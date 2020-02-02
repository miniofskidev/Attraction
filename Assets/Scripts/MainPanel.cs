using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{

    public GameObject MenuPanel;
    public GameObject CreditsPanel;
    

    GameManager GM;

    private void Awake()
    {
        GM = GameManager.Instance;
        GM.OnStateChange += HandleOnStageChange;
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowMenu();
    }

    public void ShowCredits()
    {
        MenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    public void ShowMenu()
    {
        MenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    private void HandleOnStageChange()
    {
        GM.SetGameState(GameState.MAIN_MENU);
        Debug.Log("Sei su " + GM.gameState);
    }

    public void StartGame()
    {
        //GM.SetGameState(GameState.GAME);
        Application.LoadLevel("TestLevel");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
