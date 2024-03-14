using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealObjectCounter : MonoBehaviour
{
    int health = 0;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.gameObject.CompareTag("HealObject"))
    	{
    		health++;
    		Destroy(other.gameObject);
    	}
    }
}
