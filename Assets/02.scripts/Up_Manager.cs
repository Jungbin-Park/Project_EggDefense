using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Up_Manager : MonoBehaviour
{
    public float[] Fier = {1,2,3,4,5,6,7,8,9,10};    //���̾�Ÿ���� ������ ���� �� ��
    public float Ice = 4;                            //���̽�Ÿ���� ������ ���� �� ��
    public float[] Lig= {3,4,5,6,7};                 //����Ʈ��Ÿ���� ������ ���� �� ��

      float FierHiroAttatc = 5;          //��Ÿ�� ���ݷ�
      float IceHiroAttatc = 5;           //����Ÿ�� ���ݷ�
      float LigHiroAttatc = 5;           //����Ÿ�� ���ݷ�

    //���Ⱥκ� �߰��ؾ���
   

    void Start()
    {
        
        
    }

    void Update()
    {
        
    }
    public void OnClickFier(int i)
    {
        
        Fier[i] = Random.Range(0,9);                                    //Fier�迭������ �������� ȣ��
         
         GameObject fierhiro = GameObject.FindWithTag("FierHiro");      //�±� �˻�
         FierHiroAttatc += Fier[i];                                     //ã�� �±��� ���ݷ�(�ʵ尪) + �迭�� ��
        
        Debug.Log($"fier Up = {FierHiroAttatc}");                       //���ݷ� �����Ǵ��� Ȯ��



    }
    public void OnClickIce()
    {

         GameObject Icehiro = GameObject.FindWithTag("IceHiro");      //�±� �˻�
         IceHiroAttatc += Ice;                                        //ã�� �±��� ���ݷ�(�ʵ尪) + ��Ʈ�� ��

        Debug.Log($"ice up = {IceHiroAttatc}");                       //���ݷ� �����Ǵ��� Ȯ��
    }
    public void OnClickLig(int i)
    {
         Lig[i] = Random.Range(0, 4);                                    //Lig�迭������ �������� ȣ��

         GameObject Lighiro = GameObject.FindWithTag("LigHiro");      //�±� �˻�
         LigHiroAttatc += Lig[i];                                     //ã�� �±��� ���ݷ�(�ʵ尪) + �迭�� ��

        Debug.Log($"lig up = {LigHiroAttatc}");                       //���ݷ� �����Ǵ��� Ȯ��
    }


}
