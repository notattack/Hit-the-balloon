using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQi : MonoBehaviour
{
    public int attack = 20;
    //public EnemyControl enemy;
    
    private void Start()
    {
        //enemy=GameObject.FindWithTag("Enemy").GetComponent<EnemyControl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.transform.parent.gameObject.GetComponent<EnemyControl>().GetDamage(attack);
        }
    }
}
