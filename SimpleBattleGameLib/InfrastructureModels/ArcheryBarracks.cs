using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class ArcheryBarracks : Build
    {
        public ArcheryBarracks(MapPosition mapPosition)
        {
            Health = 50;
            ActionPoint = 0;
            PointToAction = 2;
            MapPosition = mapPosition;
        }
    }
}
