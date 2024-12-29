namespace SimpleBattleGameLib.InfrastructureModels
{
    public class GameManager
    {
        private int _currentStep = 0;
        private Player? _currentStepPlayer;

        public int CurrentStep { get => _currentStep; }
        public Player? CurrentStepPlayer { get => _currentStepPlayer; }

        public required List<Player> Players { get; set; }
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
            var gameGenerator = new GameGenerator(Players[0], Players[1]);
            MapManager.Map = gameGenerator.GenerateMap();
        }

        public void DoStep(PlayerStep playerStep)
        {
            // Todo: PlayerStep Parser
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
