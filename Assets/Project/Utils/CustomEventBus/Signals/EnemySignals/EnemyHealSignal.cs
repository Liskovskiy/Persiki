namespace CustomEventBus.Signals
{
    public class EnemyHealSignal
    {
        public readonly int Health;

        public EnemyHealSignal(int health)
        {
            Health = health;
        }
    }
}