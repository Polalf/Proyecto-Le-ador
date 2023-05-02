using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Puzzles : MonoBehaviour
{
    public bool solve;
    public UnityEvent resuelto;
    void Update()
    {
        if (solve)
        {
            resuelto.Invoke();
        }
    }
}
