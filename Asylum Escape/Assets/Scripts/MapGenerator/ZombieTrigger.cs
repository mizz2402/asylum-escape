using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{

   public GameObject zombie;
   void Start()
    {
        zombie.GetComponent<Animator>().enabled = false;
    }


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
     zombie.GetComponent<Animator>().enabled = true;
        
    }
}