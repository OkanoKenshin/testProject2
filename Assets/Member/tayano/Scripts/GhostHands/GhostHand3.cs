using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHand3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        if(other.CompareTag("Item") ) {
            
            if (Input.GetButtonDown("GhostAction3")){

                other.GetComponent<Rigidbody>().useGravity = true;
            }

        }

    }
}
