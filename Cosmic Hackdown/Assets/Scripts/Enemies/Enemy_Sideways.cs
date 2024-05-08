using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    public AudioSource laserSound;

    private void Awake() {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }


// Update is called once per frame
    void Update()
    {
        if(movingLeft) {
            if(transform.position.x > leftEdge) {

                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

            } else {
                movingLeft = false;
            }
        } else {

             if(transform.position.x < rightEdge) {

                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);


            } else {
                movingLeft = true;
            }

        }
        
    }

    /*
    Detect collisions with player
    */
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {

            //reduce player health by enemy damage
            collision.GetComponent<Health>().TakeDamage(damage);

        }
        if(collision.tag == "bullet") {
            laserSound.Play();
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
