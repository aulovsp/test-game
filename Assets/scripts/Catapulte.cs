using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapulte : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        var isTaskComplete = other.gameObject.GetComponent<CollectingManager>().IsTaskComplete();

        if (!isTaskComplete)
        {
            var otherHealth = other.gameObject.GetComponent<Health>();
            otherHealth.Damage(10);
            return;
        }

        var otherRb = other.gameObject.GetComponent<Rigidbody>();
        otherRb.AddForce(transform.up * 100, ForceMode.Impulse);
        otherRb.AddForce(-transform.forward * 100, ForceMode.Impulse);
    }
}
