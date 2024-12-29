namespace SimpleBattleGameLib.ApplicationModels
{
    public abstract class Entity : MapObject
    {
        public int Health { get; set; }
        public int Damage { get; set; }
    }
}
