using SimpleBattleGameLib.InfrastructureModels;

public class GameGeneratorTests
{
    [Fact]
    public void GenerateMap_ShouldCreateMapWithCorrectSize()
    {
        // Arrange
        var firstPlayer = new Player("����� 1");
        var secondPlayer = new Player ("����� 2");
        var gameGenerator = new GameGenerator(firstPlayer, secondPlayer);

        // Act
        var map = gameGenerator.GenerateMap();

        // Assert
        Assert.Equal(100, map.MapPlaces.Count); // �������� ���������� ������ (10x10)
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
                if (townHall.MapPosition.Y < 5) // ������� ������� ��� ������� ������
                {
                    firstPlayerTownHallFound = true;
                }
                else if (townHall.MapPosition.Y >= 5) // ������ ������� ��� ������� ������
                {
                    secondPlayerTownHallFound = true;
                }
            }
        }

        Assert.True(firstPlayerTownHallFound, "TownHall ��� ������� ������ �� ������ � ������� �������.");
        Assert.True(secondPlayerTownHallFound, "TownHall ��� ������� ������ �� ������ � ������ �������.");
    }
}