using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class Field : MapPlace
    {
        public Field(MapPosition mapPosition)
        {
            IsPassable = true;
            MapPosition = mapPosition;
        }
    }
}
