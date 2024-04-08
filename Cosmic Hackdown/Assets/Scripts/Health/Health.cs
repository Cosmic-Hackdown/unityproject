using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //health header that you can see in the Inspector under Health script
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    //get means you can get it from any other reference. set means you can only set it within this health script

    [Header ("iFrames")]

    //Serialize field so you can see and edit this value within Unity itself
    [SerializeField] private float iFramesDuration;

    //how many flashes you will see of invincibility after the player gets hurt
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    
    public float currentHealth{ get; private set; }

    private Animator anim;
    private bool dead;

    // Start is called before the first frame update and I think awake is called even before that?
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        //grab reference for spriterenderer component
        spriteRend = GetComponent<SpriteRenderer>();
        
    }

    public void TakeDamage(float _damage)
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
            StartCoroutine(Invunerability());
            //iframes
        } else {

            if(!dead) {

                 //player dies
            anim.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
            dead = true;

            }
           
        }
    }


    public void AddHealth(float _value) {
        currentHealth = Mathf.Clamp(currentHealth +_value, 0, startingHealth);

    }

    private IEnumerator Invunerability() {
        //make player invinsible temporarily
        //10 is layer 10 which is the player layer.  11 is layer 111 which is enemy layer
        //true means collisions will be ignored
        Physics2D.IgnoreLayerCollision(10, 11, true);

        for(int i = 0; i < numberOfFlashes; i++) {

            //1, 0, 0 are rgb values for RED (player flashes red).  0.5f is transparency (player will be slightly transparent colored during this duration)
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            /*
            for example, if iFramesDuration is 2 seconds and numberOfFlashes is 3, then each flash lasts around 2/(3*2) or 0.33 secs.
            */
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
            //Unity has a predefined color for white
            spriteRend.color = Color.white;
            //flash again this time with regular white color
           yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
            yield return new WaitForSeconds(0.3f);

        }

        //after invunerability flashes, player is no longer invincible so you change it back to false so player can get hurt again.
        Physics2D.IgnoreLayerCollision(10, 11, false);

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
