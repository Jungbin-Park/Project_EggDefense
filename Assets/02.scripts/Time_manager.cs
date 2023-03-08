using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Time_manager : MonoBehaviour
{
    public float LimitTime;   //게임시간
    public TextMeshProUGUI text_timer;        //게임 시간 (40)초 예정

    public int round;
    public TextMeshProUGUI text_Round;

    public float stat;
    public TextMeshProUGUI text_stat;

    bool isRun = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //타이머 관련
        if (LimitTime >= 0f)                               //리밋 타임이 영보다 클때
        {
            LimitTime -= Time.deltaTime;                   //리밋타임에서 현재시간을 빼주고
            text_timer.text = "" + Mathf.Round(LimitTime); //게임시간 은 정수자리수까지의 리미트타임까지  노출 
        }

        //라운드 관련
        if ((int)LimitTime == 0f)                           //리미트 타임의 시간이 0일때
        {
            LimitTime = 5f;                                 //리미트 타임의 시간을 반복시킴
            isRun = true;                                   //이즈런을 참으로 변환

            if (isRun)                                      //이즈런이 참일때
            {
                if (round <= 6)                               //라운드가 5보다 작을때
                {
                    round++;                                //라운드를 증가시켜라
                    Debug.Log(round);
              
                
                }
           
                isRun = false;                              //이즈런 불로 변환
            }

            if (round >= 6 )
            {
                LimitTime = 0;
            }

                text_Round.text = " " + round + " ";

            if (round >= 6) 
            {
                text_Round.text = "5";
             }

        }

    }
}
