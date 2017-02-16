using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

    public int bulletDamage = 1;
    public GameObject explosionPrefab;
    public string ObjectTagToHit;
    
    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == ObjectTagToHit)
        {
            c.GetComponent<IDamageable>().Damage(bulletDamage);
            Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            
            Destroy(this.gameObject);
        }
    }
}
