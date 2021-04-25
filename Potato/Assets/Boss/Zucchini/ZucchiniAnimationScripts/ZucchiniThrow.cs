using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZucchiniThrow : BaseBossAtk
{
    public GameObject attackPrefab;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        spawnPos.Set(enemyPos.position.x, enemyPos.position.y);

        Instantiate(attackPrefab, spawnPos, enemyPos.rotation);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }
}
