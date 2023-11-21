using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatSound : MonoBehaviour
{

    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }   


    void OnCollisionEnter(Collision other) {
        if (other.collider.gameObject.tag == "Spider") {
            Debug.Log("Sonando");
            audioSource.Play();
        }
    }
}
