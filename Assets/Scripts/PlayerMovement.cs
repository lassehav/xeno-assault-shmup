using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 3.0f;

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        // Get movement direction
        float xMovCommand = Input.GetAxisRaw("Horizontal");
        float yMovCommand = Input.GetAxisRaw("Vertical");

        // create a movement vector
        Vector3 movCommand = new Vector3(xMovCommand, yMovCommand, 0);

        // Get screen limits in world coord
        Vector3 minCoord = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector3 maxCoord = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Calculate the would be location
        Vector3 currentPos = transform.position;       
        currentPos += movCommand * Time.deltaTime * movementSpeed;
        // Limit the movement to visible area
        currentPos.x = Mathf.Clamp(currentPos.x, minCoord.x, maxCoord.x);
        currentPos.y = Mathf.Clamp(currentPos.y, minCoord.y, maxCoord.y);

        // apply the movement relative to the deltatime
        transform.position = currentPos;
    }
}
