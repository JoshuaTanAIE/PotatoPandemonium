using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageIdle : BaseBossIdle
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        destination.Set(playerPos.position.x, enemyPos.position.y);
        MoveToDestination(destination, speed);
    }
}
