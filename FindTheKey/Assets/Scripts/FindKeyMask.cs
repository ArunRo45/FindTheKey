using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindKeyMask : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    

    private void Start()
    {
        mainCam = Camera.main;
        
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

}//class







































