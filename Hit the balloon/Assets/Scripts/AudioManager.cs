using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //����
    public static AudioManager Instance;
    //���ֲ�����
    public AudioSource bgmPlayer;
    //��Ч������
    public AudioSource sePlayer;

    void Awake()
    {
        Instance = this;
        PlayBgm("xinzuo.mp3");
        bgmPlayer.loop = true;
        //bgmPlayer = gameObject.AddComponent<AudioSource>();
    }

    //��������
    public void PlayBgm(string path)
    {
        //�����ǰ����û�в���
        if (bgmPlayer.isPlaying == false)
        {
            //��Resources�ļ����ж�ȡһ����Ƶ�ļ�
            AudioClip clip = Resources.Load<AudioClip>(path);
            //���ò���������ƵƬ��
            bgmPlayer.clip = clip;
            //����
            bgmPlayer.Play();
        }
    }

    //ֹͣ����
    public void StopBgm()
    {
        //����������ڲ���
        if (bgmPlayer.isPlaying == true)
        {
            //ֹͣ
            bgmPlayer.Stop();
        }
    }

    //������Ч
    public void PlaySe(string path)
    {
        //��Resources�ļ����ж�ȡһ����Ƶ�ļ�
        AudioClip clip = Resources.Load<AudioClip>(path);
        //������Ч
        sePlayer.PlayOneShot(clip);
    }

}
