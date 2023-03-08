using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Time_manager : MonoBehaviour
{
    public float LimitTime = 120f;   //게임시간
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
            //타이머 관련
            if (LimitTime >= 0f)                               //리밋 타임이 영보다 클때
            {
                LimitTime -= Time.deltaTime;                   //리밋타임에서 현재시간을 빼주고
                text_timer.text = "" + Mathf.Round(LimitTime); //게임시간 은 정수자리수까지의 리미트타임까지  노출

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
