using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 position;
    public bool imortal = false;
    protected BoxCollider2D boxCollider;
    protected DameReceiver dameReceiver;
    private void Start()
    {
        dameReceiver = transform.GetComponentInChildren<DameReceiver>();
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }
    private void Update()
    {
        if(NeedMove())
            Move(1, position, gameObject);
        boxCollider.isTrigger = EnemyManager.Instance.enemyImortal;
        CheckDead();
    }
    protected void Move(float speed, Vector3 movePoint, GameObject enemy)
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, movePoint, speed * Time.deltaTime);
    }
    protected bool NeedMove()
    {
        if(Vector3.Distance(transform.position, position) < 0.01f)
        {
            imortal = true;
            return false;
        }
        imortal=false;
        return true;
    }

    protected void CheckDead()
    {
        if (dameReceiver.IsDead())
        {
            GameCtrl.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
