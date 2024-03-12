using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace CreatorToolkitCustomScripts
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class DollyCam : MonoBehaviour
    {
        CinemachineVirtualCamera vcam;
        CinemachineTrackedDolly dolly;
        float speed = 0.2f;

        void Awake()
        {
            vcam = GetComponent<CinemachineVirtualCamera>();
            dolly = vcam.GetCinemachineComponent<CinemachineTrackedDolly>();
        }

        void Update()
        {
            float increment = speed * Time.deltaTime;
            if (dolly.m_PathPosition + increment < dolly.m_Path.MinPos || dolly.m_PathPosition + increment > dolly.m_Path.MaxPos)
            {
                speed *= -1;
            }
            dolly.m_PathPosition += speed * Time.deltaTime;
        }
    }
}
