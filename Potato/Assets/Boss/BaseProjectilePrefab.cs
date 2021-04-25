using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectilePrefab : BasePrefab
{
    public float speed;
    Vector2 destination;

    [Space]
    public bool movePastPlayer;
    public bool moveInADirection;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        if (movePastPlayer)
        {
            Vector2 movePos = 1000 * (playerPos.position - transform.position);
            destination = movePos;
        }

        if(moveInADirection)
        {
            if(playerPos.position.x > transform.position.x)
            {
                destination.Set(transform.position.x + 1000, transform.position.y);
            }
            else
            {
                destination.Set(transform.position.x - 1000, transform.position.y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }
}
