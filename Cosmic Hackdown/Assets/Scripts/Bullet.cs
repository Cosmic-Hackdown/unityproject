using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  //life is the amount of time delayed before destroying the object (in this case, the enemy or obstacle)
  public float life = 3;
  public AudioSource laserSound;
  public AudioSource destroyerDestroyed;

  void Awake()
  {
    Destroy(gameObject, life);
  }


  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Enemy"))
    {
      destroyerDestroyed.Play();
      Destroy(other.gameObject);

    }
    if (other.gameObject.CompareTag("destroyer"))
    {
      laserSound.Play();
      Destroy(other.gameObject);

    }

    Destroy(gameObject);
  }

}
