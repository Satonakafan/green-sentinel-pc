using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float fLifetime;

    private void OnBecameInvisible()
    {
        Destroy(gameObject, fLifetime);
    }
}
