using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSpace : MonoBehaviour, IDropHandler
{    
    private bool canPut;
    private Transform trans;
    private string nameStudent;
    // Start is called before the first frame update
    void Start()
    {
        canPut = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {        
        
        if (eventData.pointerDrag != false)
        {   
            
            if(canPut){
                GameObject.Find(nameStudent).transform.SetParent(this.gameObject.transform);
            }            
        }       
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {           
        if(other.name.Contains("Estudent"))
        {            
            canPut = true;   
            trans = other.GetComponent<Transform>();
            nameStudent = other.name;     
        }            
    }

    public void OnTriggerExit2D(Collider2D other)
    {               
        if(other.name.Contains("Estudent"))
        {            
            canPut = false;
        }  
    }
}
