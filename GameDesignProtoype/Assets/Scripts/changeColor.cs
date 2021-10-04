using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{

    [SerializeField] private Color MM1 = Color.white;
    [SerializeField] private Color MM1A = Color.white;
    
    public SpriteRenderer myObject;

    // Start is called before the first frame update
    void Start()
    {
        
        myObject = GetComponent<SpriteRenderer>();
    }
    
    public void changeColorOn()
    {
       
            
            
            myObject.material.color = MM1A;
        
        
    }
    public void changeColorOff()
    {
        
            Debug.Log("imma go stupid");
           
            myObject.material.color = MM1;
        

    }




}
