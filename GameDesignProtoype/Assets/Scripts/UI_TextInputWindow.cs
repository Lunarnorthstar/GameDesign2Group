using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_TextInputWindow : MonoBehaviour
{
    public string minion1Name;
    public string minion2Name;
    public string minion3Name;
    public TMP_InputField inputField;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    public GameObject minion1;
    public GameObject minion2;
    public GameObject minion3;

    void Start()
    {
        inputField.GetComponent<Text>();
        inputField2.GetComponent<Text>();
        inputField3.GetComponent<Text>();
    }

    public void StoreName()
    {
        minion1Name = minion1.name;
        minion2Name = minion2.name;
        minion3Name = minion3.name;
        minion1.name = inputField.text;
        minion2.name = inputField2.text;
        minion3.name = inputField3.text;
        Debug.Log("They are " + minion1Name + minion2Name + minion3Name);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}