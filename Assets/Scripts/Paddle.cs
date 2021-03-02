using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthUnit;
    [SerializeField] float minX, maxX;

    GameState state;
    Ball ball;
    
    // Start is called before the first frame update
    void Start()
    {
        state = FindObjectOfType<GameState>();
        ball = FindObjectOfType<Ball>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (state.GetAutoPlay())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthUnit;
        }
    }
}
