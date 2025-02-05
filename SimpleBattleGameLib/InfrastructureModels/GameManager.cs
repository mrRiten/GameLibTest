namespace SimpleBattleGameLib.InfrastructureModels
{
    public class GameManager
    {
        private int _currentStep = 0;
        private int _curentUserListIndex = 0;
        private Player? _currentStepPlayer;

        public int CurrentStep { get => _currentStep; }
        public Player? CurrentStepPlayer { get => _currentStepPlayer; }

        public List<Player> Players { get; set; }
        public MapManager MapManager { get; set; }

        public GameManager(List<Player> players)
        {
            if (players.Count != 2) throw new ArgumentException(null, nameof(players));

            Players = players;
            MapManager = new MapManager();
        }

        public Player GetPlayer(string name)
        {
            return Players.First(p => p.Name == name);
        }

        public void StartGame()
        {
            if (_currentStep != 0) return;
            var gameGenerator = new GameGenerator(Players[0], Players[1], MapManager);

            MapManager.Map = gameGenerator.GenerateMap();

            SetNextPlayerStep();
        }

        public void DoStep(PlayerStep playerStep)
        {
            var stepExecuter = new PlayerStepExecutor(playerStep, MapManager);

            stepExecuter.Execute();

            SetNextPlayerStep();
        }

        private void SetNextPlayerStep()
        {
            if (_currentStepPlayer == null)
            {
                var index = new Random().Next(0, 2);
                _currentStepPlayer = Players[index];
                _curentUserListIndex = index;

                return;
            }

            if (_curentUserListIndex == 0)
            {
                _curentUserListIndex = 1;
                _currentStepPlayer = Players[_curentUserListIndex];

                return;
            }

            _curentUserListIndex = 0;
            _currentStepPlayer = Players[_curentUserListIndex];
        }

        public bool IsGameContinue()
        {
            if (Players[0].TownHall != null && Players[1].TownHall != null)
            {
                return true;
            }
            return false;
        }
    }
}
