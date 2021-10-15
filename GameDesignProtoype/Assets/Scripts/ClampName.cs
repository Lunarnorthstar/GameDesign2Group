using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClampName : MonoBehaviour //This script handles the name tags and making sure they appear in the right place. Goes on a placeholder object childed to the minions. Dependencies; None.
{
    public TMP_Text nameLabel; //The label of the minion; what the player chose to name it.

    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position); //Gets a position based on the position of the camera.
        nameLabel.transform.position = namePos; //Moves the name tag to that position, this keeps it centered above the character's head.
    }
}
