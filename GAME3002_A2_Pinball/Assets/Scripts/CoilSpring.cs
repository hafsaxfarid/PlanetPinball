using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilSpring : MonoBehaviour
{
    [SerializeField]
    private float m_fSpringConstant = 0f;
    
    [SerializeField]
    private Vector3 m_fRestPosition;
    
    [SerializeField]
    private float m_fMass;
    
    [SerializeField]
    private Rigidbody m_attachedWeight;
    
    [SerializeField]
    private float m_fDampingConstant;

    [SerializeField]
    private KeyCode m_LaunchInput;

    private Vector3 m_vForce;
    private Vector3 m_vPrevVel;

    private Vector3 m_SpringLaunchingPos;
    private Vector3 m_SpringStartPos;

    private float speed = 2f;
    void Start()
    {
        m_fMass = m_attachedWeight.mass;
        m_attachedWeight.isKinematic = false;
        m_SpringStartPos = m_attachedWeight.transform.position;
    }

    private void FixedUpdate()
    {
        UpdateSpringForce();

        if(Input.GetKey(m_LaunchInput))
        {
            m_attachedWeight.transform.position = new Vector3(2.36f, 0.75f, -4.78f);
            m_attachedWeight.isKinematic = true;
        }

        if (Input.GetKeyUp(m_LaunchInput))
        {
            m_attachedWeight.isKinematic = false;
        }
    }

    private void UpdateSpringForce()
    {
        m_vForce = -m_fSpringConstant * (m_fRestPosition - m_attachedWeight.transform.position)
            - m_fDampingConstant * (m_attachedWeight.velocity - m_vPrevVel);

        m_attachedWeight.AddForce(m_vForce, ForceMode.Acceleration);

        m_vPrevVel = m_attachedWeight.velocity;
    }

    private void OnDrawGizmos()
    {

        Gizmos.DrawWireSphere(m_fRestPosition, 0.1f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(m_attachedWeight.transform.position, 0.1f);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, m_attachedWeight.transform.position);
    }
}
