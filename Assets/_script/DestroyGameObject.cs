using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public float lifetime = 2f;
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
