using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _interactableLayer;
    public void Interact()
    {
        Collider[] interactableObjects = Physics.OverlapSphere(transform.position, 2.5f, _interactableLayer);

        if (interactableObjects.Length > 0)
            interactableObjects[0].GetComponent<Interactable>().Interact();
    }
}
