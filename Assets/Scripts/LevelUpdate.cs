using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpdate : MonoBehaviour
{
    public int brBlocks;
    SceneLoader scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = FindObjectOfType<SceneLoader>();
        GameObject[] blocksArray = GameObject.FindGameObjectsWithTag("BreakableBlock");
        brBlocks = blocksArray.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            scene.QuitGame();
        }

    }

    public void BlockCounter()
    {
        brBlocks--;
        if(brBlocks <= 0)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        LevelUp();
    }

    public void LevelUp()
    {
        scene.LoadNextScene();
    }
}