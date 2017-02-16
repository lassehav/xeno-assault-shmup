using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRandomizer : MonoBehaviour {

    public GameObject[] primaryExplosionOptions;
    public GameObject[] secondaryExplosionOptions;
    public int maxSecondaryExplosions;
    public int minSecondaryExplosions;

    // Use this for initialization
    public void Explode () {
        Instantiate(primaryExplosionOptions[Random.Range(0, primaryExplosionOptions.Length - 1)], gameObject.transform.position, Quaternion.identity);
        for(int i = 0; i < Random.Range(minSecondaryExplosions, maxSecondaryExplosions); i++)
        {
            GameObject e = Instantiate(secondaryExplosionOptions[Random.Range(0, secondaryExplosionOptions.Length - 1)], gameObject.transform.position, Quaternion.identity);
            e.transform.Translate(Random.Range(-0.35f, 0.35f), Random.Range(-0.35f, 0.35f), 0);
        }        
    }        
}
