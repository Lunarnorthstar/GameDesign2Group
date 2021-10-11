using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    [SerializeField] private Color MM1 = Color.white;
    [SerializeField] private Color MM1A = Color.white;
    [SerializeField] private Color MM1I = Color.white;

    public SpriteRenderer myObject;
    public Sprite deadSprite;

    void Start()
    {
        myObject = GetComponent<SpriteRenderer>();
    }

    public void changeColorOn()
    {
        if (transform.parent.CompareTag("Minion1") || transform.parent.CompareTag("Minion2") || transform.parent.CompareTag("Minion3"))
        {
            myObject.material.color = MM1A;
        }
    }
    public void changeColorOff()
    {
        
        myObject.material.color = MM1;
    }
    public void changeColorDead()
    {
        myObject.material.color = MM1I;
        myObject.sprite = deadSprite;
    }
}
