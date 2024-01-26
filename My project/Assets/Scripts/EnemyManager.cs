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

    public void CheckAnswer(int id, int number)
    {
        foreach (DialogueTrigger enemy in _enemies)
        {
            if (enemy.id == id)
            {
                if (enemy.rightAnswer == number)
                {
                    enemy.isDead = true;
                    enemy.gameObject.layer = LayerMask.NameToLayer("Default");
                    return;
                }
            }
        }

        KillPlayer?.Invoke();
    }


}
