using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnCharacter : MonoBehaviour
{
    public Transform character;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = character.position;
    }
}
