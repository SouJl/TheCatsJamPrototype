using Shooter.Components.ColorGun;
using Shooter.Controllers;
using Shooter.UI;
using UnityEngine;

namespace Shooter.Player
{
    internal interface IPlayerView { }

    internal sealed class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private KillerZoneComponent _killerZoneComponent;
        [SerializeField] private HealthPickupZoneComponent _healthPickupZoneComponent;
        [SerializeField] private GunComponent _gunComponent;
        [SerializeField] MovementManager _movementManager;

        public void Init(AmmoController ammoController,
            HealthController healthController,
            ScoreController scoreController,
            PauseController pauseController)
        {
            _killerZoneComponent.Init(ammoController, healthController, scoreController);
            _gunComponent.Init(ammoController, transform, pauseController);
            _healthPickupZoneComponent.Init(healthController);
            _movementManager.Init(pauseController);
        }
    }
}
