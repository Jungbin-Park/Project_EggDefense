using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    //게임으로 진입
    public void OnClickStart(string str)
    {
        Debug.Log("Going Start");
        SceneManager.LoadScene("TEST_INGAME");
    }
    //헬프로 진입
    public void OnClickHelp(string str)
    {
        Debug.Log("Going HELP");
        SceneManager.LoadScene("HELP");
    }
    //게임종료
    public void Exit()
    {
        Debug.Log("종료");
        Application.Quit();
    }
    //뒤로가기
    public void OnClickBack(string str)
    {
        Debug.Log("뒤로가기");
        SceneManager.LoadScene("TITEL");
    }


}
