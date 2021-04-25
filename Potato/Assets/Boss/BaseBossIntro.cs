using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBossIntro : BaseBoss
{
    public Vector2 startPos;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if(Vector2.Distance(playerPos.transform.position, startPos) < 3)
        {
            animator.Play("Idle");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        animator.GetComponent<EnemyHealth>().StartFight();
    }
}
