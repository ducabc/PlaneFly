using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiletMove : MonoBehaviour
{
    [SerializeField] protected float speedBui = 0.5f;
    [SerializeField] protected float timeFly = 2f;
    [SerializeField] protected DameSender sender;
    private void Start()
    {
        sender = GetComponentInChildren<DameSender>();
    }
    private void Update()
    {
        transform.position += speedBui * Time.deltaTime * transform.up;
        if (timeFly > 0) timeFly -= Time.deltaTime;
        else Despawn();

    }

    protected void Despawn()
    {
        BuiletManager.Instance.Despawn(transform);
        timeFly = 2f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Despawn();
            sender.Send(collision.gameObject.transform);
        }
    }
}
