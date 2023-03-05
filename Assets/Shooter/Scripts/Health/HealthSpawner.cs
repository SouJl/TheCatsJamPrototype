using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    [SerializeField] Health _healthPrefab;
    HealthPool _healthPool;
    Vector2 _minScreenBounds;
    Vector2 _maxScreenBounds;
    float _maxLifeTime;

    public void Init(float maxLifeTime)
    {
        _maxLifeTime = maxLifeTime;
        _healthPool = new HealthPool();

        _minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        _maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    public void Spawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(_minScreenBounds.x, _maxScreenBounds.x),
                                            Random.Range(_minScreenBounds.y, _maxScreenBounds.y));

        var health = _healthPool.GetHealth();
        if (health == null)
        {
            health = Instantiate(_healthPrefab, spawnPosition, Quaternion.identity);
            _healthPool.AddHealth(health);
        }

        health.Init(_maxLifeTime);
        health.gameObject.transform.position = spawnPosition;
        health.gameObject.SetActive(true);
    }
}
