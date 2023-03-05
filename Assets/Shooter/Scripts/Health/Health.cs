using System;
using System.Collections;
using System.Collections.Generic;
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
