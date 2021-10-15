using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_TextInputWindow : MonoBehaviour //This script handles the input window used to name the characters. Goes on the given UI element. Dependencies; None.
{
    public string addName; //The contents of the name tag.
    public TMP_InputField newName; //The name given to the host.
    public TMP_Text nameTag; //The text box that the name will be displayed in.

    void Start()
    {
        newName.GetComponent<Text>(); //Get the player's input from the text box in the UI element.
    }

    public void StoreName()
    {
        if (gameObject.CompareTag("Player")) //If the object triggering this is the player character...
        {
            addName = nameTag.text; //Assigns the name to the player character.
            nameTag.text = "(1) " + newName.text; //Displays the chosen name, along with an indication that you can press 1 to swap to this character.
        }
        if (gameObject.CompareTag("Minion1")) //Same as above, but with minion 1.
        {
            addName = nameTag.text;
            nameTag.text = "(2) " + newName.text;
        }
        if (gameObject.CompareTag("Minion2")) //And again with minion 2.
        {
            addName = nameTag.text;
            nameTag.text = "(3) " + newName.text;
        }
        if (gameObject.CompareTag("Minion3")) //And again with minion 3.
        {
            addName = nameTag.text;
            nameTag.text = "(4) " + newName.text;
        }

        GameObject.Find("Player").SendMessage("ActivateMovement"); //Reactivates movement for the player. It's disabled during naming to prevent moving around for names with A or D in them.
    }

    public void Hide() //This function hides the text box.
    {
        gameObject.SetActive(false); //Which it does right here.
    }
}
