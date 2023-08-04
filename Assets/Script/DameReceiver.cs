using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameReceiver : MonoBehaviour
{
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int hpMax = 5;
    [SerializeField] protected bool isDead = false;

    public int HP => hp;
    public int HPMax => hpMax;

    protected void OnEnable()
    {
        this.Reborn();
    }

    protected void ResetValue()
    {
        this.Reborn();
    }
    public void Reborn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
    }

    public void Add(int add)
    {
        if (this.isDead) return;
        this.hp += add;
        if (this.hp > this.hpMax) this.hp = this.hpMax;
    }

    public void Deduct(int deduct)
    {
        if (this.isDead) return;
        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    public bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
    }
}
