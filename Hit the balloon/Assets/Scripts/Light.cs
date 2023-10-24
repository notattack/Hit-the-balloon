using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public float speed = 2f;
    public int ran;
    private float timer;
    private void Start()
    {
        
    }
    private void Update()
    {
        Bian();
        Rand();
    }
    void Bian()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            ran = Random.Range(0, 10);
            timer = 0;
        }
    }
    void Rand()
    {
        if (ran < 1)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else if (ran >= 1 && ran < 3)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (ran >= 3 && ran < 6)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * 3*speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Player")
        {
            EventCenter.Send("GameOverEvent");
            Time.timeScale = 0;
        }
    }
}
