using SimpleBattleGameLib.ApplicationModels;
using SimpleBattleGameLib.InfrastructureModels;

class Program
{
    static void Main(string[] args)
    {
        // Создаем двух игроков
        var firstPlayer = new Player("Игрок 1");
        var secondPlayer = new Player("Игрок 2");

        var gameManager = new GameManager(new List<Player>
        {
            firstPlayer,
            secondPlayer
        });

        gameManager.StartGame();

        PrintMap(gameManager.MapManager.Map);

        var build = new BuildActionItem(BuildType.Mine, new MapPosition { X = 0, Y = 0 }, BuildAction.Build);


        var step = new PlayerStep(gameManager.CurrentStepPlayer,
            new BuildStep([build]),
            null);

        gameManager.DoStep(step);

        PrintMap(gameManager.MapManager.Map);

        build = new BuildActionItem(BuildType.Mine, new MapPosition { X = 0, Y = 0 }, BuildAction.Build);


        step = new PlayerStep(gameManager.CurrentStepPlayer,
            new BuildStep([build]),
            null);

        gameManager.DoStep(step);

        PrintMap(gameManager.MapManager.Map);

        build = new BuildActionItem(new MapPosition { X = 8, Y = 8 }, BuildAction.Destroy);


        step = new PlayerStep(gameManager.CurrentStepPlayer,
            new BuildStep([build]),
            null);

        gameManager.DoStep(step);

        PrintMap(gameManager.MapManager.Map);

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

            if (build is Mine mine)
            {
                displayMap[mine.MapPosition.X, mine.MapPosition.Y] = '$';
            }
        }

        Console.WriteLine("\n\n");

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