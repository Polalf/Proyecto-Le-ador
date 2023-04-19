using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse : MonoBehaviour
{
    public GameObject brazoNormal;
    public KeyCode keyShooter;
    void Update()
    {
        if(Input.GetKey(keyShooter))
        {
            brazoNormal.SetActive(false);
            gameObject.SetActive(true);
        }
        else
        {
            brazoNormal.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
