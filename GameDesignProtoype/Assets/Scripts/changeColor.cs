using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour //This script handles changing the colors of the minions based on their state. Goes on the minion sprite. Dependencies; Change_Character, killZone.
{
    [SerializeField] private Color MM1 = Color.white; //The "off" or "inactive" color.
    [SerializeField] private Color MM1A = Color.white; //The "on" or "active" color.
    [SerializeField] private Color MM1I = Color.white; //These three keep track of the color given. They could REALLY use better names. This one is the "dead" color. Set in editor.

    public SpriteRenderer myObject; //Itself (Not sure why this is here)
    public Sprite deadSprite; //The sprite to change to when dead (must be set in editor)

    void Start()
    {
        myObject = GetComponent<SpriteRenderer>(); //Get the sprite renderer component from this object.
    }

    public void changeColorOn() //This function sets the host's color to the "active" color.
    {
        if (transform.parent.CompareTag("Minion1") || transform.parent.CompareTag("Minion2") || transform.parent.CompareTag("Minion3")) //If their tag is relevant
        {
            myObject.material.color = MM1A; //Set the color.
        }
    }
    public void changeColorOff() //This handles setting the host's color to the "inactive" color.
    {
        
        myObject.material.color = MM1; //Which it does right here.
    }
    public void changeColorDead() //This handles setting the host's color to the "dead" color.
    {
        myObject.material.color = MM1I; //Set the color
        myObject.sprite = deadSprite; //And then change the sprite.
    }
}
