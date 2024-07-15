using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
   
    public MoveLeft moveLeftScript;
    public SpawnManager spawnManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        if(OVRInput.GetDown(OVRInput.Button.Three)) //X button
        {
            if (spawnManagerScript.repeatRate > 1.5f)
            {

                moveLeftScript.speed = 7;
                spawnManagerScript.UpdateRepeatRate(4f, 0);
            }
        }
        //if (Input.GetKeyDown(KeyCode.S))
        if (OVRInput.GetDown(OVRInput.Button.Four)) //Y button
        {
            if (moveLeftScript.speed > 2.1f)
            {
                moveLeftScript.speed = 10;
                spawnManagerScript.UpdateRepeatRate(1.8f, 0);
            }
        }

    }
    
}
