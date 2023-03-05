using Shooter;
using Shooter.Controllers;
using Shooter.Player;
using Shooter.Tool;
using Shooter.UI;
using UnityEngine;

public class AmmoController : IExecute
{
    readonly HardcoreController _hardcoreController;
    private readonly string _configPath = @"Configs/Ammo/AmmoConfig";
    private readonly string _viewPath = @"Prefabs/UI/Health/AmmoView";

    readonly AmmoView _view;
    readonly IAmmoConfig _config;
    float _currentAmmo;

    float _currentRechargeTime;
    float _nextRechargeTime;

    public AmmoController(HardcoreController hardcoreController, Transform placeForUI)
    {
        _hardcoreController = hardcoreController;
        _currentAmmo = 1f;
        _view = LoadView(placeForUI);
        _view.Init(_currentAmmo);

        _config = LoadConfig(_configPath);
        _nextRechargeTime = _currentRechargeTime + _config.AmmoRechargePeriod;
    }

    public void Execute()
    {
        if (_currentAmmo < 1f)
        {
            _currentRechargeTime += Time.deltaTime;
            if (_currentRechargeTime > _nextRechargeTime)
            {
                _currentRechargeTime = _nextRechargeTime;
                _nextRechargeTime = _currentRechargeTime + _config.AmmoRechargePeriod;
                AddTimerAmmo();
            }
        }
    }

    public bool CanShoot()
    {
        return _currentAmmo >= 1;
    }

    public void AddEnemyAmmo()
    {
        _currentAmmo += _hardcoreController.GetEnemyAmmoHealth();

        if (_currentAmmo > 1f)
            _currentAmmo = 1f;

        _view.SetAmmo(_currentAmmo);
    }

    void AddTimerAmmo()
    {
        _currentAmmo += _config.AmmoPerRecharge;

        if (_currentAmmo > 1f)
            _currentAmmo = 1f;

        _view.SetAmmo(_currentAmmo);
    }

    public void ResetAmmo()
    {
        _currentAmmo = 0;
        _view.SetAmmo(_currentAmmo);
    }

    public void Dispose() { }

    public void FixedExecute() { }

    private IAmmoConfig LoadConfig(string path) => ResourceLoader.LoadObject<AmmoConfig>(path);

    AmmoView LoadView(Transform placeforUI)
    {
        GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeforUI, false);
        return objectView.GetComponent<AmmoView>();
    }
}
