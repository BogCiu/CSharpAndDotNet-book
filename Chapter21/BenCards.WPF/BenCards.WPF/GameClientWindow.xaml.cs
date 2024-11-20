using Ch13CardLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BenCards.WPF
{
    public partial class GameClientWindow : Window
    {
        private void CommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Close)
                e.CanExecute = true;
            if (e.Command == ApplicationCommands.Save)
                e.CanExecute = false;
            if (e.Command == GameViewModel.StartGameCommand)
                e.CanExecute = true;
            if (e.Command == GameOptions.OptionsCommand)
                e.CanExecute = true;
            if (e.Command == GameViewModel.ShowAboutCommand)
                e.CanExecute = true;
            e.Handled = true;
        }
        private void CommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Close)
                this.Close();
            if (e.Command == GameViewModel.StartGameCommand)
            {
                var model = new GameViewModel();
                var startGameDialog = new StartGameWindow();
                var options = GameOptions.Create();
                startGameDialog.DataContext = options;
                var result = startGameDialog.ShowDialog();
                if (result.HasValue && result.Value == true)
                {
                    options.Save();
                    model.StartNewGame();
                    DataContext = model;
                }
            }
            if (e.Command == GameOptions.OptionsCommand)
            {
                var dialog = new OptionsWindow();
                var result = dialog.ShowDialog();
                if (result.HasValue && result.Value == true)
                    DataContext = new GameViewModel(); // Clear current game
            }
            if (e.Command == GameViewModel.ShowAboutCommand)
            {
                var dialog = new AboutWindow();
                dialog.ShowDialog();
            }
            e.Handled = true;
        }
        public GameClientWindow()
        {
            InitializeComponent();
            var position = new Point(15, 15);
            //DrawAllCards();
        }
        private void DrawAllCards()
        {

            var position = new Point(15, 15);
            for (var i = 0; i < 4; i++)
            {
                var suit = (Suit)i;
                position.Y = 15;
                for (int rank = 1; rank < 14; rank++)
                {
                    position.Y += 30;
                    var card = new CardControl(new Card((Suit)suit, (Rank)rank));
                    card.VerticalAlignment = VerticalAlignment.Top;
                    card.HorizontalAlignment = HorizontalAlignment.Left;
                    card.Margin = new Thickness(position.X, position.Y, 0, 0);
                    contentGrid.Children.Add(card);
                }
                position.X += 112;
            }
        }
    }
}
