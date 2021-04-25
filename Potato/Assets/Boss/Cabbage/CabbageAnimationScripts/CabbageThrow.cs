using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageThrow : BaseBossAtk
{
    public GameObject cabbagePrefab;
    public int noOfSpawns;
    public float upForce;
    public float sideForceRange;
    Vector2 force = new Vector2();

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        for (int i = 0; i < noOfSpawns; i++)
        {
            float zRotation = Random.Range(0, 180);
            GameObject cabbage = Instantiate(cabbagePrefab, enemyPos.position, Quaternion.Euler(0, 0, zRotation));

            float sideForce = Random.Range(-sideForceRange, sideForceRange);
            force.Set(sideForce, upForce);

            cabbage.GetComponent<Rigidbody2D>().AddForce(force);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }
}
