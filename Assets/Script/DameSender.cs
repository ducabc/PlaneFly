using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSender : MonoBehaviour
{
    [SerializeField] protected int dmg = 1;
    public void Send(Transform obj)
    {
        DameReceiver damageReceiver = obj.GetComponentInChildren<DameReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    public void Send(DameReceiver damageReceiver)
    {
        Debug.Log(this.dmg);
        damageReceiver.Deduct(this.dmg);
    }
}
