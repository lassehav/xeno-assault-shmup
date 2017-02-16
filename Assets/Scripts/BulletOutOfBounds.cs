using UnityEngine;
using System.Collections;

public class BulletOutOfBounds : MonoBehaviour {

    
    // Update is called once per frame
    void Update () {
        Vector3 minCoord = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector3 maxCoord = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Rect area = new Rect(minCoord.x, minCoord.y, maxCoord.x - minCoord.x, maxCoord.y - minCoord.y);
        if(area.Contains(transform.position) == false)
        {
            Destroy(gameObject);
        }

    }
}
