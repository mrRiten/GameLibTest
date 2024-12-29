namespace SimpleBattleGameLib.ApplicationModels
{
    public abstract class Solder : Entity
    {
        public abstract void Attack(int x, int y);
        public abstract MapPosition Move(int x, int y);
    }
}
