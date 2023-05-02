using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarHacha : MonoBehaviour
{   
    [SerializeField] Transform target;
    [SerializeField] Camera mainCam;
    [SerializeField] private KeyCode shootCoode;
    [SerializeField] private Transform shootctrl;

    public GameObject bulletPrefab;
    public Rigidbody2D rb;
    

    private void Start()
    {
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }
    void Update()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 lookAtDir = mousePos - target.position;
        target.up = lookAtDir;

        if (Input.GetKey(shootCoode))
        {
            Lanzar();
        }
    }

    public void Lanzar()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootctrl.position, shootctrl.rotation);
    }


}
