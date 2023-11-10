using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    private Rigidbody2D R2D;
    private Slider EnemyBar;
    private Transform player;
    //private int MaxHp = 40;
    public int Hp = 40;
    public int ran;
    public float speed = 5f;
    private float timer;
    private float allTimer;
    private void Start()
    {
        R2D = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        //EnemyBar=GameObject.FindWithTag("EnemyBar").GetComponent<Slider>();

        EnemyBar = this.transform.GetChild(1).GetChild(0).GetComponent<Slider>();
        EnemyBar.value = 1;
    }
    private void Update()
    {
        Bian();
        Rand();
        Die();
        //Bar();
        AddSpeed();
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
    public void GetDamage(int Damage)
    {
        Hp -= Damage;
        EnemyBar.value -= 0.5f;
    }

    /*ÆúÓÃµÄ
     * void Bar()
    {
        EnemyBar.value = (float)(Hp / MaxHp);
    }
    */
    void Die()
    {
        if (Hp <= 0)
        {
            AudioManager.Instance.PlaySe("die.mp3");
            Destroy(gameObject);
            Text.instance.AddScore();
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
            R2D.AddForce(Vector2.up * 5f);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    void AddSpeed()
    {
        allTimer += Time.deltaTime;
        if (allTimer > 30f)
        {
            speed *= 2;
        }
        if (allTimer > 60f)
        {
            speed *= 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "River")
        {
            Destroy(gameObject);
        }
    }
}
