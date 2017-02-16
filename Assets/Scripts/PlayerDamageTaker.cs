
using System.Collections;
using UnityEngine;

public class PlayerDamageTaker : BasicDamageTaker {

    public GameObject explosionPrefab;
    private bool spawnProtectPeriod = false;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnProtectDelay());
        StartCoroutine(SpawnFlicker());
    }


    IEnumerator SpawnProtectDelay()
    {        
        spawnProtectPeriod = true;
        yield return new WaitForSeconds(5);
        spawnProtectPeriod = false;        
    }

    IEnumerator SpawnFlicker()
    {
        while(spawnProtectPeriod)
        {
            yield return new WaitForSeconds(0.05f);
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        }
        GetComponent<SpriteRenderer>().enabled = true;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Kill();
        }
    }

    public override void Kill()
    {        
        if(spawnProtectPeriod == false)
        {
            gm.PlayerKilled();
            GameObject exp = GameObject.Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);            
            Destroy(this.gameObject);
        }        
    }
}
