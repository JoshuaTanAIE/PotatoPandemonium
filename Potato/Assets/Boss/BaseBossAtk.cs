using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBossAtk : BaseBoss
{
    public float startTimeTillIdle;
    float timeTillIdle;
    [HideInInspector] public int counter;
    [HideInInspector] public Vector2 spawnPos;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        timeTillIdle = startTimeTillIdle;

        counter = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (startTimeTillIdle > 0)
        {
            if (timeTillIdle > 0)
            {
                timeTillIdle -= Time.deltaTime;
            }
            else
            {
                animator.Play("Idle");
            }
        }
    }
}
