using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button1Spawn : MonoBehaviour
{
    public counter = 0;
    public GameObject enemy;
    public Transform Button1;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N)) {
            var bullet = Instantiate(enemy, Button1.position, Button1.rotation);
            counter++;
        }
    }
}
