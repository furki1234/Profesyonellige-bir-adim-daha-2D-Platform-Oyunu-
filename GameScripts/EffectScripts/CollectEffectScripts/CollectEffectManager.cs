using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEffectManager : MonoBehaviour
{
    [SerializeField]
    float YasamaSuresi;
    void Start()
    {
        Destroy(gameObject,YasamaSuresi);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
