using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCtrl : MonoBehaviour
{

    public float moveSpeed = 20f;
    Vector3 dirx;
    Animator anim;

    public float currHp;
    public float initHp;

    public GameObject hpBarPrefab;
    public Vector3 hpBarOffset = new Vector3(0f, 10f, 0f);
    GameObject hpBar;

    private Canvas uiCanvas;
    private Image hpBarImage;

    private GameObject fireEffect;

    public AudioClip hitSound;
    public AudioClip dieSound;
    private new AudioSource audio;

    void Start()
    {
        dirx = Vector3.forward;
        anim = GetComponent<Animator>();
        SetHpBar();

        audio = GetComponent<AudioSource>();
        fireEffect = Resources.Load<GameObject>("HitEffect");
    }

    void Update()
    {
        if (Time_manager.LimitTime <= 0f && GameObject.FindGameObjectWithTag("MONSTER"))
        {
            Destroy(GameObject.FindGameObjectWithTag("MONSTER"));
            Destroy(hpBar);
        }

        if (currHp > 0)
        {
            StartCoroutine(monsterMove());
        }
    }

    void SetHpBar()
    {
        uiCanvas = GameObject.Find("UI Canvas").GetComponent<Canvas>();
        hpBar = Instantiate<GameObject>(hpBarPrefab, uiCanvas.transform);
        hpBarImage = hpBar.GetComponentsInChildren<Image>()[1];

        var _hpBar = hpBar.GetComponent<EnemyHpBar>();
        _hpBar.targetTr = this.gameObject.transform;
        _hpBar.offset = hpBarOffset;
    }

    public void GetDamage(float towerDmg)
    {
        if (currHp > 0)
        {
            if (initHp == SpawnMonster.nmhp)
            {
                currHp -= towerDmg;
                hpBarImage.fillAmount = currHp / SpawnMonster.nmhp;
            }
            else if (initHp == SpawnMonster.hmhp)
            {
                currHp -= towerDmg;
                //Debug.Log("currHp : " + currHp);
                hpBarImage.fillAmount = currHp / SpawnMonster.hmhp;
            }
            else if (initHp == SpawnMonster.bmhp)
            {
                currHp -= towerDmg;
                hpBarImage.fillAmount = currHp / SpawnMonster.bmhp;
            }
            //Debug.Log("currHp : " + currHp);                                    
            StartCoroutine(damageAnim());
            ShowFireEffect(this.transform.position + (new Vector3(0, 4)), this.transform.rotation);
            audio.PlayOneShot(hitSound, 0.2f);
        }
    }

    IEnumerator damageAnim()
    {
        RunDamage_moveAnimation(2);
        yield return new WaitForSeconds(0.5f);
        if (currHp <= 0)
        {
            RunDamage_moveAnimation(3);
            //hpBarImage.GetComponentsInParent<Image>()[1].color = Color.clear;
        }
        else
        {
            RunDamage_moveAnimation(1);
        }
    }

    void ShowFireEffect(Vector3 pos, Quaternion rot)
    {
        GameObject fire = Instantiate<GameObject>(fireEffect, pos, rot);
        Destroy(fire, 1f);
    }

    IEnumerator monsterMove()
    {
        yield return null;
        if (transform.position.x <= 35 && transform.position.z >= 25)  //        ̵ 
        {
            this.transform.Translate(dirx * moveSpeed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        yield return null;
        if (transform.position.x >= 35 && transform.position.z >= -25) //  Ʒ    ̵ 
        {
            this.transform.Translate(dirx * moveSpeed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        yield return null;
        if (transform.position.x >= -35 && transform.position.z <= -25)  //      ̵ 
        {
            this.transform.Translate(dirx * moveSpeed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(0f, 270f, 0f);
        }
        yield return null;
        if (transform.position.x <= -35 && transform.position.z <= 25)  //      ̵ 
        {
            this.transform.Translate(dirx * moveSpeed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(0f, 360f, 0f);
        }
        yield return null;
    }

    private void RunDamage_moveAnimation(int aniStep)
    {
        switch (aniStep)
        {
            case 1:
                doMove();
                //Debug.Log("Animation - Move");
                break;
            case 2:
                doDamage();
                //Debug.Log("Animation - Damage");
                break;
            case 3:
                doDie();
                //Debug.Log("Animation - Die");
                break;
        }
    }

    void doMove()
    {
        StartCoroutine(coMove());
    }

    IEnumerator coMove()
    {
        anim.SetInteger("aniStep", 1);
        yield return null;
    }

    void doDamage()
    {
        StartCoroutine(coDamage());
    }

    IEnumerator coDamage()
    {
        anim.SetInteger("aniStep", 2);
        yield return new WaitForSeconds(0.5f);
    }

    void doDie()
    {
        audio.PlayOneShot(dieSound, 0.3f);
        StartCoroutine(coDie());
    }

    IEnumerator coDie()
    {
        anim.SetInteger("aniStep", 3);
        yield return null;
        Destroy(this.gameObject, 0.7f);
        Destroy(hpBar);
    }
}