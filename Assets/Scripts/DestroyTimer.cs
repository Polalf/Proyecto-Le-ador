using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float tiempo;

    
    void Update()
    {
        Destroy(gameObject, tiempo);
    }
}
