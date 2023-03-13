using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Time_manager : MonoBehaviour
{
    public static float LimitTime = 120f;   //게임시간
    public TextMeshProUGUI text_timer;        //게임 시간 (40)초 예정

    public static int Round = 1;
    public TextMeshProUGUI text_Round;

    public static int stat = 0;
    public TextMeshProUGUI text_stat;

    public static int bombPoint = 0;
    public TextMeshProUGUI text_bomb;

    public static bool isGame = true;

    public static string isResult;

    private void Update()
    {
        LimitTimer();
    }
    void LimitTimer()
    {
        //타이머 관련
        if (isGame)
        {
            if (LimitTime >= 0f)                               //리밋 타임이 영보다 클때
            {
                LimitTime -= Time.deltaTime;                   //리밋타임에서 현재시간을 빼주고
                text_timer.text = "" + Mathf.Round(LimitTime); //게임시간 은 정수자리수까지의 리미트타임까지  노출
                text_stat.text = "" + stat;
                text_Round.text = "" + Round;
                text_bomb.text = "" + bombPoint;
                if (SpawnMonster.MonsterNum == SpawnMonster.MaxMonsterNum && GameObject.FindGameObjectWithTag("MONSTER") == null)
                {
                    //Debug.Log("Round Clear!");
                    LimitTime = 120f;
                    text_timer.text = "" + Mathf.Round(LimitTime);
                    Round++;
                    stat++;
                    SpawnMonster.MonsterNum = 0;
                    SpawnMonster.i = 0;
                    SpawnMonster.isSpawnMonster = true;
                    SpawnMonster.isran = true;
                    SpawnMonster.BossNum = 0;
                    //Debug.Log("(TM)monstercount : " + SpawnMonster.MonsterCount);                    
                }
                else if (SpawnMonster.BossNum == SpawnMonster.MaxBMonsterNum && GameObject.FindGameObjectWithTag("MONSTER") == null)
                {
                    //Victory
                    isResult = "VICTORY";
                    isGame = false;
                }
            }
            else if (LimitTime <= 0f && GameObject.FindGameObjectWithTag("MONSTER") != null)
            {
                isResult = "GAMEOVER";
                //GameOver
                isGame = false;
            }
        }

    }
}