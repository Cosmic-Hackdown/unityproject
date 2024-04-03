using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    //get means you can get it from any other reference. set means you can only set it within this health script
    public float currentHealth{ get; private set; }

    private Animator anim;

    // Start is called before the first frame update and I think awake is called even before that?
    void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        
    }

    void TakeDamage(float _damage)
    {
        /*
        Mathf.Clamp(float value, float min, float max)
        Clamps the given value between the given min float and max float values.  Returns given value if it is within range.
        This makes sure our current health never goes below 0 or above startingHealth
        */
        currentHealth = Mathf.Clamp(currentHealth-_damage, 0, startingHealth);

        if(currentHealth > 0) {
            //player hurt
            anim.SetTrigger("hurt");
        } else {
            //player dies
            anim.SetTrigger("die");
        }
    }

/*
// This is just for testing purposes
    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            TakeDamage(1);
        }
    }
*/

   
}
