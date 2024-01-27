using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField] DialogueTrigger[] _enemies;

    public UnityEvent KillPlayer;
    void Awake()
    {
        instance = this;
    }

    public void CheckAnswer(int id, int number, int itemID)
    {
        foreach (DialogueTrigger enemy in _enemies)
        {
            if (enemy.id == id)
            {
                if (enemy.rightAnswer == number && InventoryManager.instance.CheckItem(itemID))
                {
                    enemy.isDead = true;
                    InventoryManager.instance.DestroyItem(itemID);
                    enemy.gameObject.layer = LayerMask.NameToLayer("Default");
                    return;
                }
            }
        }

        KillPlayer?.Invoke();
    }


}
