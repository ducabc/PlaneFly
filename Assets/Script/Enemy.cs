using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 position;

    private void Update()
    {
        if(NeedMove())
            Move(1, position, gameObject);
    }
    protected void Move(float speed, Vector3 movePoint, GameObject enemy)
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, movePoint, speed * Time.deltaTime);
    }
    protected bool NeedMove()
    {
        if(Vector3.Distance(transform.position, position) < 0.01f)
        {
            return false;
        }
        return true;
    }
}
