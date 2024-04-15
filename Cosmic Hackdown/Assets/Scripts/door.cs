using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public bool isLocked;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        isLocked = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Key"))
        {
            anim.SetTrigger("Open");
            isLocked = false;
            Debug.Log("Débloqué");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Key"))
        {
            anim.SetTrigger("Close");
            isLocked = true;
            Debug.Log("Bloqué");
        }
    }
}
