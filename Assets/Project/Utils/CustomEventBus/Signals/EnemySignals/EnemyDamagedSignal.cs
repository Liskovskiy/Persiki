namespace CustomEventBus.Signals
{
    public class EnemyDamagedSignal
    {
        public readonly int Health;
        public readonly Enemy Enemy;

        public EnemyDamagedSignal(Enemy enemy, int damage)
        {
            Enemy = enemy;
            Health = damage;
        }
    }
}