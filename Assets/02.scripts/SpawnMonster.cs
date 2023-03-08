using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    // ���� ����
    List<GameObject> nm = new List<GameObject>();
    List<GameObject> hm = new List<GameObject>();
    List<GameObject> bm = new List<GameObject>();
    public int Round = Time_manager.Round;
    public static int MaxRound = 5;
    public Object[] MonsterObj;
    Object monsterObj;

    public float spawnTime = 2f;
    public float intervalCheckMonsterNum = 1f;    
    public static int MonsterCount = 0;
    public static int MaxMonsterNum = 20;
    public static int BossNum = 0;
    public static int MaxBMonsterNum = 1;
    bool isSpawnMonster = true;

    void Start()
    {
        if (Time_manager.isGame)
        {
            MObj();
            StartCoroutine(coSpawnMonster());
            StartCoroutine(coCheckMonsterNum());
        }
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
            if (Round != MaxRound && (Round % 2) != 0)
            {
                yield return new WaitForSeconds(spawnTime);
                if (isSpawnMonster)
                {
                    Vector3 pos = transform.position;
                    if (MonsterCount <= MaxMonsterNum)
                    {
                        Object monsterObj = nm[Random.Range(0, nm.Count)];
                        GameObject Monster = (GameObject)Instantiate(monsterObj, pos, Quaternion.identity);
                        Monster.tag = "MONSTER";

                    }
                    MonsterCount++;
                }
            }
            else if (Round != MaxRound && (Round % 2) == 0)
            {
                yield return new WaitForSeconds(spawnTime);
                if (isSpawnMonster)
                {
                    Vector3 pos = transform.position;
                    if (MonsterCount <= MaxMonsterNum)
                    {
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
                        MonsterCount++;
                    }
                }
            }



            else if (Round == MaxRound)
            {
                yield return new WaitForSeconds(spawnTime);
                if (isSpawnMonster)
                {
                    if (BossNum <= MaxBMonsterNum)
                    {
                        Vector3 pos = transform.position;
                        Object monsterObj = bm[Random.Range(0, bm.Count)];
                        GameObject Monster = (GameObject)Instantiate(monsterObj, pos, Quaternion.identity);
                        Monster.tag = "MONSTER";
                    }
                    BossNum++;
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
            while (true)
            {
                yield return new WaitForSeconds(intervalCheckMonsterNum);
                if (BossNum == MaxBMonsterNum)
                    isSpawnMonster = false;
            }
        }

    }
}
