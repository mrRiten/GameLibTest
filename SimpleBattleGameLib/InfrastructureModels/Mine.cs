using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class Mine : Build
    {
        public Mine(MapPosition mapPosition)
        {
            Health = 50;
            ActionPoint = 0;
            PointToAction = 1;
            MapPosition = mapPosition;
        }
    }
}
