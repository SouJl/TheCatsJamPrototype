namespace Shooter.Components.ColorGun
{
    internal interface IExplosive
    {
        bool IsExploding { get; }
        void SetExplosive();
        void Explode();
    }
}
