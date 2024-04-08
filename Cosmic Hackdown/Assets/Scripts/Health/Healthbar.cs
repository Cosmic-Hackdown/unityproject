using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    [SerializeField] private Health playerHealth;
   [SerializeField] private Image totalhealthBar;
      [SerializeField] private Image currenthealthBar;


    // Start is called before the first frame update
    void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        // it is out of 10 bc 0.3, which is how much of the healthbar is shown, is 3/10.  health shown will always be /10 in this case.
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
