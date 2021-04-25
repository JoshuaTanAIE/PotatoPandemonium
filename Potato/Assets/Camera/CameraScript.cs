using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Transform player;
    Vector3 pos = new Vector3(0,0,0);
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        pos.Set(player.position.x, player.position.y + offset, -10);
        transform.position = pos;
    }
}
