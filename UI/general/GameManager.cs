    
//     using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// [DisallowMultipleComponent]
// public class GameManager : SingletonMonobehaviour<GameManager> {

//     [SerializeField] private GameObject pauseMenu;
//     [HideInInspector] public GameState gameState;
//     [HideInInspector] public GameState previousGameState;

//     private void Update()
//     {
//          HandleGameState();
//     }

//     private void HandleGameState()
//     {
//         switch (gameState)
//         {
//             case GameState.gameStarted:
//                   if (Input.GetKeyDown(KeyCode.Escape))
//                 {
//                     PauseGameMenu();
//                 }
//                 break;
//         }
//     }


//     public void PauseGameMenu()
//     {
//        if (gameState != GameState.gamePaused)
//        {
//            pauseMenu.SetActive(true);
//            GetPlayer().playerControl.DisablePlayer();

//            previousGameState = gameState;
//            gameState = GameState.gamePaused;
//        }
//        else if (gameState == GameState.gamePaused)
//        {
//            pauseMenu.SetActive(false);
//            GetPlayer().playerControl.EnablePlayer();

//            gameState = previousGameState;
//            previousGameState = GameState.gamePaused;
//        }
//    }
    
// }