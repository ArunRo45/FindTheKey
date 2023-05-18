using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public GameObject hiddenPlatform;
    public void SetHiddenPlatform()
    {
        hiddenPlatform.SetActive(true);
    }
}
