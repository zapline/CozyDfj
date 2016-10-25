using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject PlayerObj;
    public GameObject EnemyObj;
    private enum eGameState
    {
        GAME_STATE_START_SCREEN,
        GAME_STATE_PLAYING,
        GAME_STATE_GAME_OVER
    }
    private eGameState m_state = eGameState.GAME_STATE_START_SCREEN;
    private enum ePlayState
    {
        PLAY_STATE_STARTUP,
        PLAY_STATE_WAVE,
        PLAY_STATE_IN_BETWEEN_WAVES
    }
    private ePlayState m_playState = ePlayState.PLAY_STATE_STARTUP;

    void Start()
    {
        CaptionManager.Instance.ShowTitle("按空格键开始游戏！", 100000);
    }

    void Update()
    {
        switch (m_state)
        {
            case eGameState.GAME_STATE_START_SCREEN:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine("enemyGenerator");
                    m_state = eGameState.GAME_STATE_PLAYING;
                }
                break;
            case eGameState.GAME_STATE_PLAYING:
                switch (m_playState)
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
                    StartCoroutine("enemyGenerator");
                    m_state = eGameState.GAME_STATE_PLAYING;
                }
                break;
        }
    }

    public void GameOver()
    {
        StopCoroutine("enemyGenerator");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var e in enemys)
            Destroy(e);
        m_state = eGameState.GAME_STATE_GAME_OVER;
        CaptionManager.Instance.ShowTitle("按空格键重新开始游戏！", 100000);
    }

    IEnumerator enemyGenerator()
    {
        CaptionManager.Instance.ShowTitle("第一章");
        CaptionManager.Instance.ShowSubtitle("设计模式概述");
        Instantiate(PlayerObj, new Vector2(0, -7), Quaternion.identity);

        yield return new WaitForSeconds(3.5f);
        for (int i = 0; i < 5; i++)
        {
            Vector2 spawnPosition = new Vector2(
                Random.Range(-2.0f, 2.0f),
                Random.Range(-2.0f, 2.0f));
            Instantiate(EnemyObj, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(3);
    }
}
