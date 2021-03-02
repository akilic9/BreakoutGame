using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloooock : MonoBehaviour
{
    [SerializeField] AudioClip blockbreakSound; //breaking sound effect
    [SerializeField] GameObject blockVFX;  //breaking particle effect
    [SerializeField] Sprite[] breakLevels;
    int maxHits; //max number of hits a block can take

    [SerializeField] int timesHit; //serialized for debug purposes

    LevelUpdate lev;
    GameState state;


    private void Start()
    {
        lev = FindObjectOfType<LevelUpdate>();
        state = FindObjectOfType<GameState>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsBlockDestroyed();
    }

    private void IsBlockDestroyed()
    {
        maxHits = breakLevels.Length;
        if (tag == "BreakableBlock")
        {
            timesHit++; //increment hit counter if the block is a breable one
            if (timesHit >= maxHits) //destroy the block if it took max number of hits it can or more
            {
                BlockDestroyed();
            }
            else
            {
                ShowNextBreakLevel();
            }
        }
    }

    private void ShowNextBreakLevel()
    {
        if (timesHit <= breakLevels.Length)
        {
            GetComponent<SpriteRenderer>().sprite = breakLevels[timesHit];
        }
    }

    private void BlockDestroyed()
    {
        AudioSource.PlayClipAtPoint(blockbreakSound, Camera.main.transform.position); //play block's destroy sound
        Destroy(gameObject);  //destroy the block
        lev.BlockCounter();  //call the block counter method
        state.ScoreWriter();  //call the score counter method
        Sparkle();  //play the block destroy VFX
    }

    private void Sparkle()
    {
        GameObject cloneVFX = Instantiate(blockVFX, transform.position, transform.rotation); //instantiate VFX
        Destroy(cloneVFX, 2f); //destroy the object after 2 seconds
    }

}
