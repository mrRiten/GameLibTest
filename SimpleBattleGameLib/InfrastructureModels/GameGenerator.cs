using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class GameGenerator(Player firstPlayer, Player secondPlayer, MapManager mapManager)
    {
        public Player FirstPlayer { get; set; } = firstPlayer;
        public Player SecondPlayer { get; set; } = secondPlayer;

        private readonly MapManager _mapManager = mapManager;

        private readonly Random _random = new();

        public Map GenerateMap()
        {
            var mapWeidth = 10;
            var mapHigth = 10;

            var map = new Map
            {
                Weidth = mapWeidth,
                Higth = mapHigth,
                MapPlaces = [],
                Entities = [],
                Builds = []
            };

            // Генерация клеток карты 10 на 10
            for (int x = 0; x < mapWeidth; x++)
            {
                for (int y = 0; y < mapHigth; y++)
                {
                    var field = new Field(new MapPosition { X = x, Y = y });
                    map.MapPlaces.Add(field);
                }
            }

            // Генерация случайной позиции для TownHall первого игрока (верхняя область: y от 0 до 4)
            var firstPlayerTownHallPosition = new MapPosition
            {
                X = _random.Next(0, 10), // Случайная позиция по X
                Y = _random.Next(0, 5)    // Случайная позиция по Y (от 0 до 4)
            };

            var firstPlayerTownHall = new TownHall(firstPlayerTownHallPosition);
            map.Builds.Add(firstPlayerTownHall);
            FirstPlayer.TownHall = firstPlayerTownHall;
            FirstPlayer.Builds.Add(firstPlayerTownHall);

            map.MapPlaces.Remove(map.MapPlaces.FirstOrDefault(mp => mp.MapPosition == firstPlayerTownHallPosition));

            // Генерация случайной позиции для TownHall второго игрока (нижняя область: y от 5 до 9)
            var secondPlayerTownHallPosition = new MapPosition
            {
                X = _random.Next(0, 10), // Случайная позиция по X
                Y = _random.Next(5, 10)   // Случайная позиция по Y (от 5 до 9)
            };
            
            var secondPlayerTownHall = new TownHall(secondPlayerTownHallPosition);
            map.Builds.Add(secondPlayerTownHall);
            SecondPlayer.TownHall = secondPlayerTownHall;
            SecondPlayer.Builds.Add(secondPlayerTownHall);

            map.MapPlaces.Remove(map.MapPlaces.FirstOrDefault(mp => mp.MapPosition == secondPlayerTownHallPosition));

            return map;
        }
    }
}