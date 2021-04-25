using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageJump : BaseBossAtk
{
    public float startTimeTillAtk;
    float timeTillAtk;
    public float noOfAttacks;
    bool hasUsedAtk;
    Rigidbody2D rigidbody2D;
    public GameObject cabbagePrefab;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        hasUsedAtk = false;
        timeTillAtk = startTimeTillAtk;
        destination.Set(enemyPos.position.x, enemyPos.position.y + 3);
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

        if(IsAtDestination())
        {
            counter++;
            rigidbody2D.gravityScale = 3;
        }

        if (timeTillAtk > 0)
        {
            timeTillAtk -= Time.deltaTime;
        }
        else if(!hasUsedAtk)
        {
            hasUsedAtk = true;

            for (int i = 0; i < noOfAttacks; i++)
            {
                spawnPos.Set(150 + (5*i), -150);

                float zRotation = Random.Range(0, 180);
                Instantiate(cabbagePrefab, spawnPos, Quaternion.Euler(0, 0, zRotation));
            }
        }
    }
}
