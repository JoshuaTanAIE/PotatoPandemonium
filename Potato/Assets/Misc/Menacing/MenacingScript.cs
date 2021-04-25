using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenacingScript : MonoBehaviour
{
    public int speed;
    Vector2 destination;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
        destination.Set(-200, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }
}
