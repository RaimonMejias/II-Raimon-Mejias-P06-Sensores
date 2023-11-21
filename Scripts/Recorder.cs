using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Recored : MonoBehaviour
{

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        foreach (string device in Microphone.devices) {
            Debug.Log(device);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")) {
           audioSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
        }

        if (Input.GetKeyDown("s")) {
            Microphone.End(Microphone.devices[0]);
            audioSource.Play();
        }
    }
}
