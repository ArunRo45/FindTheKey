using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    private MovingPlatform _movingPlatform;


    private void Start()
    {
        _movingPlatform = FindObjectOfType<MovingPlatform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player":
                _movingPlatform.IsPressureOccured = true;
                break;
            case "Crate":
                _movingPlatform.IsPressureOccured = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player":
                _movingPlatform.IsPressureOccured = false;
                break;
            case "Crate":
                _movingPlatform.IsPressureOccured = false;
                break;
        }
    }
}
