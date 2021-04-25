using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggplantIdle : BaseBossIdle
{
    public Vector2 arenaHeight;
    public Vector2 arenaWidth;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        destination.Set(Random.Range(arenaWidth.x, arenaWidth.y), Random.Range(arenaHeight.x, arenaHeight.y));
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        MoveToDestination(destination, speed);
    }
}
