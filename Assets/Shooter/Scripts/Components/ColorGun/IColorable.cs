namespace Shooter.Components.ColorGun
{
    internal interface IColorable
    {
        bool IsColored { get; set; }
        void SetColored();
        void SetDefaultColored();
    }
}