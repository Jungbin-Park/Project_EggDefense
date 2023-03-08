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
    //�������� ����
    public void OnClickStart(string str)
    {
        Debug.Log("Going Start");
        SceneManager.LoadScene("TEST_INGAME");
    }
    //������ ����
    public void OnClickHelp(string str)
    {
        Debug.Log("Going HELP");
        SceneManager.LoadScene("HELP");
    }
    //��������
    public void Exit()
    {
        Debug.Log("����");
        Application.Quit();
    }
    //�ڷΰ���
    public void OnClickBack(string str)
    {
        Debug.Log("�ڷΰ���");
        SceneManager.LoadScene("TITEL");
    }


}
