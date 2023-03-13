using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleCtrl : MonoBehaviour
{
    private float missleDamage;
    public float mSpeed = 30;
    public GameObject mParticle;
    GameObject missleParticle;
    public AudioClip explodsionBombSound;

    void Update()
    {
        missleDamage = 10000;//TowerCtrl.damage * 15;
        this.transform.Translate(Vector3.up * mSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MONSTER"))
        {

            SpawnMissle.spawnMissleAudio.PlayOneShot(explodsionBombSound, 1.0f);
            //Debug.Log(other.name);
            //collision.transform.GetComponent<EnemyCtrl>().GetDamage(missleDamage);
            other.GetComponent<EnemyCtrl>().GetDamage(missleDamage);
            //Destroy(this.gameObject);
            missleParticle = (GameObject)Instantiate(mParticle, this.transform.position - Vector3.down, mParticle.transform.rotation);
            Destroy(missleParticle, 1f);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("MAP"))
        {
            SpawnMissle.spawnMissleAudio.PlayOneShot(explodsionBombSound, 1.0f);
            //Debug.Log(other.name);
            //Destroy(this.gameObject);
            missleParticle = (GameObject)Instantiate(mParticle, this.transform.position, mParticle.transform.rotation);
            Destroy(missleParticle, 1f);
            Destroy(this.gameObject);
        }
    }
}
