namespace SimpleBattleGameLib.ApplicationModels
{
    public abstract class Build : MapObject
    {
        public int Health { get; set; }
        public int ActionPoint { get; set; }
        public int PointToAction { get; set; }
    }

    public enum BuildType
    {
        TownHall = 1,
        Mine = 2,
        InfantryBarracks = 3,
        CavalryBarracks = 4,
        ArcheryBarracks = 5,
    }
}
