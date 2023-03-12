using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesEtmeController : MonoBehaviour
{
    public bool oyuncugoruldu;
     

    public TankController tankController;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& !oyuncugoruldu)
        {
            tankController.AtesEtFNC();
            oyuncugoruldu = true;
        }
    }
}
