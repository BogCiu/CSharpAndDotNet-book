using Ch13CardLib;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace BenCards.WPF
{
    /// <summary>
    /// Interaction logic for CardsInHandControl.xaml
    /// </summary>
    public partial class CardsInHandControl : UserControl
    {

        public CardsInHandControl()
        {


        InitializeComponent();
        }
        public Player Owner
        {
            get { return (Player)GetValue(OwnerProperty); }
            set { SetValue(OwnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(Player), typeof(CardsInHandControl), new PropertyMetadata(null, new PropertyChangedCallback(OnOwnerChanged)));

        public GameViewModel Game
        {
            get { return (GameViewModel)GetValue(GameProperty); }
            set { SetValue(GameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Game.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GameProperty =
            DependencyProperty.Register("Game", typeof(GameViewModel), typeof(CardsInHandControl), new PropertyMetadata(null, new PropertyChangedCallback(OnOwnerChanged)));

        public PlayerState PlayerState
        {
            get { return (PlayerState)GetValue(PlayerStateProperty); }
            set { SetValue(PlayerStateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerState.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerStateProperty =
            DependencyProperty.Register("PlayerState", typeof(PlayerState), typeof(CardsInHandControl), new PropertyMetadata(PlayerState.Inactive, new PropertyChangedCallback(OnPlayerStateChanged)));


        public Orientation PlayerOrientation
        {
            get { return (Orientation)GetValue(PlayerOrientationProperty); }
            set { SetValue(PlayerOrientationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerOrientation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerOrientationProperty =
            DependencyProperty.Register("PlayerOrientation", typeof(Orientation), typeof(CardsInHandControl), new PropertyMetadata(Orientation.Horizontal, new PropertyChangedCallback(OnPlayerOrientationChanged)));

        private static void OnOwnerChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var control = source as CardsInHandControl;
            control.RedrawCards(); 
        }
        private static void OnPlayerStateChanged(DependencyObject source, DependencyPropertyChangedEventArgs e) 
        {
            var control = source as CardsInHandControl;
            var computerPlayer = control.Owner as ComputerPlayer;
            if (computerPlayer != null)
            {
                if (computerPlayer.State == PlayerState.MustDiscard)
                {
                    Thread delayedWorker = new Thread(control.DelayDiscard);
                    delayedWorker.Start(new Payload
                    {
                        Deck = control.Game.GameDeck,
                        AvailableCard = control.Game.CurrentAvailableCard,
                        Player = computerPlayer
                    });
                }
                else if (computerPlayer.State == PlayerState.Active)
                {
                    Thread delayedWorker = new Thread(control.DelayDraw);
                    delayedWorker.Start(new Payload
                    {
                        Deck = control.Game.GameDeck,
                        AvailableCard = control.Game.CurrentAvailableCard,
                        Player = computerPlayer
                    });
                }
            }
            control.RedrawCards(); 
        }
        private static void OnPlayerOrientationChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
        {
            var control = source as CardsInHandControl;
            control.RedrawCards();
        }
        private class Payload
        {
            public Deck Deck { get; set; }
            public Card AvailableCard { get; set; }
            public ComputerPlayer Player { get; set; } 
        }
        private void DelayDraw(object payload)
        {
            Thread.Sleep(1250);
            var data = payload as Payload;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Deck, Card>(data.Player.PerformDraw), data.Deck, data.AvailableCard); 
        }
        private void DelayDiscard(object payload)
        {
            Thread.Sleep(1250);
            var data = payload as Payload;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Deck>(data.Player.PerformDiscard), data.Deck); 
        }
    }
}
