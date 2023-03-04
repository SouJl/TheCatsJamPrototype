namespace Shooter.Components.ColorGun
{
    internal interface IExplosive
    {
        bool IsExploding { get; set; }
        void Explode();
    }
}