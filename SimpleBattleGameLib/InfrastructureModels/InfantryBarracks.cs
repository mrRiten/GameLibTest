using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class InfantryBarracks : Build
    {
        public InfantryBarracks(MapPosition mapPosition)
        {
            Health = 70;
            ActionPoint = 0;
            PointToAction = 2;
            MapPosition = mapPosition;
        }
    }
}
