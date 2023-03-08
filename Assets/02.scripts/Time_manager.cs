using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Time_manager : MonoBehaviour
{
    public float LimitTime = 120f;   //���ӽð�
    public TextMeshProUGUI text_timer;        

    public static int Round = 1;
    public TextMeshProUGUI text_Round;

    public static bool isGame = true;

    void Start()
    {
        if (isGame)
        {
            LimitTimer();
        }        
    }
    void LimitTimer()
    {
        while (true)
        {
            //Ÿ�̸� ����
            if (LimitTime >= 0f)                               //���� Ÿ���� ������ Ŭ��
            {
                LimitTime -= Time.deltaTime;                   //����Ÿ�ӿ��� ����ð��� ���ְ�
                text_timer.text = "" + Mathf.Round(LimitTime); //���ӽð� �� �����ڸ��������� ����ƮŸ�ӱ���  ����

                if (SpawnMonster.MonsterCount == SpawnMonster.MaxMonsterNum && GameObject.FindGameObjectsWithTag("MONSTER") == null)
                {
                    LimitTime = 120f;
                    if (Round != SpawnMonster.MaxRound)
                        Round++;
                    text_Round.text = "" + Round;
                    SpawnMonster.MonsterCount = 0;
                }
                else if (SpawnMonster.BossNum == SpawnMonster.MaxBMonsterNum && GameObject.FindGameObjectsWithTag("MONSTER") == null)
                {
                    //Victory
                    isGame = false;
                }
            }
            else if (LimitTime <= 0f && GameObject.FindGameObjectsWithTag("MONSTER") != null)
            {
                //GameOver
                isGame = false;
            }
        }
    }
}
