using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Threading;

public class UIController : MonoBehaviour
{
    [SerializeField]
    TMP_Text MucevherSayisi;

    public GameObject fadeScreen;

    IEnumerator OpenGameRoutine()
    {
        yield return new WaitForSeconds(0.01f);

        fadeScreen.GetComponent<CanvasGroup>().DOFade(0, 1);
    }

    private void Start()
    {
        fadeScreen.GetComponent<CanvasGroup>().alpha = 1.0f;
        StartCoroutine(OpenGameRoutine());
    }


    PlayerHealthController playerHealthController;
    LevelManager levelManager;

    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
        levelManager = Object.FindObjectOfType<LevelManager>();
    }

    [SerializeField]
    Image kalp1_Img, kalp2_Img, kalp3_Img;

    [SerializeField]
    Sprite doluKalp, yarimKalp, bosKalp;
    
    public void UpdateHealthFNC()
    {
        switch (playerHealthController.Health)
        {
            default:

                case 6:
                kalp1_Img.sprite = doluKalp;
                kalp2_Img.sprite = doluKalp;
                kalp3_Img.sprite = doluKalp;
                break;


                case 5:
                kalp1_Img.sprite = doluKalp;
                kalp2_Img.sprite = doluKalp;
                kalp3_Img.sprite = yarimKalp;
                break;


                case 4:
                kalp1_Img.sprite = doluKalp;
                kalp2_Img.sprite = doluKalp;
                kalp3_Img.sprite = bosKalp;
                break;


                case 3:
                kalp1_Img.sprite = doluKalp;
                kalp2_Img.sprite = yarimKalp;
                kalp3_Img.sprite = bosKalp;
                break;


                case 2:
                kalp1_Img.sprite = doluKalp;
                kalp2_Img.sprite = bosKalp;
                kalp3_Img.sprite = bosKalp;
                break;


                case 1:
                kalp1_Img.sprite = yarimKalp;
                kalp2_Img.sprite = bosKalp;
                kalp3_Img.sprite = bosKalp;
                break;


                case 0:
                kalp1_Img.sprite = bosKalp;
                kalp2_Img.sprite = bosKalp;
                kalp3_Img.sprite = bosKalp;
                break;
        } 
        
    }

    public void MucehverSayisiniGuncelleFNC()
    {
        MucevherSayisi.text = levelManager.ToplananMucevherSayisi.ToString();

        
    }


    public void OpenFadeScreen()
    {
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1f, 4.6f);
    }

    public void OpenFadeScreen_GameOver()
    {
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1f, 2f);
    }



   

}
