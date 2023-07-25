using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeAnimationScript : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;
    Animator myAnimator;
    RuntimeAnimatorController idleAnimation;
    RuntimeAnimatorController walkAnimation;
    public float runspeed = 0.15f;

    System.Boolean flipped = false;
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        idleAnimation = Resources.Load("Animations/Player_Idle_Controller") as RuntimeAnimatorController;
        walkAnimation = Resources.Load("Animations/Player_Walk") as RuntimeAnimatorController;
        

    }
    // Update is called once per frame
    void FixedUpdate()
    {
       
        //float runspeed = 0.15f; ;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical"); // not using this
        if (!Input.anyKey)
        {
            // if no keys are pressed do the idle animation
            myAnimator.runtimeAnimatorController = idleAnimation;
        }
        if (moveHorizontal < 0)
        {
            // walk left
            myAnimator.runtimeAnimatorController = walkAnimation;
            flipped = true;
            Vector3 currentPos = transform.position;
            currentPos.x -= 0.1f * runspeed;
            transform.position = currentPos;
        }
        if (moveHorizontal > 0)
        {
            // walk right, and flip the sprite in X
            myAnimator.runtimeAnimatorController = walkAnimation;
            flipped = false;
            Vector3 currentPos = transform.position;
            currentPos.x += 0.1f * runspeed;
            transform.position = currentPos;
        }
        // set the sprite facing the correct way
        mySpriteRenderer.flipX = flipped;
    }
}