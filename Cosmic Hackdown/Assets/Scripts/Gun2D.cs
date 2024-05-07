using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2D : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    //false if kill command item not collected.  if collected, switches to true
    public bool killCollected = false;

    // Start is called before the first frame update
  /*  void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {

        //press m to shoot kill command.  can only do so if kill command item has been collected
        if(Input.GetKeyDown(KeyCode.M) && killCollected) {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right*bulletSpeed;
        }
        
    }

    //if kill command item is collected, you gain the ability to shoot it at enemies
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("kill")) {
            Destroy(other.gameObject);
            killCollected = true;
        }
    }
}
