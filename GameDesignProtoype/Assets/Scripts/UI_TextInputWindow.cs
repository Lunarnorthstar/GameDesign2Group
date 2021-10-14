using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_TextInputWindow : MonoBehaviour
{
    public string addName;
    public TMP_InputField newName;
    public TMP_Text nameTag;

    void Start()
    {
        newName.GetComponent<Text>();
    }

    public void StoreName()
    {
        if (gameObject.CompareTag("Player"))
        {
            addName = nameTag.text;
            nameTag.text = "(1) " + newName.text;
        }
        if (gameObject.CompareTag("Minion1"))
        {
            addName = nameTag.text;
            nameTag.text = "(2) " + newName.text;
        }
        if (gameObject.CompareTag("Minion2"))
        {
            addName = nameTag.text;
            nameTag.text = "(3) " + newName.text;
        }
        if (gameObject.CompareTag("Minion3"))
        {
            addName = nameTag.text;
            nameTag.text = "(4) " + newName.text;
        }

        GameObject.Find("Player").SendMessage("ActivateMovement");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
