using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField]
    private float m_fSpringConst = 0f;

    [SerializeField]
    private float m_OriginalPos = 0f;

    [SerializeField]
    private float m_PressedPos = 0f;

    [SerializeField]
    private float m_FlipperSpringDamp = 0f;

    [SerializeField]
    private KeyCode m_FlipperInput;

    private HingeJoint m_hingeJoint = null;

    private JointSpring m_jointSpring;

    private void Start()
    {
        m_hingeJoint = GetComponent<HingeJoint>();
        m_hingeJoint.useSpring = true;

        m_jointSpring = new JointSpring();
        m_jointSpring.spring = m_fSpringConst;
        m_jointSpring.damper = m_FlipperSpringDamp;

        m_hingeJoint.spring = m_jointSpring;
    }

    private void Update()
    {
        if (Input.GetKeyDown(m_FlipperInput))
        {
            OnFlipperPressedInternal();
        }

        if (Input.GetKeyUp(m_FlipperInput))
        {
            OnFlipperReleasedInternal();
        }
    }

    private void OnFlipperPressedInternal()
    {
        m_jointSpring.targetPosition = m_PressedPos;
        m_hingeJoint.spring = m_jointSpring;
    }

    private void OnFlipperReleasedInternal()
    {
        m_jointSpring.targetPosition = m_OriginalPos;
        m_hingeJoint.spring = m_jointSpring;
    }
}