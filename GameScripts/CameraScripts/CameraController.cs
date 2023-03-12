using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform targetTransform;

    [SerializeField]
    float minY, maxY;


    [SerializeField]
    float minX, maxX;


    [SerializeField]
    float gameFinishMaxX;

    [SerializeField]
    Transform altZemin, ortaZemin;
    public bool tankOldumu;


    TankController tankController;

    Vector2 sonPos;


    private void Awake()
    {
            tankController = Object.FindObjectOfType<TankController>();
    }


    private void Start()
    {
        sonPos = transform.position;
    }
    private void Update()
    {

        
        CameraMoveFNC();
        placeMoveFNC();
        
    }

    void CameraMoveFNC()
    {
        if (tankController.yenildimi)
        {
            transform.position = new Vector3(Mathf.Clamp(targetTransform.position.x, minX, gameFinishMaxX), Mathf.Clamp(targetTransform.position.y, minY, maxY), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(Mathf.Clamp(targetTransform.position.x,minX,maxX), Mathf.Clamp(targetTransform.position.y, minY, maxY), transform.position.z);
        }

    }
    void placeMoveFNC()
    {
        Vector2 aradakiMiktar = new Vector2(transform.position.x - sonPos.x, transform.position.y - sonPos.y);

        altZemin.position += new Vector3(aradakiMiktar.x, aradakiMiktar.y, 0f);
        ortaZemin.position += new Vector3(aradakiMiktar.x, aradakiMiktar.y, 0f)*0.7f;

        sonPos = transform.position;
    }

}

