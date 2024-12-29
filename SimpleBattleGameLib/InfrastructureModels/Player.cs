using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class Player(string name)
    {
        public string Name { get; set; } = name;
        public int Money { get; set; } = 0;

        // Todo: TownHall is bool???
        public TownHall? TownHall { get; set; }

        public ICollection<Build> Builds { get; set; } = [];
        public ICollection<Entity> Entities { get; set; } = [];
    }
}
