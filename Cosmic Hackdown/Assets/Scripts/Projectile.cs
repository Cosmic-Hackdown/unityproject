using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float direction;
    [SerializeField] private float speed;

    private bool hit;
    private BoxCollider2D boxCollider;

      private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if killcommand hits something, return and don't execute rest of code
        if(hit) {
            return;
        }
        //else
        //allow us to determine which direction it will fly
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

       
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        hit = true;
        //disable box collider
        boxCollider.enabled = false;

        
    }

    public void SetDirection(float _direction) {
        direction = _direction;

        //want to make sure that the killcommand game object is active
        gameObject.SetActive(true);
        //reset state of hitting an object or enemy
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate(){
        gameObject.SetActive(false);
    }
 }
