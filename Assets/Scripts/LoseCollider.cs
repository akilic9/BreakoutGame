using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    SceneLoader endGame;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        endGame = FindObjectOfType<SceneLoader>();
        endGame.GameOverScene();
    }

}
