using SimpleBattleGameLib.InfrastructureModels;

public class GameGeneratorTests
{
    [Fact]
    public void GenerateMap_ShouldCreateMapWithCorrectSize()
    {
        // Arrange
        var firstPlayer = new Player("»грок 1");
        var secondPlayer = new Player ("»грок 2");
        var gameGenerator = new GameGenerator(firstPlayer, secondPlayer);

        // Act
        var map = gameGenerator.GenerateMap();

        // Assert
        Assert.Equal(100, map.MapPlaces.Count); // ѕроверка количества клеток (10x10)
    }

    [Fact]
    public void GenerateMap_ShouldPlaceTownHallsInCorrectAreas()
    {
        // Arrange
        var firstPlayer = new Player("Player1");
        var secondPlayer = new Player("Player2");
        var gameGenerator = new GameGenerator(firstPlayer, secondPlayer);

        // Act
        var map = gameGenerator.GenerateMap();

        // Assert
        bool firstPlayerTownHallFound = false;
        bool secondPlayerTownHallFound = false;

        foreach (var build in map.Builds)
        {
            if (build is TownHall townHall)
            {
                if (townHall.MapPosition.Y < 5) // ¬ерхн€€ область дл€ первого игрока
                {
                    firstPlayerTownHallFound = true;
                }
                else if (townHall.MapPosition.Y >= 5) // Ќижн€€ область дл€ второго игрока
                {
                    secondPlayerTownHallFound = true;
                }
            }
        }

        Assert.True(firstPlayerTownHallFound, "TownHall дл€ первого игрока не найден в верхней области.");
        Assert.True(secondPlayerTownHallFound, "TownHall дл€ второго игрока не найден в нижней области.");
    }
}