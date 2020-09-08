using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Movement script for Mouse/Mobile
public class Movement : MonoBehaviour
{
    public Transform player;
    public float speed = 10.0f;
    private bool touching = false;
    private Vector3 pointA;
    private Vector3 pointB;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        if(Input.GetMouseButton(0))
        {
            touching = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touching = false;
        }
    }

    private void FixedUpdate()
    {
        if (touching)
        {
            Vector3 offset = pointB - pointA;
            Vector3 direction = Vector3.ClampMagnitude(offset, 1.0f);
            movePlayer(direction * -1);
        }
    }

    void movePlayer(Vector3 direction)
    {
        direction.y = 0;
        player.Translate(direction * speed * Time.deltaTime);
    }
}
