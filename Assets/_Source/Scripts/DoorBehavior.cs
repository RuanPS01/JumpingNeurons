using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    Animator doorAnimator;
    AudioSource audioSourceEffect;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        audioSourceEffect = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
         if(other.tag == "Player")
         {
            doorAnimator.Play("OpenDoor");
         }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            doorAnimator.Play("CloseDoor");
        }
    }

    public void PlayAudioEffect()
    {
        audioSourceEffect.Play();
    }
}
