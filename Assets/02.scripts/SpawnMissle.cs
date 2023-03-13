using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SpawnMissle : MonoBehaviour
{
    public GameObject targetMark;
    GameObject target;

    public GameObject missleObj;
    GameObject missle;

    public AudioClip spawnBombSound;
    public AudioClip explodsionBombSound;
    public static AudioSource spawnMissleAudio;

    public static bool isClick;

    public LayerMask layermask;

    private void Start()
    {
        spawnMissleAudio = GetComponent<AudioSource>();
        layermask = 1 << LayerMask.NameToLayer("TERRAIN");
    }

    private void Update()
    {
        if (target != null && isClick == false && Input.GetMouseButtonDown(0))
        {
            isClick = true;
            SpawnMissleAttack();
            Destroy(target, 1.5f);
        }
    }

    public void SpawnTargetMark()
    {
        Time_manager.bombPoint--;
        StartCoroutine(coSpawnTargetMark());
    }
    IEnumerator coSpawnTargetMark()
    {
        isClick = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
        {
            target = (GameObject)Instantiate(targetMark, hit.point, targetMark.transform.rotation);
            while (!isClick)
            {
                Ray rayTarget = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitTarget;
                if (Physics.Raycast(rayTarget, out hitTarget, Mathf.Infinity, layermask))
                {
                    target.transform.position = hitTarget.point + Vector3.up * 0.2f;
                    yield return null;
                }
            }
        }

    }

    public void SpawnMissleAttack()
    {
        //Debug.Log("spawnmissleattack!");
        StartCoroutine(coSpawnMissleAttack());
    }

    IEnumerator coSpawnMissleAttack()
    {
        //hit.transform.GetComponent<EnemyCtrl>().GetDamage(damage);
        if (isClick)
        {
            spawnMissleAudio.PlayOneShot(spawnBombSound, 1.0f);
            missle = (GameObject)Instantiate(missleObj, target.transform.position + Vector3.up * 30f,
                                                        missleObj.transform.rotation);
        }
        yield return null;
    }
}
