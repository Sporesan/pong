using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class BallTouchWall : MonoBehaviour
{
    public GameObject PlayerScore;
    public GameObject BallObject;
    public GameObject TopRacket;
    public GameObject BottomRacket;
    private string score;
    private int score_no;
    Vector2 BallPos;
    Vector2 TopRacketPos;
    Vector2 BottomRacketPos;
    private void Start()
    {
        BallPos = BallObject.GetComponent<Rigidbody2D>().position;
        TopRacketPos = TopRacket.transform.position;
        BottomRacketPos = BottomRacket.transform.position;
    }

    private IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(5);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //If ball collides with wall
        //then add score to opposing player
        score = PlayerScore.GetComponent<TextMeshProUGUI>().text;
        score_no = int.Parse(score)+1;
        PlayerScore.GetComponent<TextMeshProUGUI>().text = score_no.ToString();
        //and reset positions
        BallObject.GetComponent<Rigidbody2D>().position = BallPos;
        TopRacket.transform.position = TopRacketPos;
        BottomRacket.transform.position = BottomRacketPos;
        //pause for 5 seconds
        waiter();
    }
}
