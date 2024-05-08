using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorHit : MonoBehaviour
{
    public AudioSource laserSound;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "bullet") {
            laserSound.Play();

        }
    }
    // Start is called before the first frame update
   /* void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } */

}
