using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_TextInputWindow : MonoBehaviour
{
    public string minionName;
    public TMP_InputField newName;
    public TMP_Text minionTag;

    void Start()
    {
        newName.GetComponent<Text>();
    }

    public void StoreName()
    {
        if (gameObject.CompareTag("Minion1"))
        {
            minionName = minionTag.text;
            minionTag.text = "(2) " + newName.text;
            
        }
        if (gameObject.CompareTag("Minion2"))
        {
            minionName = minionTag.text;
            minionTag.text = "(3) " + newName.text;
        }
        if (gameObject.CompareTag("Minion3"))
        {
            minionName = minionTag.text;
            minionTag.text = "(4) " + newName.text;
        }

        GameObject.Find("Player").SendMessage("ActivateMovement");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
