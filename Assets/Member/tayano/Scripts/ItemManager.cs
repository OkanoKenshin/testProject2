using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public AudioClip GlassSE;
    AudioSource GlassSESource;
    // Start is called before the first frame update
    void Start()
    {
        GlassSESource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            GlassSESource.PlayOneShot(GlassSE);
            Destroy(this.gameObject);
            //Debug.LogError("—Ž‚¿‚½");
        }
    }
}
