using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]private float speed = 10f;
    [SerializeField] EnemySprites enemySprites;
    public  Transform[] targetPos;

    private int randomPos;

    
    
    private void Start()
    {
        //get the random sprite for the enemy

        GetComponent<SpriteRenderer>().sprite = MakeRandomEnemy(enemySprites.sprites);

        //getting random position around 2 
        randomPos = UnityEngine.Random.Range(0, targetPos.Length);
        
    }


    private void Update()
    {
        MoveEnemy();

    }
    Sprite MakeRandomEnemy(Sprite[] enemySprites)
    {
        int index = UnityEngine.Random.Range(0, enemySprites.Length);

        return enemySprites[index];
    }
    void MoveEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos[randomPos].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos[randomPos].position) < .3f)
        {
            randomPos = UnityEngine.Random.Range(0, targetPos.Length);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameHandler.instance.PlayerDied();
        }
    }


}
