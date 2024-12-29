using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class TownHall : Build
    {
        public TownHall(MapPosition mapPosition)
        {
            Health = 100;
            MapPosition = mapPosition;
            ActionPoint = 0;
            PointToAction = 5;
        }
    }
}
