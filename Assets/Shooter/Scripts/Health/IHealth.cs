using UnityEngine;

public interface IHealth
{
    GameObject gameObject { get; }
    void Init(float maxLifeTime);
    void Consume();
}
