using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallControl : MonoBehaviour
{
    [SerializeField]
    private GameObject m_RespawnPoint;

    [SerializeField]
    private GameObject m_LBlocker;

    [SerializeField]
    private GameObject m_RBlocker;
    
    [SerializeField]
    public int m_lives;

    [SerializeField]
    private TextMeshProUGUI livesText = null;

    private Rigidbody m_rbBall = null;

    void Start()
    {
        //m_lives = 3;
        livesText.text = m_lives.ToString();
        m_rbBall = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetPos"))
        {
            LivesLeft();
            BallRespawn(other);
        }

        if(other.CompareTag("BlockerTrigger"))
        {
            RaiseBlockers();
        }
    }

    private void BallRespawn(Collider other)
    {
        if(other.CompareTag("ResetPos") && m_lives!= 0)
        {
            m_rbBall.position = m_RespawnPoint.transform.position;
            m_LBlocker.transform.position = new Vector3(m_LBlocker.transform.position.x, 1.27f, 2.39f);
            m_RBlocker.transform.position = new Vector3(m_RBlocker.transform.position.x, 1.27f, 2.39f);
        }
        else
        {
            Debug.Log("Game Over!");
        }
    }

    private void RaiseBlockers()
    {
        m_LBlocker.transform.position = new Vector3(m_LBlocker.transform.position.x, 1.639f, 2.329f);
        m_RBlocker.transform.position = new Vector3(m_RBlocker.transform.position.x, 1.639f, 2.329f);
    }

    private void LivesLeft()
    {
        if (m_lives == 0)
        {
            m_lives = 0;
            livesText.text = m_lives.ToString();
            Debug.Log("No more lives left!");
        }
        else
        {
            m_lives--;
            livesText.text = m_lives.ToString();
            Debug.Log("Life Lost!");
        }
    }
}