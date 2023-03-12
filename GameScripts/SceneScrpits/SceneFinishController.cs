using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFinishController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundController.instance.GameWin();
            LevelManager.levelManager.FinishScene();
        }
    }
    

}
