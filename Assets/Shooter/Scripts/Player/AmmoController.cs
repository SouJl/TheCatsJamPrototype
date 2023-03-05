using Shooter;
using Shooter.Player;
using Shooter.Tool;
using UnityEngine;

public class AmmoController : IExecute
{
    public float CurrentAmmo => _currentAmmo;
    private readonly string _configPath = @"Configs/Ammo/AmmoConfig";

    IAmmoConfig _config;
    float _currentAmmo;
    float _nextRechargeTime;

    public AmmoController()
    {
        _config = LoadConfig(_configPath);
        _currentAmmo = 1f;
        _nextRechargeTime = 0f;
    }

    public void Execute()
    {
        //if (_currentAmmo < 1f)
        //{
        //    if (Time.time > _nextRechargeTime)
        //    {
        //        _nextRechargeTime += ammoRechargePeriod;
        //        AddAmmo(ammoPerRecharge);
        //    }
        //}
    }

    public bool CanShoot()
    {
        return _currentAmmo >= 1;
    }

    public void AddEnemyAmmo()
    {
        _currentAmmo += _config.AmmoPerEnemy;

        if (_currentAmmo > 1f)
        {
            _currentAmmo = 1f;
        }
    }

    public void ResetAmmo()
    {
        _currentAmmo = 0;
    }

    public void Dispose() { }

    public void FixedExecute() { }

    private IAmmoConfig LoadConfig(string path) => ResourceLoader.LoadObject<AmmoConfig>(path);
}
