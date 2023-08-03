using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Vector3> positions;
    [SerializeField] protected List<Enemy> enemyList;
    [SerializeField] protected Transform enemy;
    [SerializeField] protected float timeTran = 0;
    protected int statusEnemy = 1;
    public EnemyPosition enemyPosition;
    private void Start()
    {
        SpamEnemy(16);
        LoadEnemyList();
    }
    private void Update()
    {
        this.timeTran += Time.deltaTime;
        if(timeTran > 10)
        {
            timeTran = 0;
            AutoLoadPosition();
            EnemyMoveToPoint();
            statusEnemy ++;
            if(statusEnemy > 4)
            {
                statusEnemy = 1;
            }
        }
    }
    protected void LoadEnemyList()
    {
        enemyList.AddRange(holder.GetComponentsInChildren<Enemy>());
        EnemyMoveToPoint();
    }
    protected void EnemyMoveToPoint()
    {
        for(int i = 0; i < positions.Count; i++)
        {
            if(enemyList[i] == null) continue;
            enemyList[i].position = positions[i];
        }
    }
    protected void SpamEnemy(float n)
    {
        for(int i = 0; i < n; i++)
        {
            Transform newEnemy = Instantiate(this.enemy);
            newEnemy.transform.SetParent(holder);
            newEnemy.gameObject.SetActive(true);
        }
    }
    protected void Reset()
    {
        this.AutoLoadPosition();
        this.LoadHolder();
        this.LoadEnemy();
    }

    protected void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("EnemyHolder");
    }
    protected void LoadEnemy()
    {
        if (this.enemy != null) return;
        this.enemy = transform.Find("Enemy");
        enemy.gameObject.SetActive(false);
    }
    protected void AutoLoadPosition()
    {
        this.enemyPosition = transform.GetComponentInChildren<EnemyPosition>();
        switch (statusEnemy)
        {
            case 1: LoadPosition(enemyPosition._enemySquarePositions); break;
            case 2: LoadPosition(enemyPosition._enemyRhombusPositions); break;
            case 3: LoadPosition(enemyPosition._enemyRectanglePositions); break;
            case 4: LoadPosition(enemyPosition._enemyTrianglePositions); break;
        }
    }
    protected void LoadPosition(List<Vector3> enemyPosition)
    {
        this.positions.Clear();
        this.positions.AddRange(enemyPosition);
    }
}
