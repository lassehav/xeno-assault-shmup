using UnityEngine;
using System.Collections;

public class EnemyBasicWeapon : MonoBehaviour, IWeapon
{
    public GameObject projectilePrefab;
    public float firingInterval = 1.0f;
    private float firingTime = 0.0f;
    public bool trackingFiring = false;

    void Start()
    {
        firingTime = Random.Range(0, firingInterval);
    }

    // Update is called once per frame
    void Update () {

        if((Time.time - firingTime) > firingInterval)
        {
            Fire(gameObject.transform.position);
            firingTime = Time.time;
        }
    }

    public void Fire(Vector2 position)
    {
        Vector3 minCoord = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector3 maxCoord = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Rect view = new Rect(minCoord.x, minCoord.y, maxCoord.x - minCoord.x, maxCoord.y - minCoord.y);
        if(view.Contains(transform.position))
        {
            Quaternion direction = Quaternion.identity;
            if(trackingFiring)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if(player != null)
                {
                    Vector3 directionVector = player.transform.position - transform.position;
                    float angle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg - 90.0f;
                    direction = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
                }                                               
            }

            GameObject.Instantiate(projectilePrefab, position, direction);
        }                
    }
}
