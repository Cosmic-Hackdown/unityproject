using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyerHit : MonoBehaviour
{
    public AudioSource destroyerDestroyed;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "bullet") {
            destroyerDestroyed.Play();

        }
    }
}
