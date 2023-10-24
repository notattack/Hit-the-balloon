using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBorn : MonoBehaviour
{
    public List<GameObject> enemyPre=new List<GameObject>();
    private int MaxNum = 3;
    private float timer;

    private void Update()
    {
        timer+=Time.deltaTime;
        BornPoint();
    }
    void BornPoint()
    {
        if (timer > 2)
        {
            timer = 0;

            int currentEnemy = transform.childCount;
            if (currentEnemy < MaxNum)
            {
                Vector3 v = transform.position;
                v.x += Random.Range(-2, 2);

                int index = Random.Range(0, enemyPre.Count);
                GameObject ranEenmy = enemyPre[index];
                GameObject go = Instantiate(ranEenmy, v, transform.rotation);
                go.transform.SetParent(transform);
            }
        }
    }
}
