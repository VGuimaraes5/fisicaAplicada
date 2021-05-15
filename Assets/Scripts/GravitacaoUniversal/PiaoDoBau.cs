using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiaoDoBau : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_VelocityAngular;

    private Vector3 m_Rotation;

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        m_Rotation = m_VelocityAngular * Time.fixedDeltaTime;
        transform.Rotate(m_Rotation, Space.Self);
    }
}
