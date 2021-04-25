using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBossIdle : BaseBoss
{
    public float minStartTimeTillAtk;
    public float maxStartTimeTillAtk;
    [HideInInspector] public float timeTillAtk;
    [HideInInspector] public int attackToUse;

    public string[] attackNameArray;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        timeTillAtk = Random.Range(minStartTimeTillAtk, maxStartTimeTillAtk);

        attackToUse = Random.Range(0, attackNameArray.Length);

        FacePlayer();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        
        if(timeTillAtk > 0)
        {
            timeTillAtk -= Time.deltaTime;
        }
        else
        {
            animator.Play(attackNameArray[attackToUse]);
        }
    }
}
