using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    //          
    List<GameObject> nm = new List<GameObject>();
    List<GameObject> hm = new List<GameObject>();
    List<GameObject> bm = new List<GameObject>();


    public Object[] MonsterObj;
    Object monsterObj;

    public float spawnTime = 1f;
    public float intervalCheckMonsterNum = 1f;

    public static int MonsterNum = 0;
    public static int MaxMonsterNum = 40;
    public static int BossNum = 0;
    public static int MaxBMonsterNum = 2;
    public int Round;
    public static int MaxRound = 10;
    public static int i = 1;
    public static bool isSpawnMonster = true;
    public static bool isran = true;
    public static int nmhp;
    public static int hmhp;
    public static int bmhp;

    private void Start()
    {
        MObj();
        StartCoroutine(coSpawnMonster());
        StartCoroutine(coCheckMonsterNum());
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
        while (Time_manager.isGame)
        {
            yield return new WaitForSeconds(spawnTime);
            Round = Time_manager.Round;
            hpmanage();
            if (Round == 1)
            {
                if (isSpawnMonster)
                {
                    Vector3 pos = transform.position;
                    if (i == 1)
                    {
                        monsterObj = hm[Random.Range(0, hm.Count)];
                        GameObject Hmonster = (GameObject)Instantiate(monsterObj, pos, Quaternion.identity);
                        Hmonster.GetComponent<EnemyCtrl>().currHp = Hmonster.GetComponent<EnemyCtrl>().initHp = hmhp;
                        Time_manager.bombPoint++;
                        Hmonster.tag = "MONSTER";
                        i++;
                        yield return new WaitForSeconds(spawnTime);
                    }

                    if (MonsterNum <= MaxMonsterNum)
                    {
                        monsterObj = nm[Random.Range(0, nm.Count)];
                        GameObject Nmonster = (GameObject)Instantiate(monsterObj, pos, Quaternion.identity);
                        Nmonster.GetComponent<EnemyCtrl>().currHp = Nmonster.GetComponent<EnemyCtrl>().initHp = nmhp;
                        Nmonster.tag = "MONSTER";
                        MonsterNum++;
                    }
                }
            }
            else if (Round <= 3)
            {
                if (isSpawnMonster)
                {
                    Vector3 pos = transform.position;
                    if (MonsterNum <= MaxMonsterNum)
                    {
                        monsterObj = nm[Random.Range(0, nm.Count)];
                        GameObject Nmonster = (GameObject)Instantiate(monsterObj, pos, Quaternion.identity);
                        Nmonster.GetComponent<EnemyCtrl>().currHp = Nmonster.GetComponent<EnemyCtrl>().initHp = nmhp;

                        Nmonster.tag = "MONSTER";
                        MonsterNum++;
                    }
                }
            }
            else if (Round <= 9)
            {
                if (isSpawnMonster)
                {
                    Vector3 pos = transform.position;
                    if (isran)
                    {
                        i = Random.Range(0, 2);
                        isran = false;
                    }

                    if (i == 1)
                    {
                        monsterObj = hm[Random.Range(0, hm.Count)];
                        GameObject Hmonster = (GameObject)Instantiate(monsterObj, pos, Quaternion.identity);
                        Time_manager.bombPoint++;
                        Hmonster.GetComponent<EnemyCtrl>().currHp = Hmonster.GetComponent<EnemyCtrl>().initHp = hmhp;
                        Hmonster.tag = "MONSTER";
                        i++;
                        yield return new WaitForSeconds(spawnTime);
                    }
                    if (i != 1 && MonsterNum <= MaxMonsterNum)
                    {
                        monsterObj = nm[Random.Range(0, nm.Count)];
                        GameObject Nmonster = (GameObject)Instantiate(monsterObj, pos, Quaternion.identity);
                        Nmonster.GetComponent<EnemyCtrl>().currHp = Nmonster.GetComponent<EnemyCtrl>().initHp = nmhp;
                        Nmonster.tag = "MONSTER";
                        MonsterNum++;
                    }
                }
            }
            else if (Round == MaxRound)
            {
                if (isSpawnMonster)
                {
                    if (BossNum <= MaxBMonsterNum)
                    {
                        Vector3 pos = transform.position;
                        Object monsterObj = bm[Random.Range(0, bm.Count)];
                        GameObject Monster = (GameObject)Instantiate(monsterObj, pos, Quaternion.identity);
                        Monster.GetComponent<EnemyCtrl>().currHp = Monster.GetComponent<EnemyCtrl>().initHp = bmhp;
                        Monster.tag = "MONSTER";
                        BossNum++;
                        spawnTime += 5f;
                    }
                }
            }
        }
    }
    IEnumerator coCheckMonsterNum()
    {
        while (Time_manager.isGame)
        {
            yield return new WaitForSeconds(intervalCheckMonsterNum);
            if (Round != MaxRound)
            {

                if (MonsterNum == MaxMonsterNum)
                {
                    isSpawnMonster = false;
                }
            }
            else if (Round == MaxRound)
            {
                if (BossNum == MaxBMonsterNum)
                {
                    isSpawnMonster = false;
                }
            }
        }
    }

    void hpmanage()
    {
        switch (Round)
        {
            case 1:
                nmhp = 50;
                hmhp = 100;
                break;
            case 2:
                nmhp = 300;
                break;
            case 3:
                nmhp = 600;
                break;
            case 4:
                nmhp = 1600;
                hmhp = 3200;
                break;
            case 5:
                nmhp = 2100;
                hmhp = 4200;
                break;
            case 6:
                nmhp = 2800;
                hmhp = 5600;
                break;
            case 7:
                nmhp = 4000;
                hmhp = 8000;
                break;
            case 8:
                nmhp = 4800;
                hmhp = 9600;
                break;
            case 9:
                nmhp = 6100;
                hmhp = 12000;
                break;
            case 10:
                bmhp = 170000;
                break;
        }
    }
}