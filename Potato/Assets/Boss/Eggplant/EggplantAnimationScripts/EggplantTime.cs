using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggplantTime : BaseBossAtk
{
    public GameObject timeStopPrefab;
    public GameObject eggplantSlicePrefab;
    public float startTimeTillAtk;
    float timeTillAtk;
    AudioSource audioSource;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        timeTillAtk = startTimeTillAtk;

        Instantiate(timeStopPrefab, enemyPos.position, enemyPos.rotation);
        playerPos.GetComponent<Player>().lockMovement = true;
        playerPos.GetComponent<Rigidbody2D>().gravityScale = 0;
        playerPos.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        audioSource = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<AudioSource>();
        audioSource.Pause();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if(timeTillAtk > 0)
        {
            timeTillAtk -= Time.deltaTime;
        }
        else if(counter == 0)
        {
            counter++;
            timeTillAtk = 0.6f;
            float zRotation = Random.Range(0, 180);
            Instantiate(eggplantSlicePrefab, enemyPos.position, Quaternion.Euler(0, 0, zRotation));
        }
        else if(counter == 1)
        {
            counter++;
            playerPos.GetComponent<Player>().lockMovement = false;
            playerPos.GetComponent<Rigidbody2D>().gravityScale = 1;
            audioSource.UnPause();
        }
    }
}
