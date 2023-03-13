using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{         
    public void OnClickStart(string str)
    {
        Time_manager.Round = 1;
        Time_manager.stat = 0;
        Time_manager.LimitTime = 120f;

        SpawnMonster.MonsterNum = 0;
        SpawnMonster.BossNum = 0;
        SpawnMonster.i = 0;
        SpawnMonster.isSpawnMonster = true;
        SpawnMonster.isran = true;

        Time_manager.isGame = true;
        Time_manager.isResult = null;

        Debug.Log("Going Start");
        SceneManager.LoadScene("TEST_INGAME");

    }
    //           
    public void OnClickHelp(string str)
    {

        Debug.Log("Going HELP");
        SceneManager.LoadScene("HELP");
    }
    //        
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    // ڷΰ   
    public void OnClickBack(string str)
    {

        Debug.Log("GoHome");
        SceneManager.LoadScene("TITEL");
    }


}