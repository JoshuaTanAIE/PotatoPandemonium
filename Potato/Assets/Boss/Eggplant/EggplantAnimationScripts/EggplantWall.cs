using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggplantWall : BaseBossAtk
{
    public GameObject eggplantSlicePrefab;
    public int noOfAttacks;
    public float sideForce;
    public float upForce;
    Vector2 forceVector = new Vector2();

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        for (int i = 0; i < noOfAttacks; i++)
        {
            float zRotation = Random.Range(0, 180);
            GameObject eggplantSlice = Instantiate(eggplantSlicePrefab, enemyPos.position, Quaternion.Euler(0, 0, zRotation));

            if (playerPos.position.x > enemyPos.position.x)
            {
                forceVector.Set(sideForce, upForce);
            }
            else
            {
                forceVector.Set(-sideForce, upForce);
            }

            Rigidbody2D eggplantSliceRB = eggplantSlice.GetComponent<Rigidbody2D>();
            eggplantSliceRB.AddForce(forceVector);
            eggplantSliceRB.gravityScale = i + 1;
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }
}
