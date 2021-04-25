using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfGrounded : MonoBehaviour
{
    Player player;
    public float startGroundedTimer;
    float groundedTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arena"))
        {
            groundedTimer = startGroundedTimer;
            player.currentState = State.normal;
            player.longJumpTimer = player.startLongJumpTimer;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Arena"))
        {
            if(groundedTimer > 0)
            {
                groundedTimer -= Time.deltaTime;
            }
            else
            {
                player.rigidbody2D.velocity = Vector2.zero; 
                player.isGrounded = true;
            }

            player.canMove = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Arena"))
        {
            player.isGrounded = false;
        }

        player.canMove = false;
    }
}
