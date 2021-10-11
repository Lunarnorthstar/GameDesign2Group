using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Summon : MonoBehaviour
{
    private float Xpos;
    private float Ypos;

    private bool active = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Xpos = GameObject.Find("Player").transform.position.x;
        Ypos = GameObject.Find("Player").transform.position.y;
    }



    public void Activate()
    {
        active = true;
    }
    
    public void Deactivate()
    {
        active = false;
    }
    
    public void Call(InputAction.CallbackContext context)
    {
        if (active)
        {
            transform.position = new Vector3(Xpos, Ypos);
        }
    }
}
