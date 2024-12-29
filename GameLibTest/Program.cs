using SimpleBattleGameLib.InfrastructureModels;

class Program
{
    static void Main(string[] args)
    {
        // Создаем двух игроков
        var firstPlayer = new Player("Игрок 1" );
        var secondPlayer = new Player("Игрок 2");

        // Создаем генератор игры
        var gameGenerator = new GameGenerator(firstPlayer, secondPlayer);

        // Генерируем карту
        Map generatedMap = gameGenerator.GenerateMap();

        // Выводим карту в консоль
        PrintMap(generatedMap);
    }

    static void PrintMap(Map map)
    {
        // Создаем двумерный массив для представления карты
        char[,] displayMap = new char[10, 10];

        // Заполняем карту символами "."
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                displayMap[x, y] = '.';
            }
        }

        // Устанавливаем символы для TownHall
        foreach (var build in map.Builds)
        {
            if (build is TownHall townHall)
            {
                displayMap[townHall.MapPosition.X, townHall.MapPosition.Y] = '^';
            }
        }

        // Выводим карту в консоль
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Console.Write(displayMap[x, y] + " ");
            }
            Console.WriteLine();
        }
    }
}