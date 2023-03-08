using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Up_Manager : MonoBehaviour
{
    public float[] Fier = {1,2,3,4,5,6,7,8,9,10};    //파이어타워에 랜덤한 수를 줄 값
    public float Ice = 4;                            //아이스타워에 랜덤한 수를 줄 값
    public float[] Lig= {3,4,5,6,7};                 //라이트닝타워에 랜덤한 수를 줄 값

      float FierHiroAttatc = 5;          //불타워 공격력
      float IceHiroAttatc = 5;           //얼음타워 공격력
      float LigHiroAttatc = 5;           //번개타워 공격력

    //스탯부분 추가해야함
   

    void Start()
    {
        
        
    }

    void Update()
    {
        
    }
    public void OnClickFier(int i)
    {
        
        Fier[i] = Random.Range(0,9);                                    //Fier배열값에서 랜덤으로 호출
         
         GameObject fierhiro = GameObject.FindWithTag("FierHiro");      //태그 검색
         FierHiroAttatc += Fier[i];                                     //찾은 태그의 공격력(필드값) + 배열의 값
        
        Debug.Log($"fier Up = {FierHiroAttatc}");                       //공격력 증가되는지 확인



    }
    public void OnClickIce()
    {

         GameObject Icehiro = GameObject.FindWithTag("IceHiro");      //태그 검색
         IceHiroAttatc += Ice;                                        //찾은 태그의 공격력(필드값) + 인트의 값

        Debug.Log($"ice up = {IceHiroAttatc}");                       //공격력 증가되는지 확인
    }
    public void OnClickLig(int i)
    {
         Lig[i] = Random.Range(0, 4);                                    //Lig배열값에서 랜덤으로 호출

         GameObject Lighiro = GameObject.FindWithTag("LigHiro");      //태그 검색
         LigHiroAttatc += Lig[i];                                     //찾은 태그의 공격력(필드값) + 배열의 값

        Debug.Log($"lig up = {LigHiroAttatc}");                       //공격력 증가되는지 확인
    }


}
