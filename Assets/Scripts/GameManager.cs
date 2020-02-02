using UnityEngine;
using System.Collections;

// Game States
// for now we are only using these two
public enum GameState { MAIN_MENU, GAME }

public delegate void OnStateChangeHandler();

public class GameManager
{
    protected GameManager() { }
    private static GameManager instance = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }
    public static int actualLevel = -1;

    public static GameManager Instance
    {
        get
        {
            if (GameManager.instance == null)
            {
                GameManager.instance = new GameManager();
            }
            return GameManager.instance;
        }

    }
    
    public void NextLevel()
    {
        Application.LoadLevel("level" + (++(actualLevel)));
    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }

    public void OnApplicationQuit()
    {
        GameManager.instance = null;
    }

}