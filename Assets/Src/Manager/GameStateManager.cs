using UnityEngine;
using System.Collections;

public enum eGameState
{
    GAME_STATE_START_SCREEN,
    GAME_STATE_PLAYING,
    GAME_STATE_GAME_OVER
}

public enum ePlayState
{
    PLAY_STATE_STARTUP,
    PLAY_STATE_WAVE,
    PLAY_STATE_IN_BETWEEN_WAVES
}

public class GameStateManager : Singleton<GameStateManager>
{
    GameStateManager() { }
    private eGameState m_state = eGameState.GAME_STATE_START_SCREEN;
    private ePlayState m_playState = ePlayState.PLAY_STATE_STARTUP;

    public eGameState GameState
    {
        get { return m_state; }
        set { m_state = value; }
    }

    public ePlayState PlayState
    {
        get { return m_playState; }
        set { m_playState = value; }
    }
}
