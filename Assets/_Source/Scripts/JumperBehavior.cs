using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperBehavior : MonoBehaviour
{
    public float jumpForce;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Jump(other.gameObject);
        }
    }
    private void Jump(GameObject player)
    {
        audioSource.Play();
        Rigidbody rigidbody = player.transform.parent.gameObject.GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);
        rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
