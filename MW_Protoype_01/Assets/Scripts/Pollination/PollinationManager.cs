using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollinationManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bee In Trigger");
    }
}
