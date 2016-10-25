using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject EnemyObj;

    void Start()
    {
        StartCoroutine(enemyGenerator());
    }

    IEnumerator enemyGenerator()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector2 spawnPosition = new Vector2(
                    Random.Range(-2.0f, 2.0f),
                    Random.Range(-2.0f, 2.0f));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(EnemyObj, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(3);
        }
    }
}
