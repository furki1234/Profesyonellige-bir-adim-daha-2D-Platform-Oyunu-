using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public int ToplananMucevherSayisi;

    public static LevelManager levelManager;
    public string sceneName;
    public GameObject fadeScreen;

    PlayerController playerController;
    UIController uiController;

    private void Awake()
    {
        levelManager = this;


        playerController = Object.FindObjectOfType<PlayerController>();
        uiController = Object.FindObjectOfType<UIController>();
    }

    public void FinishScene()
    {
        StartCoroutine(FinishSceneRoutine());
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator FinishSceneRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        playerController.hareketEtsinmi = false;
        yield return new WaitForSeconds(0.5f);
        uiController.OpenFadeScreen();
        yield return new WaitForSeconds(4.6f);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        playerController.hareketEtsinmi = false;
        yield return new WaitForSeconds(0.5f);
        uiController.OpenFadeScreen_GameOver();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneName);
    }
}
