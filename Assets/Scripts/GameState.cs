using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{

    [Range(0.1f, 10f)] [SerializeField] float timeCoef;
    [SerializeField] int scorePerBlock, score;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayOn;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeCoef;
    }

    public int scoreKeeper()
    {
        score += scorePerBlock;
        return score;
    }

    public void ScoreWriter()
    {
        scoreText.text = scoreKeeper().ToString();
    }


    public void StatusDestroy()
    {
        Destroy(gameObject);
    }

    public bool GetAutoPlay()
    {
        return isAutoPlayOn;
    }
}
