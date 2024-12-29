using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class Infantry : Solder
    {
        public Infantry(Player playerOwner, MapPosition mapPosition)
        {
            Health = 30;
            Damage = 20;

            MapPosition = mapPosition;
        }

        public override void Attack(int targetX, int targetY)
        {
            if (IsInRangeAttack(targetX, targetY))
            {
                // Логика атаки: здесь вы можете добавить логику для нахождения цели и нанесения урона
                // Например, вы можете получить цель из списка сущностей на карте
                // И затем уменьшить здоровье цели на величину урона

                // Пример:
                // var target = FindTarget(targetX, targetY);
                // if (target != null)
                // {
                //     target.Health -= Damage;
                // }
            }
            else
            {
                Console.WriteLine("Цель вне досягаемости.");
            }
        }

        public override MapPosition Move(int newX, int newY)
        {
            if (IsValidMove(newX, newY))
            {
                MapPosition = new MapPosition { X = newX, Y = newY };
                return MapPosition;
            }
            else
            {
                return MapPosition;
            }
        }

        private bool IsInRangeAttack(int targetX, int targetY)
        {
            return Math.Abs(MapPosition.X - targetX) <= 1 && Math.Abs(MapPosition.Y - targetY) <= 1;
        }

        private bool IsValidMove(int newX, int newY)
        {
            return Math.Abs(MapPosition.X - newX) <= 1 && Math.Abs(MapPosition.Y - newY) <= 1;
        }
    }
}
