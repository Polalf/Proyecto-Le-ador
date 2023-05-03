using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLimits : MonoBehaviour
{
    
    public bool limitBounds = false;
    public float left = -5f;
    public float right = 5f;
    public float bottom = -5f;
    public float top = 5f;

    
    [SerializeField]private Camera _camera;

    void LateUpdate()
    {
        if (limitBounds)
        {
            Vector3 bottomLeft = _camera.ScreenToWorldPoint(Vector3.zero);
            Vector3 topRight = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight));
            Vector2 screenSize = new Vector2(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);

            Vector3 boundPosition = transform.position;
            if (boundPosition.x > right - (screenSize.x / 2f))
            {
                boundPosition.x = right - (screenSize.x / 2f);
            }
            if (boundPosition.x < left + (screenSize.x / 2f))
            {
                boundPosition.x = left + (screenSize.x / 2f);
            }

            if (boundPosition.y > top - (screenSize.y / 2f))
            {
                boundPosition.y = top - (screenSize.y / 2f);
            }
            if (boundPosition.y < bottom + (screenSize.y / 2f))
            {
                boundPosition.y = bottom + (screenSize.y / 2f);
            }
            transform.position = boundPosition;
        }
        
    }
}
