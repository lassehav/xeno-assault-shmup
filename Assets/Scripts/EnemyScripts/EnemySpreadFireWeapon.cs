using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpreadFireWeapon : MonoBehaviour, IWeapon {

    public GameObject projectilePrefab;
    public float firingInterval = 1.0f;
    private float firingTime = 0.0f;
    public int burstSize = 3;
    public float burstInternalInterval = 0.2f;
    private int burstCountTracker = 0;


    // Use this for initialization
    void Update() {
        if ((Time.time - firingTime) > firingInterval)
        {
            Fire(gameObject.transform.position);
            firingTime = Time.time;            
        }
    }

    public void Fire(Vector2 position)
    {
        InvokeRepeating("FireBurst", 0, burstInternalInterval);    
    }

    void FireBurst()
    {
        GameObject.Instantiate(projectilePrefab, gameObject.transform.position, gameObject.transform.rotation);
        burstCountTracker++;
        if(burstCountTracker == burstSize)
        {
            burstCountTracker = 0;
            CancelInvoke();            
        }
    }
}
