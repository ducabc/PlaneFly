using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public BoxCollider2D player;
    public float moveSpeed = 0.1f;
    public Vector3 positionMouse;

    private void Reset()
    {
        player = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        this.positionMouse  = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.positionMouse.z = 0;
        Vector3 newPos = Vector3.Lerp(transform.position, positionMouse, this.moveSpeed);
        transform.position = newPos;
    }
}
