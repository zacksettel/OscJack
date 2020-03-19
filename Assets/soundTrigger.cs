using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class soundTrigger : MonoBehaviour
{
    public AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        if (!audiosrc)
            audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("PLAY");
            audiosrc.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("STOP");
            audiosrc.Stop();
        }
    }
}
