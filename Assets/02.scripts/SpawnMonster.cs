using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    // ���� ����
    List<GameObject> nm = new List<GameObject>();
    List<GameObject> hm = new List<GameObject>();
    List<GameObject> bm = new List<GameObject>();

    
    public Object[] MonsterObj;
    Object monsterObj;

    public float spawnTime = 2f;
    public float intervalCheckMonsterNum = 1f;
    public int MaxMonsterNum = 20;
    public int MonsterCount = 0;
    public int BossNum = 1;
    public int Round = 1;
    public int MaxRound = 5;
    public float accTime = 30f;
    bool isSpawnMonster = true;

    void Start()
    {
        MObj();
        StartCoroutine(coSpawnMonster());
        StartCoroutine(coCheckMonsterNum());
        StartCoroutine(coRoundNum());
    }

    void MObj()
    {

        foreach (GameObject a in MonsterObj)
        {
            if (a.CompareTag("NM"))
                nm.Add(a);
        }

        foreach (GameObject a in MonsterObj)
        {
            if (a.CompareTag("HM"))
                hm.Add(a);
        }

        foreach (GameObject a in MonsterObj)
        {
            if (a.CompareTag("BM"))
                bm.Add(a);
        }
    }
    IEnumerator coSpawnMonster()
    {
        while (true)
        {
            if (Round != MaxRound && (Round % 2) == 0)
            {
                yield return new WaitForSeconds(spawnTime);
                if (isSpawnMonster)
                {
                    Vector3 pos = transform.position;
                    MonsterCount++;
                    if (MonsterCount != 10 && MonsterCount != 20)
                    {
                        monsterObj = nm[Random.Range(0, nm.Count)];
                        GameObject Monster = (GameObject)Instantiate(monsterObj, pos, Quaternion.identity);
                        Monster.tag = "MONSTER";
                    }
                    else
                    {
                        monsterObj = hm[Random.Range(0, hm.Count)];
                        GameObject Monster = (GameObject)Instantiate(monsterObj, pos, Quaternion.identity);
                        Monster.tag = "MONSTER";
                    }
                }
            }

            else if (Round != MaxRound && (Round % 2) != 0)
            {
                yield return new WaitForSeconds(spawnTime);
                if (isSpawnMonster)
                {
                    Vector3 pos = transform.position;
                    MonsterCount++;
                    Object monsterObj = nm[Random.Range(0, nm.Count)];
                    GameObject Monster = (GameObject)Instantiate(monsterObj, pos, Quaternion.identity);
                    Monster.tag = "MONSTER";
                }
            }

            else if (Round == MaxRound)
            {
                yield return new WaitForSeconds(spawnTime);
                if (isSpawnMonster)
                {
                    Vector3 pos = transform.position;
                    Object monsterObj = bm[Random.Range(0, bm.Count)];
                    GameObject Monster = (GameObject)Instantiate(monsterObj, pos, Quaternion.identity);
                    Monster.tag = "MONSTER";
                }
            }
        }
    }
    IEnumerator coCheckMonsterNum()
    {
        if (Round != MaxRound)
        {
            while (true)
            {
                yield return new WaitForSeconds(intervalCheckMonsterNum);
                if (MonsterCount == MaxMonsterNum)
                {
                    isSpawnMonster = false;
                }
            }
        }
        else if (Round == MaxRound)
        {
            isSpawnMonster = false;
        }

    }

    IEnumerator coRoundNum()
    {
        if (MonsterCount == 0 && accTime == 0f)
            Round++;
        isSpawnMonster = true;
        yield return null;
    }
}
