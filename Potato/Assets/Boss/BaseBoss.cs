using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBoss : StateMachineBehaviour
{
    [HideInInspector] public Transform playerPos;
    [HideInInspector] public Transform enemyPos;
    [HideInInspector] public Vector2 destination;
    public float speed;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        enemyPos = animator.GetComponent<Transform>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    public void MoveToDestination(Vector2 destination, float speed)
    {
        enemyPos.position = Vector2.MoveTowards(enemyPos.position, destination, speed * Time.deltaTime);
    }

    public bool IsAtDestination()
    {
        if (Vector2.Distance(enemyPos.position, destination) < 0.1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void FacePlayer()
    {
        if (playerPos.position.x > enemyPos.position.x)
        {
            enemyPos.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            enemyPos.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
