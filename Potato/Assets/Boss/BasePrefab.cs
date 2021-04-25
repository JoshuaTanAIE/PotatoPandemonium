using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePrefab : MonoBehaviour
{
    public float timeTillDestroy;
    [HideInInspector] public Transform playerPos;

    // Start is called before the first frame update
    public virtual void Start()
    {
        if(timeTillDestroy > 0)
        {
            Destroy(gameObject, timeTillDestroy);
        }

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
