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
        minionName = minionTag.text;
        minionTag.text = newName.text;
        GameObject.Find("Player").SendMessage("ActivateMovement");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
