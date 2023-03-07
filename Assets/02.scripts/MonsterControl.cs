using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    Animator anim;
    public delegate void MoveAnimation(int aniStep);
    public event MoveAnimation moveAnimation = null;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        moveAnimation += MonsterControl_moveAnimation;
    }

    private void MonsterControl_moveAnimation(int aniStep)
    {
        switch (aniStep)
        {
            case 1:
                doMove();
                break;
            case 2:
                doDamage();
                break;
            case 3:
                doDie();
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
        yield return null;
    }

    void doDie()
    {
        StartCoroutine(coDie());
    }

    IEnumerator coDie()
    {
        anim.SetInteger("aniStep", 3);
        yield return null;
        Destroy(this.gameObject);

    }
}
