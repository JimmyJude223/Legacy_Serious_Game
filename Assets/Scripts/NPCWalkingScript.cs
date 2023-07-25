using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalkingScript : MonoBehaviour
{
    public float movementspeed = 3f;
    Transform leftWaypoint,rightWaypoint;
    Vector3 localScale;
    bool movingright = true;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        leftWaypoint = GameObject.Find("LeftWalkway").GetComponent<Transform>();
        rightWaypoint = GameObject.Find("RightWalkway").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > rightWaypoint.position.x)
        
            movingright = false;
            if(transform.position.x< leftWaypoint.position.x)
            movingright=true;

        if (movingright)
            moveright();
        else
            moveleft();
        
        
    }
    void moveright() {
        movingright = true;
        localScale.x = 0.5f;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * movementspeed,rb.velocity.y );
    
    }
    void moveleft()
    {
        movingright = false;
        localScale.x = -0.5f;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * movementspeed, rb.velocity.y);

    }

}
