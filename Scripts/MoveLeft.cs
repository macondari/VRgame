using Meta.WitAi.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10;
    public float joystick;
    private PlayerController PlayerControllerScript;
    private float leftBound = -15;
    public bool rotateDelete = false;
    public SpawnManager spawnManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //joystick = Input.GetAxis("Horizontal");
        joystick = Input.GetAxis("Vertical");
        if (PlayerControllerScript.gameOver == false)
        {
            if (!PlayerControllerScript.isRotate)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed * joystick);
                //time.deltatime allows things to be moved over time rather than at each frame
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed * joystick);
            }

        }

        if (transform.position.x < leftBound  && gameObject.CompareTag("Obstacle") && !rotateDelete)
        {
            Destroy(gameObject);
        }

        if (rotateDelete)
        {
            DeleteObstacles();
            rotateDelete = false;  // Reset rotateDelete after deletion
        }
    }

    void DeleteObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        spawnManagerScript.UpdateRepeatRate(5, 2);

        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
    }

}

