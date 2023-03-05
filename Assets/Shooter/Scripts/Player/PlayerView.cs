using Shooter.Components.ColorGun;
using Shooter.UI;
using UnityEngine;

namespace Shooter.Player
{
    internal interface IPlayerView { }

    internal sealed class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private KillerZoneComponent _killerZoneComponent;
        [SerializeField] private GunComponent _gunComponent;

        public void Init(AmmoController ammoController, HealthController healthController)
        {
            _killerZoneComponent.Init(ammoController, healthController);
            _gunComponent.Init(ammoController, transform);
        }
    }
}
