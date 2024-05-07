using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float life = 3;
   public AudioSource laserSound;

   void Awake() {
    Destroy(gameObject, life);
   }

  /* void OnCollisionEnter2D(Collision2D collision) {
    if(collision.gameObject.CompareTag("Enemy")){
    Destroy(collision.gameObject);
    }
    Destroy(gameObject);
   }
*/
    void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("Enemy")){
      laserSound.Play();
    Destroy(other.gameObject);
    
    }
    Destroy(gameObject);
   }

}
