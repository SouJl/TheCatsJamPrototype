using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    [SerializeField] private Health _healthPrefab;
    [SerializeField] private Vector2 _screenOffset;
    HealthPool _healthPool;
    Vector2 _minScreenBounds;
    Vector2 _maxScreenBounds;
    float _maxLifeTime;

    public void Init(float maxLifeTime)
    {
        _maxLifeTime = maxLifeTime;
        _healthPool = new HealthPool();

        _minScreenBounds 
            = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        _maxScreenBounds 
            = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - _screenOffset.x, Screen.height - _screenOffset.y));
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
