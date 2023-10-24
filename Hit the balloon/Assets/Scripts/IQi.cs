using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IQi : MonoBehaviour
{
    public int attack = 20;
    public PlayerControl player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
           player.GetDamage(attack);
        }
    }
}
