using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    public GameObject door;
    public bool solve;
    void Update()
    {
        if(solve)
        {
            door.GetComponent<Doors>().openDoor();
        }
    }
}
