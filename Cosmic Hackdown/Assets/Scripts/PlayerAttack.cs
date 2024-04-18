using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //how long cooldown before next attack is
    [SerializeField] private float attackCooldown;

    //counts how long it takes before cooldown is reached and can attack again
        private float cooldownTimer;

    private Animator anim;
    private PlayerMovement playerMovement;

    // 
  /*  private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
*/

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown) {
            Attack();
        }
    }

    private void Attack() {

    }
}
