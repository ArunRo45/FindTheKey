using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public bool isNormalMovingPlatform = true;
    [SerializeField] private float _speed = 5f;
    public Transform[] movingPlaces;

    int randomIndex;
    public bool IsPressureOccured { get; set; }


    private void Start()
    {
        IsPressureOccured = false;
        randomIndex = 0;//first move to the left side that is index 0[Moving Places]
    }

    private void Update()
    {
        if (isNormalMovingPlatform)
        {
            MovePlatform();
        }
        else if(IsPressureOccured)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        transform.position = Vector2.MoveTowards(transform.position, movingPlaces[randomIndex].position,
                    _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movingPlaces[randomIndex].position) < .2f)
        {
            if (randomIndex == 0)
                randomIndex = 1;
            else if (randomIndex == 1)
                randomIndex = 0;
            //Debug.Log(randomIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.activeInHierarchy)
            other.transform.SetParent(null);
    }
}


