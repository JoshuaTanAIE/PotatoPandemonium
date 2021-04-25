using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZucchiniDash : BaseBossAtk
{
    public float startWaitTime;
    float waitTime;
    public float amountToRise;
    Rigidbody2D rigidbody2D;
    public Vector2 arenaSize;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        waitTime = startWaitTime;

        destination.Set(playerPos.position.x, enemyPos.position.y + amountToRise);

        rigidbody2D = animator.GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if(counter == 0)
        {
            MoveToDestination(destination, speed);
        }
        else
        {
            if(waitTime > 0)
            {
                waitTime -= Time.deltaTime;
            }
            else
            {
                animator.Play("Idle");
            }
        }

        if(IsAtDestination())
        {
            if(counter == 0)
            {
                counter++;
                rigidbody2D.gravityScale = 3;
            }
        }

        if(enemyPos.position.x < arenaSize.x || enemyPos.position.x > arenaSize.y)
        {
            if (counter == 0)
            {
                counter++;
                rigidbody2D.gravityScale = 3;
            }
        }
    }
}
