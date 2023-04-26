using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Puzzles : MonoBehaviour
{
    public GameObject door;
    public bool solve;
    public UnityEvent resuelto;
    void Update()
    {
        //if (solve)
        //{
        //    door.GetComponent<Doors>().openDoor();
        //}
        if (solve)
        {
            resuelto.Invoke();
        }
    }
}
