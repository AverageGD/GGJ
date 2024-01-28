using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField] DialogueTrigger[] _enemies;

    public UnityEvent KillPlayer;
    public UnityEvent Win;
    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        bool check = true;

        foreach (DialogueTrigger enemy in _enemies)
        {
            check &= enemy.isDead;
        }
        if (check)
        {
            StartCoroutine(PlayerWin());
        }
    }
    public void CheckAnswer(int id, int number, int itemID)
    {
        bool ch = false;

        foreach (DialogueTrigger enemy in _enemies)
        {
            if (enemy.id == id)
            {

                if (enemy.rightAnswer == number)
                    ch = true;

                if (enemy.rightAnswer == number && InventoryManager.instance.CheckItem(itemID))
                {
                    enemy.isDead = true;
                    enemy.GetComponent<AudioSource>().Play();
                    InventoryManager.instance.DestroyItem(itemID);
                    enemy.gameObject.layer = LayerMask.NameToLayer("Default");
                    return;
                }
            }
        }

        if (!ch)
            KillPlayer?.Invoke();
    }

    private IEnumerator PlayerWin()
    {
        yield return new WaitForSeconds(0.5f);

        Win?.Invoke();
    }
}
