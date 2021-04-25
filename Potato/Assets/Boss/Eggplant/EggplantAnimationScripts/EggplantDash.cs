using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggplantDash : BaseBossAtk
{
    public GameObject afterimagePrefab;
    public float startTimeTillAtk;
    float timeTillAtk;
    float yDestination;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        timeTillAtk = 0;

        yDestination = Random.Range(-330, -341);
        if(playerPos.position.x > enemyPos.position.x)
        {
            destination.Set(223, yDestination);
        }
        else
        {
            destination.Set(243, yDestination);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if(destination.x > enemyPos.position.x)
        {
            enemyPos.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            enemyPos.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (IsAtDestination())
        {
            yDestination = Random.Range(-330, -341);
            if (enemyPos.position.x > 230)
            {
                destination.Set(223, yDestination);
            }
            else
            {
                destination.Set(243, yDestination);
            }
        }

        MoveToDestination(destination, speed);

        if(timeTillAtk > 0)
        {
            timeTillAtk -= Time.deltaTime;
        }
        else
        {
            Instantiate(afterimagePrefab, enemyPos.position, enemyPos.rotation);
            timeTillAtk = startTimeTillAtk;
        }
    }
}
