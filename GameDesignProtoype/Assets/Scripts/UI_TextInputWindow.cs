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
    public TMP_InputField name1;
    public TMP_InputField name2;
    public TMP_InputField name3;
    public GameObject minion1;
    public GameObject minion2;
    public GameObject minion3;

    void Start()
    {
        name1.GetComponent<Text>();
        name2.GetComponent<Text>();
        name3.GetComponent<Text>();
    }

    public void StoreName()
    {
        minion1Name = name1.text;
        minion2Name = name2.text;
        minion3Name = name3.text;
        name1.text = minion1.name;
        name2.text = minion2.name;
        name3.text = minion3.name;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
