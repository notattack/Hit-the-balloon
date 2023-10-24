using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Events;

public class Text : MonoBehaviour
{
    public static Text instance;
    public GameObject tMP;
    public TMP_Text scoreText;
    public int myScore=0;
    //public Transform over;
    public PlayerControl player;


    private void Awake()
    {
        instance = this;
        EventCenter.Add("GameOverEvent", GameOverShow);
    }

    private void Start()
    {
        //player = GetComponent<PlayerControl>();
        //over = GameObject.FindWithTag("Over").transform;
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
        tMP.SetActive(false);
    }

    public void GameOverShow()
    {
        tMP.SetActive(true);
    }
    public void AddScore()
    {
        myScore++;
        scoreText.text = "Score X "+myScore.ToString();
    }
    //private void Update()
    //{
       
    //    if (player.isTime==true)
    //    {
    //        tMP.SetActive(true);
    //        //Instantiate(tMP,over.position,over.rotation);
    //    }
    //}


    
}
