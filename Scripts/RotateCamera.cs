using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private GameObject person; // Declare person as a class field
    public MoveLeft moveLeftScript;
    // Start is called before the first frame update
    void Start()
    {
        person = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (person != null)
        {
            // Access the Transform component of the person GameObject
            Transform personTransform = person.transform;

            // Check the x-value of the person's position
            if (personTransform.position.x > 40f && personTransform.position.x < 43f)
            {
                moveLeftScript.rotateDelete = true;
                Debug.Log("Player's x-position is 10");
                // Example: Rotate 180 degrees around the y-axis
                gameObject.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                gameObject.transform.localPosition = new Vector3(-15, 4, 8);
            }
        }
        else
        {
            // Handle the case where the GameObject with tag "Player" was not found
            Debug.LogWarning("GameObject with tag 'Player' not found.");
        }
    }
}
