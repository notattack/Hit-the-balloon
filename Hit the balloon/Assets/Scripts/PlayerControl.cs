using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D R2D;
    public Slider PlayerBar;
    //private int MaxHp = 80;
    public int Hp = 80;
    public float speed = 2f;
    private float timer = 0;
    //允许跳跃判断
    public bool isTime = false;
    void Start()
    {
        R2D = GetComponent<Rigidbody2D>();
        PlayerBar=GameObject.FindWithTag("PlayerBar").GetComponent<Slider>();
        PlayerBar.value = 1;
    }
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer > 0.2f)
        {
            isTime = true;
            timer = 0;
        }
        Move();
       
        Die(); 
        //Bar();
    }
    private void FixedUpdate()
    {
        Ups();
    }
    void Ups()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isTime==true)
        {
            R2D.AddForce(Vector2.up * 250f);
            isTime = false;
        }
    }
    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0)
        {
            //移动
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //翻转
            GetComponent<SpriteRenderer>().flipX = horizontal > 0 ? false : true;
        }
        else if (horizontal < 0)
        {
            //移动
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            //翻转
            GetComponent<SpriteRenderer>().flipX = horizontal > 0 ? false : true;
        }
    }
    public void GetDamage(int Damage)
    {
        Hp-=Damage;
        PlayerBar.value -= 0.25f;
    }
    /*弃用的
     * void Bar()
    {
        PlayerBar.value = (float)(Hp / MaxHp);
    }
    */
    void Die()
    {
        if (Hp <= 0)
        {
            EventCenter.Send("GameOverEvent");
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "River")
        {
            // isTime = true;  
                EventCenter.Send("GameOverEvent");
                Time.timeScale = 0;
        }
    }
}
