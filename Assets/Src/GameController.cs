using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject PlayerObj;
    GameObject EnemyObj;

    void Start()
    {
        EnemyObj = DfjObject.Instance.EnemyObj;
        CaptionManager.Instance.ShowTitle("王文撸大战设计模式", 100000);
        CaptionManager.Instance.ShowSubtitle("按空格键开始游戏！", 100000);
    }

    void Update()
    {
        switch (GameStateManager.Instance.GameState)
        {
            case eGameState.GAME_STATE_START_SCREEN:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine("level1");
                    GameStateManager.Instance.GameState = eGameState.GAME_STATE_PLAYING;
                }
                break;
            case eGameState.GAME_STATE_PLAYING:
                switch (GameStateManager.Instance.PlayState)
                {
                    case ePlayState.PLAY_STATE_STARTUP:
                        break;
                    case ePlayState.PLAY_STATE_WAVE:
                        break;
                    case ePlayState.PLAY_STATE_IN_BETWEEN_WAVES:
                        break;
                }
                break;
            case eGameState.GAME_STATE_GAME_OVER:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine("level1");
                    GameStateManager.Instance.GameState = eGameState.GAME_STATE_PLAYING;
                }
                break;
        }
    }

    public void GameOver()
    {
        StopCoroutine("level1");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var e in enemys)
            Destroy(e);
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        foreach (var e in player)
            Destroy(e);
        GameStateManager.Instance.GameState = eGameState.GAME_STATE_GAME_OVER;
        CaptionManager.Instance.ShowSubtitle("按空格键重新开始游戏！", 100000);
    }

    IEnumerator level1()
    {
        CaptionManager.Instance.ShowTitle("第一章");
        CaptionManager.Instance.ShowSubtitle("设计模式概述");
        Instantiate(PlayerObj, new Vector2(0, -3), Quaternion.identity);
 
        yield return new WaitForSeconds(3.5f);
        for (int i = 0; i < 10; i++)
        {
            Vector2 spawnPosition = new Vector2(
                Random.Range(-2.0f, 2.0f),
                Random.Range(-2.0f, 4.0f));
            GameObject go = (GameObject)Instantiate(
                EnemyObj,
                spawnPosition,
                Quaternion.identity);
            go.tag = "Enemy";
            go.AddComponent<DfjEnemy>();
            var sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>("Graphics/enemyBlue");
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(2);
        CaptionManager.Instance.ShowTitle("设计模式从何而来?", 4);
        CaptionManager.Instance.ShowSubtitle("Erich Gamma", 1);
        yield return new WaitForSeconds(1);
        CaptionManager.Instance.ShowSubtitle("Richard Helm", 1);
        yield return new WaitForSeconds(1);
        CaptionManager.Instance.ShowSubtitle("Ralph Johnson", 1);
        yield return new WaitForSeconds(1);
        CaptionManager.Instance.ShowSubtitle("John Vlissides", 1);

        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 20; i++)
        {
            Vector2 spawnPosition = new Vector2(
                Random.Range(-2.0f, 2.0f),
                Random.Range(-2.0f, 4.0f));
            GameObject go = (GameObject)Instantiate(
                EnemyObj,
                spawnPosition,
                Quaternion.identity);
            go.tag = "Enemy";
            go.AddComponent<DfjEnemy>();
            var sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>("Graphics/enemyBlue");
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(2);
        CaptionManager.Instance.ShowTitle("面向对象设计原则", 7);
        CaptionManager.Instance.ShowSubtitle("单一职责原则", 1);
        yield return new WaitForSeconds(1);
        CaptionManager.Instance.ShowSubtitle("开放封闭原则", 1);
        yield return new WaitForSeconds(1);
        CaptionManager.Instance.ShowSubtitle("里氏代换原则", 1);
        yield return new WaitForSeconds(1);
        CaptionManager.Instance.ShowSubtitle("依赖倒转原则", 1);
        yield return new WaitForSeconds(1);
        CaptionManager.Instance.ShowSubtitle("接口隔离原则", 1);
        yield return new WaitForSeconds(1);
        CaptionManager.Instance.ShowSubtitle("合成复用原则", 1);
        yield return new WaitForSeconds(1);
        CaptionManager.Instance.ShowSubtitle("迪米特法则", 1);

        yield return new WaitForSeconds(2);
        GameOver();
    }
}
