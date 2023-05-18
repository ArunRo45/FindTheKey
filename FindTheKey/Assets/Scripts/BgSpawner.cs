using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawner : MonoBehaviour
{
    [SerializeField] private BGSprites _backGrounds;

    private void Start()
    {
        int randomIndex = Random.Range(0, _backGrounds.BgSprites.Length);

        Instantiate(_backGrounds.BgSprites[randomIndex], Vector3.zero, Quaternion.identity);
    }


}
