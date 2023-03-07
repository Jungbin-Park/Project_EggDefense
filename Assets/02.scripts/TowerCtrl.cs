using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerCtrl : MonoBehaviour
{
    public enum State
    {
        IDLE,
        ATTACK
    }

    public State state = State.IDLE;

    private Animator anim;
    private Transform towerTr;
    private Transform target;

    public float attackDist = 30f;
    public float lineSize = 30f;
    public bool isGame = true;
    public Object particle;

    RaycastHit hit;
    void Start()
    {
        towerTr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        StartCoroutine(UpdateTarget());
        StartCoroutine(stateAction());
    }
    // 가장 가까운 적 감지
    IEnumerator UpdateTarget()
    {
        // 감지된 몬스터 배열에 저장
        GameObject[] arrEnemy = GameObject.FindGameObjectsWithTag("MONSTER");
        // 최소거리 = 무한대
        float shortestDistance = Mathf.Infinity;
        // 가까운 적 게임오브젝트
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in arrEnemy)
        {
            // 적과 포탑의 거리
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        // 공격 사정거리 안에 있으면 타겟 설정
        if (nearestEnemy != null && shortestDistance <= attackDist)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

        if (target != null)
        {
            state = State.ATTACK;
            //anim.SetBool("isAttack", true);
            towerTr.LookAt(target);
            StartCoroutine(coFire());
            // 가장 광선과 가까운 1개의 오브젝트만 감지한다. 물체에 닿으면 true를 반환

        }
        else
        {
            state = State.IDLE;
        }

        if (arrEnemy == null)
        {
            isGame = false;
        }
        yield return null;
    }

    IEnumerator coFire()
    {
        yield return new WaitForSeconds(1.0f);
        // 닿은 물체의 이름을 출력
        //Debug.Log(hit.collider.gameObject.name);
        Debug.DrawRay(transform.position, transform.forward * lineSize, Color.green);
        if (Physics.Raycast(transform.position, transform.forward, out hit, lineSize))
        {
            if (hit.collider.tag.Equals("MONSTER"))
            {
                hit.transform.GetComponent<EnemyCtrl>().GetDamage();
            }
        }
    }

    IEnumerator stateAction()
    {
        switch (state)
        {
            case State.IDLE:
                anim.SetBool("isAttack", false);
                break;
            case State.ATTACK:
                Debug.Log("isAttack True!");
                anim.SetBool("isAttack", true);
                break;
        }
        yield return null;
    }

    private void OnDrawGizmos()
    {
        if(state == State.IDLE)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, attackDist);
        }
        if(state == State.ATTACK)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDist);
        }
        
    }
}
