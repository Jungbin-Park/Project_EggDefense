using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Time_manager : MonoBehaviour
{
    public float LimitTime;   //���ӽð�
    public TextMeshProUGUI text_timer;        //���� �ð� (40)�� ����

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

        //Ÿ�̸� ����
        if (LimitTime >= 0f)                               //���� Ÿ���� ������ Ŭ��
        {
            LimitTime -= Time.deltaTime;                   //����Ÿ�ӿ��� ����ð��� ���ְ�
            text_timer.text = "" + Mathf.Round(LimitTime); //���ӽð� �� �����ڸ��������� ����ƮŸ�ӱ���  ���� 
        }

        //���� ����
        if ((int)LimitTime == 0f)                           //����Ʈ Ÿ���� �ð��� 0�϶�
        {
            LimitTime = 5f;                                 //����Ʈ Ÿ���� �ð��� �ݺ���Ŵ
            isRun = true;                                   //����� ������ ��ȯ

            if (isRun)                                      //����� ���϶�
            {
                if (round <= 6)                               //���尡 5���� ������
                {
                    round++;                                //���带 �������Ѷ�
                    Debug.Log(round);
              
                
                }
           
                isRun = false;                              //��� �ҷ� ��ȯ
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
