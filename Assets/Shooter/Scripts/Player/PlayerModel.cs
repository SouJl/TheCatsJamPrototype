namespace Shooter.Player
{
    internal interface IPlayer
    {
        float Speed { get; }
    }

    internal interface IHealth
    {
        int HealthPoints { get; }
    }

    internal class PlayerModel : IPlayer
    {
        public float Speed { get; private set; }

        public PlayerModel(IPlayerConfig config)
        {
            Speed = config.Speed;
        }
    }

    internal class HealthModel : IHealth
    {
        public int HealthPoints { get; private set; }

        public HealthModel(IHealthConfig config)
        {
            HealthPoints = config.HealthPoints;
        }
    }
}
