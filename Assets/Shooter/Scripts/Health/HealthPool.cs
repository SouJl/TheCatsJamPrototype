using System;
using System.Collections.Generic;

public class HealthPool
{
    readonly List<IHealth> _healths;

    public HealthPool()
    {
        _healths = new List<IHealth>();
    }

    public void AddHealth(IHealth bullet)
    {
        _healths.Add(bullet);
    }

    public IHealth GetHealth()
    {
        return _healths.Find(bullet => !bullet.gameObject.activeSelf);
    }
}
