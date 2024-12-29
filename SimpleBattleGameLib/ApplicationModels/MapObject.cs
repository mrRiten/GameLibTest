namespace SimpleBattleGameLib.ApplicationModels
{
    public abstract class MapObject
    {
        private MapPosition? _position;

        public MapPosition MapPosition
        {
            get => _position ?? new MapPosition { X = 0, Y = 0 };
            set => _position = value;
        }
    }
}
