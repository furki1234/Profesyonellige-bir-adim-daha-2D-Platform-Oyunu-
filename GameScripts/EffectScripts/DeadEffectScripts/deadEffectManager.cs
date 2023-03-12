using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadEffectManager : MonoBehaviour
{
    [SerializeField]
    float yasamaSuresi;



    void Start()
    {
        Destroy(gameObject, yasamaSuresi);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
