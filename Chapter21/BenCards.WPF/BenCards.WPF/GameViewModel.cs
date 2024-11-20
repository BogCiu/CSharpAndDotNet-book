using Ch13CardLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace BenCards.WPF
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private GameOptions gameOptions;

        public static RoutedCommand StartGameCommand = new RoutedCommand("Start New Game", typeof(GameViewModel), 
            new InputGestureCollection(new List<InputGesture> { new KeyGesture(Key.N, ModifierKeys.Control) }));
        public static RoutedCommand ShowAboutCommand = new RoutedCommand("Show About Dialog", typeof(GameViewModel)); 


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private Player currentPlayer;
        public Player CurrentPlayer
        {
            get { return currentPlayer; }
            set
            {
                currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }
        private List<Player> players;
        public List<Player> Players
        {
            get { return players; }
            set
            {
                players = value;
                OnPropertyChanged(nameof(Players));
            }
        }
        private Card availableCard;
        public Card CurrentAvailableCard
        {
            get { return availableCard; }
            set
            {
                availableCard = value;
                OnPropertyChanged(nameof(CurrentAvailableCard));
            }
        }
        private Deck deck;
        public Deck GameDeck
        {
            get { return deck; }
            set
            {
                deck = value;
                OnPropertyChanged(nameof(GameDeck));
            }
        }
        private bool gameStarted;
        public bool GameStarted
        {
            get { return gameStarted; }
            set
            {
                gameStarted = value;
                OnPropertyChanged(nameof(GameStarted));
            }
        }

        public GameViewModel()
        {
            players = new List<Player>();
            gameOptions = GameOptions.Create();
        }
        public void StartNewGame()
        {
            if (gameOptions.SelectedPlayers.Count < 1 || (gameOptions.SelectedPlayers.Count == 1 && !gameOptions.PlayAgainstComputer))
                return;
            CreateGameDeck();
            CreatePlayers();
            InitializeGame();
            GameStarted = true;
        }
        private void InitializeGame()
        {
            AssignCurrentPlayer(0);
            CurrentAvailableCard = GameDeck.Draw();
        }
        private void AssignCurrentPlayer(int index)
        {
            CurrentPlayer = Players[index];
            if (!Players.Any(x => x.State == PlayerState.Winner))
                Players.ForEach(x => x.State = (x == Players[index] ? PlayerState.Active : PlayerState.Inactive));
        }
        private void InitializePlayer(Player player)
        {
            player.DrawNewHand(GameDeck);
            player.OnCardDiscarded += player_OnCardDiscarded;
            player.OnPlayerHasWon += player_OnPlayerHasWon;
            Players.Add(player);
        }

        private void CreateGameDeck()
        {
            GameDeck = new Deck();
            GameDeck.Shuffle();
        }
        private void CreatePlayers()
        {
            Players.Clear();
            for (var i = 0; i < gameOptions.NumberOfPlayers; i++)
            {
                if (i < gameOptions.SelectedPlayers.Count)
                    InitializePlayer(new Player
                    {
                        Index = i,
                        PlayerName = gameOptions.SelectedPlayers[i]
                    });
                else
                    InitializePlayer(new ComputerPlayer
                    {
                        Index = i,
                        Skill = gameOptions.ComputerSkill
                    });
            }
        }
        void player_OnPlayerHasWon(object sender, PlayerEventArgs e)
        {
            Players.ForEach(x => x.State = (x == e.Player ? PlayerState.Winner : PlayerState.Loser));
        }
        void player_OnCardDiscarded(object sender, CardEventArgs e)
        {
            CurrentAvailableCard = e.Card;
            var nextIndex = CurrentPlayer.Index + 1 >= gameOptions.NumberOfPlayers ? 0 : CurrentPlayer.Index + 1;
            if (GameDeck.CardsInDeck == 0)
            {
                var cardsInPlay = new List<Card>();
                foreach (var player in Players)
                    cardsInPlay.AddRange(player.GetCards());
                cardsInPlay.Add(CurrentAvailableCard);
                GameDeck.ReshuffleDiscarded(cardsInPlay);
            }
            AssignCurrentPlayer(nextIndex);
        }
    }
}
