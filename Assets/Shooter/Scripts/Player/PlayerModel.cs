namespace Shooter.Player
{
    internal interface IPlayer
    {
        float HealthPoints { get; }

        float Speed { get; }
    }

    internal class PlayerModel : IPlayer
    {
        public float HealthPoints { get; private set; }

        public float Speed { get; private set; }

        public PlayerModel(IPlayerConfig config)
        {
            HealthPoints = config.HealthPoints;
            Speed = config.Speed;
        }
    }
}
