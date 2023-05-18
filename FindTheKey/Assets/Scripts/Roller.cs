using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Roller : MonoBehaviour
{


    [SerializeField] private float rotationSpeed = 10f;
    void Update()
    {
        Spin();
        
    }

    void Spin()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameHandler.instance.PlayerDied();
        }
    }
}
