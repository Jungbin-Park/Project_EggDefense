using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{

    public float moveSpeed = 20f;
    Vector3 dirx;
    Animator anim;

    public int initHp = 100;
    private int currHp;

    void Start()
    {
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

    public void GetDamage()
    {
        if (currHp > 0)
        {
            currHp -= 5;
            Debug.Log("HP : " + currHp);
            StartCoroutine(damageAnim());
        }


        if (currHp == 0)
        {
            StartCoroutine(dieAnim());
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
