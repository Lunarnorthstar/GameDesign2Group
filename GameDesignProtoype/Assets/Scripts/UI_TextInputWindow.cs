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
    public TMP_Text minion1Tag;
    public TMP_Text minion2Tag;
    public TMP_Text minion3Tag;

    void Start()
    {
        name1.GetComponent<Text>();
        name2.GetComponent<Text>();
        name3.GetComponent<Text>();
    }

    public void StoreName()
    {
        minion1Name = minion1Tag.text;
        minion2Name = minion2Tag.text;
        minion3Name = minion3Tag.text;
        minion1Tag.text = name1.text;
        minion2Tag.text = name2.text;
        minion3Tag.text = name3.text;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
