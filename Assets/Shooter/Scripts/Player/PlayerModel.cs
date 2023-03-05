namespace Shooter.Player
{
    internal interface IPlayer
    {
        int HealthPoints { get; }

        float Speed { get; }
    }

    internal class PlayerModel : IPlayer
    {
        public int HealthPoints { get; private set; }

        public float Speed { get; private set; }

        public PlayerModel(IPlayerConfig config)
        {
            HealthPoints = config.HealthPoints;
            Speed = config.Speed;
        }
    }
}
