using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    public List<Vector3> _enemyRhombusPositions;
    public List<Vector3> _enemyRectanglePositions;
    public List<Vector3> _enemySquarePositions;
    public List<Vector3> _enemyTrianglePositions;

    private void Reset()
    {
        SpamTriangle();
        SpamRhombus();
        SpamRectangle(3);
        SpamSquare();
    }

    protected void SpamRhombus()
    {
        int n = 5;
        Vector3 newPos = transform.position;
        for(int i = 0; i < n; i++)
        {
            newPos = new Vector3(transform.position.x, newPos.y - 0.7f, 0);
            if(i ==0 || i == 4)
            {
                newPos.x = transform.position.x;
                _enemyRhombusPositions.Add(newPos);
            }

        }
        newPos = new Vector3(transform.position.x -0.35f, transform.position.y - 0.7f);
        for (int i = 0; i < 3; i++)
        {
            newPos = new Vector3(newPos.x + 0.7f, transform.position.y - 0.7f);
            for (int j = 0; j < 3; j++)
            {
                newPos.y -= 0.7f;
                if (i == 2 && j == 0 || i==2 && j==2)
                {
                    continue;
                }
                else
                {
                    _enemyRhombusPositions.Add(newPos);
                    Vector3 reflectedVector = Vector3.Reflect(newPos, Vector3.right);
                    _enemyRhombusPositions.Add(reflectedVector);
                }
            }
        }
    }
    protected void SpamTriangle()
    {
        int n = 5;
        Vector3 newPos = new(transform.position.x, transform.position.y, 0);
        for (int i = 0; i < n; i++)
        {
            newPos = new Vector3(transform.position.x - 0.5f * (i + 1), newPos.y - 0.7f, 0);
            for (int k = 0; k < 2 * i + 1; k++)
            {
                newPos.x += 0.5f;
                if (k == 0 || k == 2 * i || i == n - 1)
                {
                    _enemyTrianglePositions.Add(newPos);
                }
            }
        }
    }
    protected void SpamRectangle(int x)
    {
        int n = (16 - x * 2 + 4) / 2;
        Vector3 newPos = new(transform.position.x, transform.position.y, 0);
        for (int i = 0; i < x; i++)
        {
            newPos = new Vector3(transform.position.x - 0.5f * (n / 2 + 1), newPos.y - 0.7f, 0);
            for (int j = 0; j < n; j++)
            {
                newPos.x += 0.5f;
                if (j == 0 || j == n - 1 || i == 0 || i == x - 1)
                {
                    _enemyRectanglePositions.Add(newPos);
                }
            }
        }
    }
    protected void SpamSquare()
    {
        Vector3 newPos = new(transform.position.x - 1.6f, transform.position.y, 0);
        for (int i = 0; i < 4; i++)
        {
            newPos = new Vector3(transform.position.x - 1.75f, newPos.y - 0.7f, 0);
            for (int j = 0; j < 4; j++)
            {
                newPos.x += 0.7f;
                _enemySquarePositions.Add(newPos);
            }
        }
    }
}
