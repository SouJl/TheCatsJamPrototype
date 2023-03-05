using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    float _currentLifeTime;
    float _maxLifeTime;

    public void Init(float maxLifeTime)
    {
        gameObject.SetActive(false);
        _maxLifeTime = maxLifeTime;
    }

    public void Consume()
    {
        gameObject.SetActive(false);
        _currentLifeTime = 0f;
    }

    void Update()
    {
        _currentLifeTime += Time.deltaTime;
        if (_currentLifeTime > _maxLifeTime)
        {
            gameObject.SetActive(false);
            _currentLifeTime = 0f;
        }
    }
}
