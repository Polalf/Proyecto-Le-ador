using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject player;
    public void CargarEscena(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }
    public void Inicio()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<Player>().enabled = true;
    }
}
