using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(changescene());
    }

    IEnumerator changescene()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            switch (Time_manager.isResult)
            {
                case "VICTORY":
                    SceneManager.LoadScene("VICTORY");
                    break;
                case "GAMEOVER":
                    SceneManager.LoadScene("GAMEOVER");
                    break;
            }
        }

    }
}