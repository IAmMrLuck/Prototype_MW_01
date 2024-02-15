using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollinationManager : MonoBehaviour
{
    [SerializeField] private Material petalMaterial;

    private void Start()
    {
        petalMaterial.SetColor("_Color", Color.red);
        // Assuming the child gameObject is named "ChildGameObject"
        Transform child = transform.Find("Petals");

        if (child != null)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = petalMaterial;
            }
            else
            {
                Debug.LogWarning("Child does not have a Renderer component.");
            }
        }
        else
        {
            Debug.LogWarning("Child GameObject not found.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("in Trigger");
        petalMaterial.SetColor("_Color", Color.blue);
    }
}
