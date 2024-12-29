using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class BuildFactory(Player player)
    {
        // Todo delete static
        private readonly Player _player = player;

        public Mine CreateMine(MapPosition mapPosition)
        {
            return new Mine(mapPosition);
        }
    }
}
