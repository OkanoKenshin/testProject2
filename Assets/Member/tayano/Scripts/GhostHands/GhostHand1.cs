using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHand1 : MonoBehaviour
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
            
            if (Input.GetButtonDown("GhostAction1")){
                Debug.Log("“–‚½‚Á‚½");
                other.GetComponent<Rigidbody>().useGravity = true;
            }

        }

    }
}
