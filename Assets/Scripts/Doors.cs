using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Doors : MonoBehaviour
{
    public UnityEvent Open;
    public void openDoor()
    {
        Open.Invoke();
    }
}
