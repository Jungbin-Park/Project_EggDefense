using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public float moveSpeed = 20f;
    Vector3 dirx;

    private int initHp = 100;
    private int currHp;

    void Start()
    {
        dirx = Vector3.forward;

        currHp = initHp;
    }

    void Update()
    {
        if (transform.position.x <= 35 && transform.position.z >= 25)  // �������̵�
        {
            this.transform.Translate(dirx * moveSpeed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        if (transform.position.x >= 35 && transform.position.z >= -25) // �Ʒ����̵�
        {
            this.transform.Translate(dirx * moveSpeed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (transform.position.x >= -35 && transform.position.z <= -25)  // �����̵�
        {
            this.transform.Translate(dirx * moveSpeed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(0f, 270f, 0f);
        }
        if (transform.position.x <= -35 && transform.position.z <= 25)  // �����̵�
        {
            this.transform.Translate(dirx * moveSpeed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(0f, 360f, 0f);
        }
    }

    public void OnDamage(Vector3 pos, Vector3 normal)
    {
        currHp -= 10;
        Debug.Log("HP : " + currHp);
        if(currHp <= 0)
        {
            Debug.Log("Die");
            Destroy(this);
        }
    }
}
