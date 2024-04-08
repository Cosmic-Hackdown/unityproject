using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //how much health to restore to player
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            collision.GetComponent<Health>().AddHealth(healthValue);
            //deactivate collectible so you can't collect more than once
            gameObject.SetActive(false);
        }
    }
    
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    */
}
