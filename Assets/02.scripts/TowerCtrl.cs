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
    private Transform enemyTr;
    private Transform towerTr;
    private Transform target;

    public float attackDist = 30f;
    public float lineSize = 30f;
    public Object particle;

    RaycastHit hit;

    void Start()
    {
        //enemyTr = GameObject.FindGameObjectWithTag("MONSTER").GetComponent<Transform>();
        GameObject[] arrEnemy = GameObject.FindGameObjectsWithTag("MONSTER");
        towerTr = GetComponent<Transform>();
        anim.GetComponent<Animator>();
    }

    void Update()
    {
        StartCoroutine(UpdateTarget());
    }

    // 가장 가까운 적 감지
    IEnumerator UpdateTarget()
    {
        GameObject[] arrEnemy = GameObject.FindGameObjectsWithTag("MONSTER");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in arrEnemy)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= attackDist)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

        if(nearestEnemy != null)
        {
            towerTr.LookAt(target);
            Debug.DrawRay(transform.position, transform.forward * lineSize, Color.green);

            // 가장 광선과 가까운 1개의 오브젝트만 감지한다.
            // 물체에 닿으면 true를 반환
            if (Physics.Raycast(transform.position, transform.forward, out hit, lineSize))
            {
                if (hit.collider.tag.Equals("MONSTER"))
                {
                    doShot();
                }
            }
        }
<<<<<<< Updated upstream
=======
        else
        {
            state = State.IDLE;
        }
        if (arrEnemy == null)
        {
            isGame = false;
        }
>>>>>>> Stashed changes
        yield return null;
    }

    private void doShot()
    {
        StartCoroutine(coShot());
    }

    IEnumerator coShot()
    {
        yield return new WaitForSeconds(1.0f);
        // 닿은 물체의 이름을 출력
        //Debug.Log(hit.collider.gameObject.name);
        hit.transform.GetComponent<EnemyCtrl>()?.OnDamage(hit.point, hit.normal);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackDist);
    }
}
