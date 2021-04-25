using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToCharacter : MonoBehaviour
{
    public float timeTillSnap;
    public Transform character;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeTillSnap > 0)
        {
            timeTillSnap -= Time.deltaTime;
        }
        else
        {
            transform.position = character.position;
        }
    }
}
