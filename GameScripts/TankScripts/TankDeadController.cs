using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDeadController : MonoBehaviour
{
    TankController tankController;


    private void Awake()
    {
        tankController = Object.FindObjectOfType<TankController>();
    }


    private void Update()
    {
        if(tankController.yenildimi == true)
        {
            Destroy(gameObject);
        }
    }
}
