using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeLogics : MonoBehaviour
{
    public int id;
    public int enemyId;

    public void CheckAnswer()
    {
        EnemyManager.instance.CheckAnswer(enemyId, id);
    }
}
