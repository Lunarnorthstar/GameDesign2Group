using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float X;
    public float Y;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            X = GameObject.Find("Player").transform.position.x;
            Y = GameObject.Find("Player").transform.position.y;
            
            GameObject.Find("Player").SendMessage("CPsetX", X);
            GameObject.Find("Player").SendMessage("CPsetY", Y);
            
        }
    }
}
