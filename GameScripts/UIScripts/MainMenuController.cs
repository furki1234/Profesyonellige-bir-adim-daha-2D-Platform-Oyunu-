using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuController : MonoBehaviour
{


    

    public string SceneName;

    public GameObject gameNameImg;
    public GameObject startButton, exitButton;
    public GameObject fadeScreen;
    private void Start()
    {
        StartCoroutine(StartGameRoutine());
    }
    IEnumerator StartGameRoutine()
    {
        yield return new WaitForSeconds(0.1f);

        gameNameImg.GetComponent<CanvasGroup>().DOFade(1, 0.5f);         

        yield return new WaitForSeconds(0.4f);
        startButton.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        startButton.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(0.4f);

        exitButton.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        exitButton.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }

    IEnumerator OpenGameRoutine()
    { 
        yield return new WaitForSeconds(0.1f);

        fadeScreen.GetComponent<CanvasGroup>().DOFade(1, 1f);

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneName);
        
        
    }

    public void StartGameFNC()
    {        
        StartCoroutine(OpenGameRoutine());
    }


    public void ExitGameFNC()
    {
        Application.Quit();
    }
}
