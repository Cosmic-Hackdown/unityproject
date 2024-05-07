using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //how long cooldown before next attack is
    [SerializeField] private float attackCooldown;

    //position from which the bullets will be fired
    [SerializeField] private Transform killPoint;

    //array that holds all 10 killcommand bullets
    [SerializeField] private GameObject[] killbullets;

    //counts how long it takes before cooldown is reached and can attack again
        private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private PlayerMovement playerMovement;

    // 
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()) {
            Attack();
            cooldownTimer += Time.deltaTime;
        }
    }

    private void Attack() {


        cooldownTimer = 0;

        //object pooling - multiple kill commands already created.  deactivated on hit and waits to be reused.
        //recommended when creating lots of objects as opposed to making it Instantiate every time.
        killbullets[0].transform.position = killPoint.position;
        killbullets[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }
}
