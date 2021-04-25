using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggplantStream : BaseBossAtk
{
    public int noOfAttacks;
    public GameObject eggplantSlicePrefab;
    public float startTimeTillAtk;
    float timeTillAtk;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        timeTillAtk = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (timeTillAtk > 0)
        {
            timeTillAtk -= Time.deltaTime;
        }
        else if (counter < noOfAttacks)
        {
            counter++;
            timeTillAtk = startTimeTillAtk;
            float zRotation = Random.Range(0, 180);
            Instantiate(eggplantSlicePrefab, enemyPos.position, Quaternion.Euler(0, 0, zRotation));
        }
    }
}
