using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button1Spawn : MonoBehaviour
{
    public int counterlaser = 0;
    public GameObject laser;
 //   public GameObject button2;
    public Transform Button1;

  public GameObject destroyerProtector;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    void Update() {
        if (counterlaser == 1) {
            gameObject.transform.position = new Vector2(-4, 4);
        } else if(counterlaser == 2) {
            Destroy(gameObject);
            Destroy(destroyerProtector);
        }

    }

    // Update is called once per frame
   private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("bullet")) {
            var newLaser = Instantiate(laser, Button1.position, Button1.rotation);
         //   var button2Create = Instantiate(button2, Button1.position, Button1.rotation);

           // Destroy(gameObject);
            counterlaser++;
        }
    }
}
