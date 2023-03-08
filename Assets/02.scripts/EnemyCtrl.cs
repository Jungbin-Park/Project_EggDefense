using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCtrl : MonoBehaviour
{

    public float moveSpeed = 20f;
    Vector3 dirx;
    Animator anim;

    public float initHp = 100f;
    private float currHp;

    public GameObject hpBarPrefab;
    public Vector3 hpBarOffset = new Vector3(0f, 10f, 0f);

    private Canvas uiCanvas;
    private Image hpBarImage;

    void Start()
    {
        dirx = Vector3.forward;
        anim = GetComponent<Animator>();
        currHp = initHp;
        SetHpBar();

        if (Time_manager.isGame)
        {
            dirx = Vector3.forward;
            anim = GetComponent<Animator>();
            currHp = initHp;
        }
    }

    void Update()
    {
        if (Time_manager.isGame)
        {
            StartCoroutine(monsterMove());
        }            
    }

    void SetHpBar()
    {
        uiCanvas = GameObject.Find("UI Canvas").GetComponent<Canvas>();
        GameObject hpBar = Instantiate<GameObject>(hpBarPrefab, uiCanvas.transform);
        hpBarImage = hpBar.GetComponentsInChildren<Image>()[1];

        var _hpBar = hpBar.GetComponent<EnemyHpBar>();
        _hpBar.targetTr = this.gameObject.transform;
        _hpBar.offset = hpBarOffset;
    }

    public void GetDamage()
    {
        if (currHp > 0)
        {
            currHp -= 1;
            hpBarImage.fillAmount = currHp / initHp;
            Debug.Log("HP : " + currHp);
            StartCoroutine(damageAnim());
        }


        if (currHp <= 0)
        {
            StartCoroutine(dieAnim());
            hpBarImage.GetComponentsInParent<Image>()[1].color = Color.clear;
        }
    }

    IEnumerator damageAnim()
    {
        RunDamage_moveAnimation(2);
        yield return new WaitForSeconds(1.0f);
        RunDamage_moveAnimation(1);
    }

    IEnumerator dieAnim()
    {
        RunDamage_moveAnimation(3);
        yield return null;
    }

    IEnumerator monsterMove()
    {
        yield return null;
        if (transform.position.x <= 35 && transform.position.z >= 25)  // �������̵�
        {
            this.transform.Translate(dirx * moveSpeed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        yield return null;
        if (transform.position.x >= 35 && transform.position.z >= -25) // �Ʒ����̵�
        {
            this.transform.Translate(dirx * moveSpeed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        yield return null;
        if (transform.position.x >= -35 && transform.position.z <= -25)  // �����̵�
        {
            this.transform.Translate(dirx * moveSpeed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(0f, 270f, 0f);
        }
        yield return null;
        if (transform.position.x <= -35 && transform.position.z <= 25)  // �����̵�
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
                Debug.Log("Animation - Move");
                break;
            case 2:
                doDamage();
                Debug.Log("Animation - Damage");
                break;
            case 3:
                doDie();
                Debug.Log("Animation - Die");
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
        yield return new WaitForSeconds(1f);
    }

    void doDie()
    {
        StartCoroutine(coDie());
    }

    IEnumerator coDie()
    {
        anim.SetInteger("aniStep", 3);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);

    }
}
