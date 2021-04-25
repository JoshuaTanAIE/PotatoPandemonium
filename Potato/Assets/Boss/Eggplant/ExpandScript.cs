using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandScript : MonoBehaviour
{
    public int maxSize;
    public float waitTime;
    bool hasReachedMax;
    public Vector3 amountToExpand;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasReachedMax)
        {
            if (transform.localScale.x < maxSize)
            {
                transform.localScale += amountToExpand * Time.deltaTime;
            }
            else
            {
                hasReachedMax = true;
            }
        }
        else if(waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            if(transform.localScale.x > 0.01f)
            {
                transform.localScale -= 2 * amountToExpand * Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
}
