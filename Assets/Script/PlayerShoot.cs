using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] protected float timeDelay = 0.1f;
    protected float timeTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        this.timeTimer += Time.deltaTime;
        if (this.timeTimer < this.timeDelay) return;
        this.timeTimer = 0;
        Transform newBuilet = BuiletManager.Instance.Spawn("Builet", transform.position,Quaternion.identity);
        newBuilet.gameObject.SetActive(true);
    }
}
