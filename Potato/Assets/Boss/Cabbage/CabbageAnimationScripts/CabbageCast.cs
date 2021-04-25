using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageCast : BaseBossAtk
{
    public GameObject cabbagePrefab;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        float zRotation = Random.Range(0, 180);
        Instantiate(cabbagePrefab, enemyPos.position, Quaternion.Euler(0, 0, zRotation));
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }
}
