using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MainMenu,
    InGame,
    Pause,
    GameOver
}

public class EnumExaple : MonoBehaviour
{
    public GameState currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.MainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == GameState.MainMenu)

        {
            //Hien thi UI Menu  
        }
        else if(currentState == GameState.InGame)
        {
            //an main menu
        }
    }
}
