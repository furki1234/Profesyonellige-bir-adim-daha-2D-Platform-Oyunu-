using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TankController : MonoBehaviour
{

    public AtesEtmeController atesEtmeController;
    public enum TankDurumlari {AtesEtme,DarbeAlma,HareketEtme,Bekleme };
    public TankDurumlari gecerliDurum;

    [SerializeField]
    Transform tankObje;

    public Animator tankAnim;
    public GameObject tankEziciKutu;


    [Header("Hareket")]
    public float moveSpeed;
    public Transform solHedef, sagHedef;
    bool yonuSagmi;
    public GameObject mayinObje;
    public Transform mayinMerkezNoktasi;
    public float mayinBirakmaSuresi, mayinBýrakmaSuresiArtir;
    float mayinBirakmaSayaci;

    [Header("AtesEtme")]
    public GameObject mermi;
    public Transform mermiMerkezi;
    public float mermiAtmaSuresi, mermiAtmaSuresiArtir;
    float mermiAtmaSayaci;

    [Header("CanDurumu")]
    public int Health = 5;
    public GameObject tankBoomEfffect;
    public bool yenildimi;
        

    [Header("Darbe")]
    public float darbeSuresi;
    float darbeSayaci;

    MayinController mayinController;


    private void Awake()
    {
            mayinController = Object.FindObjectOfType<MayinController>();  
    }
    private void Start()
    {
        gecerliDurum = TankDurumlari.Bekleme;
    }





    

    private void Update()
    {

        

        switch (gecerliDurum)
        {

            
            case TankDurumlari.AtesEtme:
                //ateþ edildiði zaman
                mermiAtmaSayaci -= Time.deltaTime;
                

                if (mermiAtmaSayaci <= 0)
                {
                    mermiAtmaSayaci = mermiAtmaSuresi;

                   var yeniMermi = Instantiate(mermi, mermiMerkezi.position, mermiMerkezi.rotation);
                    yeniMermi.transform.localScale = tankObje.localScale;
                    SoundController.instance.sesEfektiCikarFNC(3);
                    
                }
                tankEziciKutu.SetActive(true);
                break;

            case TankDurumlari.DarbeAlma:
                //darbe alýndýðý zaman

                if (darbeSayaci > 0)
                {
                  darbeSayaci -= Time.deltaTime;

                    if (darbeSayaci <= 0)
                    {
                        
                        gecerliDurum = TankDurumlari.HareketEtme;
                        mayinBirakmaSayaci = mayinBirakmaSuresi;

                        if (yenildimi)
                        {
                            gameObject.SetActive(false);
                            Instantiate(tankBoomEfffect, tankObje.position, tankObje.rotation);
                        }
                    }
                }


                break;

            case TankDurumlari.HareketEtme:
                //tank hareket ettiði zaman

                if (yonuSagmi)
                {
                    tankObje.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (tankObje.position.x > sagHedef.position.x)
                    {
                        yonuSagmi = false;
                        tankObje.localScale = Vector3.one;
                        StopMovingFNC();
                        
                    }
                    
                }
                else
                {
                    tankObje.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (tankObje.position.x < solHedef.position.x)
                    {
                        yonuSagmi = true;
                        tankObje.localScale = new Vector3(-1, 1, 1);
                        StopMovingFNC();
                        
                    }
                }
                mayinBirakmaSayaci -= Time.deltaTime;

                if (mayinBirakmaSayaci <= 0)
                {
                    
                    mayinBirakmaSayaci = mayinBirakmaSuresi;

                    Instantiate(mayinObje,mayinMerkezNoktasi.position,mayinMerkezNoktasi.rotation);
                }


                break;
                
        }

        
    }

    public void DarbeAlFNC()
    {
        
        gecerliDurum = TankDurumlari.DarbeAlma;
        darbeSayaci = darbeSuresi;
        tankAnim.SetTrigger("Hit");
        SoundController.instance.sesEfektiCikarFNC(2);

        MayinController[] mayinlar = FindObjectsOfType<MayinController>();

        if (mayinlar.Length > 1)
        {
            foreach (MayinController bulunanMayin in mayinlar)
            {

                bulunanMayin.PatlamaFNC();
            }
        }

        Health--;

        if (Health <= 0)
        {
            yenildimi = true;
            SoundController.instance.sesEfektiCikarFNC(10);
        }
        else
        {
            mermiAtmaSuresi /= mermiAtmaSuresiArtir;
            mayinBirakmaSuresi /= mayinBýrakmaSuresiArtir;
        }
    }

    public void AtesEtFNC()
    {
        gecerliDurum = TankDurumlari.DarbeAlma;
        darbeSayaci = darbeSuresi;
        tankAnim.SetTrigger("Hit");
        SoundController.instance.sesEfektiCikarFNC(2);
        tankEziciKutu.SetActive(false);
        MayinController[] mayinlar = FindObjectsOfType<MayinController>();

        if (mayinlar.Length > 1)
        {
            foreach (MayinController bulunanMayin in mayinlar)
            {

                bulunanMayin.PatlamaFNC();
            }
        }
    }
    public void StopMovingFNC()
    {
        gecerliDurum = TankDurumlari.AtesEtme;
        mermiAtmaSayaci = mermiAtmaSuresi;
        tankAnim.SetTrigger("stopMoving");
    }
}
