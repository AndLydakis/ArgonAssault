using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void Start() {

    }

    void Update() {

    }

    void OnCollisionEnter(Collision collision) {
        print("OnCollisionEnter");
    }

    private void OnTriggerEnter(Collider other) {
        print("OnTriggerEnter");
        StartDeathSequence();
    }

    private void StartDeathSequence() {
        SendMessage("OnPlayerDeath");
    }
}
