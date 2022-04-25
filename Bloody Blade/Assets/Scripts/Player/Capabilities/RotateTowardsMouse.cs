using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    [SerializeField] private inputController input = null;
    [SerializeField] private Camera cam;
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] private float offset = 90.0f;
    Vector2 mousePos;
    

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(input.retrieveMousePos());
    }

    void FixedUpdate(){
        Vector2 lookDir = mousePos - playerRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - offset;
        playerRb.rotation = angle;
    }
}
