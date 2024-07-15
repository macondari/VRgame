using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;
    public float extra = 32;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; // gives coordinates of initial position in transform section of inspector for the background
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; //sets width as half of the box collider on the background

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition.x - repeatWidth - extra) //if current position < start position - repeat width 
        {
            transform.position = startPosition;
        }
    }
}
