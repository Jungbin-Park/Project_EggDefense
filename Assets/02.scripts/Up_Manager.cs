using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Up_Manager : MonoBehaviour
{
    Button fireBtn;
    Button iceBtn;
    Button elecBtn;
    Button bombBtn;

    GameObject canvas;

    public Object FireUp;               //파이어 업그레이드 이펙트
    public Object IceUp;                //아이스 업그레이드 이펙트
    public Object ElecUp;                //라이트닝 업그레이드 이펙트

    public AudioClip fireUpSound;
    public AudioClip iceUpSound;
    public AudioClip elecUpSound;
    private AudioSource upAudio;


    int fire;
    int ice;
    int elec;


    //스탯부분 추가해야함

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        fireBtn = canvas.GetComponentsInChildren<Button>()[1];
        iceBtn = canvas.GetComponentsInChildren<Button>()[2];
        elecBtn = canvas.GetComponentsInChildren<Button>()[3];
        bombBtn = canvas.GetComponentsInChildren<Button>()[4];
        upAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Time_manager.stat <= 0)
        {
            fireBtn.interactable = false;
            iceBtn.interactable = false;
            elecBtn.interactable = false;
        }
        else
        {
            fireBtn.interactable = true;
            iceBtn.interactable = true;
            elecBtn.interactable = true;
        }

        if (Time_manager.bombPoint <= 0)
            bombBtn.interactable = false;
        else
            bombBtn.interactable = true;
    }
    public void OnClickFire()
    {
        upAudio.PlayOneShot(fireUpSound, 1.0f);
        StartCoroutine(coFire());
    }
    IEnumerator coFire()
    {
        Time_manager.stat--;
        fire = Random.Range(1, 11);
        TowerCtrl.damage += fire;
        GameObject[] firehero = GameObject.FindGameObjectsWithTag("TOWER");
        Debug.Log(TowerCtrl.damage);
        foreach (var fhero in firehero)                                  
        {
            GameObject fiereff = (GameObject)Instantiate(FireUp,
                                 fhero.transform.position + Vector3.up, fhero.transform.rotation);
            Destroy(fiereff, 2f);
            yield return null;
        }
        Debug.Log(TowerCtrl.damage);
    }


    public void OnClickIce()
    {
        upAudio.PlayOneShot(iceUpSound, 1.0f);
        StartCoroutine(coIce());
    }
    IEnumerator coIce()
    {
        Time_manager.stat--;
        ice = 4;
        TowerCtrl.damage += ice;
        GameObject[] icehero = GameObject.FindGameObjectsWithTag("TOWER");
        Debug.Log(TowerCtrl.damage);
        foreach (var ihero in icehero)
        {
            GameObject iceeff = (GameObject)Instantiate(IceUp,
                                 ihero.transform.position, ihero.transform.rotation);
            Destroy(iceeff, 2f);
            yield return null;
        }
        Debug.Log(TowerCtrl.damage);
    }


    public void OnClickElec()
    {
        upAudio.PlayOneShot(elecUpSound, 1.0f);
        StartCoroutine(coElec());
    }
    IEnumerator coElec()
    {
        Time_manager.stat--;
        elec = Random.Range(3, 7);
        TowerCtrl.damage += elec;
        GameObject[] elechero = GameObject.FindGameObjectsWithTag("TOWER");
        Debug.Log(TowerCtrl.damage);
        foreach (var ehero in elechero)
        {
            GameObject eleceff = (GameObject)Instantiate(ElecUp,
                                 ehero.transform.position, ehero.transform.rotation);
            Destroy(eleceff, 2f);
            yield return null;
        }
        Debug.Log(TowerCtrl.damage);
    }


}