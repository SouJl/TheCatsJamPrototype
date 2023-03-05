using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    public void Init()
    {
        gameObject.SetActive(false);
    }
}
