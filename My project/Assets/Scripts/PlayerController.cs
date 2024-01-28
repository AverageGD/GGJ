using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject deathScreen;

    public bool isDead = false;
    public void Interact()
    {
        Collider[] interactableObjects = Physics.OverlapSphere(transform.position, 2.5f, _interactableLayer);

        if (interactableObjects.Length > 0)
            interactableObjects[0].GetComponent<Interactable>().Interact();
    }

    private void Update()
    {
        if (isDead)
        {
            spriteRenderer.sprite = _sprite;
        }

    }

    public void KillPlayer()
    {
        isDead = true;
        StartCoroutine(DeathScreen());
    }

    private IEnumerator DeathScreen()
    {
        yield return new WaitForSeconds(0.5f);

        deathScreen.SetActive(true);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(1);

    }
}
