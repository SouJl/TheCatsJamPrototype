using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] float initialAmmo;

    public float ammoPerShot;
    public float ammoPerEnemy;
    public float ammoPerRecharge;
    public float ammoRechargePeriod;

    public float CurrentAmmo => _currentAmmo;

    float _currentAmmo;
    float _nextRechargeTime;

    void Awake()
    {
        _currentAmmo = initialAmmo;
        _nextRechargeTime = 0f;
    }

    private void Update()
    {
        if (_currentAmmo < 1f)
        {
            if (Time.time > _nextRechargeTime)
            {
                _nextRechargeTime += ammoRechargePeriod;
                AddAmmo(ammoPerRecharge);
            }
        }
    }

    public void AddAmmo(float percentage) 
    {
        _currentAmmo += percentage;

        if (_currentAmmo > 1f)
        {
            _currentAmmo = 1f;
        }
    }

    public void SubstractAmmo(float percentage) 
    {
        _currentAmmo -= percentage;

        if (_currentAmmo < 0f)
        {
            _currentAmmo = 0f;
        }
    }
}
