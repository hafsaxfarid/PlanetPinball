using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText = null;

    private int score = 0;

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        addScore(collision);
    }

    // keeps track of total score
    void addScore(Collision other)
    {
        // compares the balls tag to that of target tag
        if (other.gameObject.name == "BumperA" ||
            other.gameObject.name == "BumperA1"||
            other.gameObject.name == "BumperA2" )
        {
            score += 100;
            scoreText.text = score.ToString();
            Debug.Log("Hit Active Bumper!");
        }
        else
        {
            // displays total score
            scoreText.text = score.ToString();
        }

        if (other.gameObject.name == "BumperP" ||
            other.gameObject.name == "BumperP1"||
            other.gameObject.name == "BumperP2" )
        {
            score += 10;
            scoreText.text = score.ToString();
            Debug.Log("Hit Passive Bumper!");
        }
        else
        {
            // displays total score
            scoreText.text = score.ToString();
        }
    }
}
