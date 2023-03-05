﻿using Shooter.Components.ColorGun;
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

        public void Init(
            AmmoController ammoController,
            HealthController healthController,
            ScoreController scoreController)
        {
            _killerZoneComponent.Init(ammoController, healthController, scoreController);
            _gunComponent.Init(ammoController, transform);
            _healthPickupZoneComponent.Init(healthController);
        }
    }
}
