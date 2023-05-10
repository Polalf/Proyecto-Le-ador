using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInicio : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
        Time.timeScale = 0;
        player.GetComponent<Player>().enabled = false;
    }

   
}
