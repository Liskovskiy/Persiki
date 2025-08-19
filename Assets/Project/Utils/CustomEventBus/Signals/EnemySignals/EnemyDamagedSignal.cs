namespace CustomEventBus.Signals
{
    public class EnemyDamagedSignal
    {
        public readonly int Health;

        public EnemyDamagedSignal(int health)
        {
            Health = health;
        }
    }
}