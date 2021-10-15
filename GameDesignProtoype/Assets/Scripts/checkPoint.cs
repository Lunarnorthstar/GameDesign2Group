using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour //This script handles setting the checkpoint position and moving the player there if they touch a deathplane. Goes on the player. Dependencies; checkpointColliderScript, killZone.
{
    float CPX; //
    float CPY; //These two hold the X and Y positons of the CheckPoint.
    

    void CPsetX(float checkX) //This handles setting the checkpoint's X value.
    {
        CPX = checkX; //...Which it does right here.
    }
    void CPsetY(float checkY) //Same as above, but for the Y value.
    {
        CPY = checkY; //I'm honestly not sure why these need to be separate functions, but I don't dare tamper with it.
    }
  
    void gotoCP() //This function sets the player's position to the checkpoint.
    {
        transform.position = new Vector3(CPX, CPY); //If the player hasn't touched a checkpoint, they'll go to 0, 0 instead. This currently won't happen due to level structure.
    }
}
