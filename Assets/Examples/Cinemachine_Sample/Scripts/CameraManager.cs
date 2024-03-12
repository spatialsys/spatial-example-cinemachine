using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

namespace CreatorToolkitCustomScripts
{
    public class CameraManager : MonoBehaviour
    {
        enum VirtualCameraType { Dolly, LookAt, Follow, None }
        VirtualCameraType activeCam = VirtualCameraType.LookAt;
        public CinemachineVirtualCamera dollyCam;
        public CinemachineVirtualCamera lookAtCam;
        public CinemachineVirtualCamera followCam;

        public Button dollyButton;
        public Button lookAtButton;
        public Button followButton;
        public Button disableAll;
        void Start()
        {
            dollyButton.onClick.AddListener(SwitchToDolly);
            lookAtButton.onClick.AddListener(SwitchToLookAt);
            followButton.onClick.AddListener(SwitchToFollow);
            disableAll.onClick.AddListener(DisableAll);
        }
        void SwitchToDolly()
        {
            activeCam = VirtualCameraType.Dolly;
            UpdateCameras();

        }

        void SwitchToLookAt()
        {
            activeCam = VirtualCameraType.LookAt;
            UpdateCameras();

        }

        void SwitchToFollow()
        {
            activeCam = VirtualCameraType.Follow;
            UpdateCameras();

        }

        void DisableAll()
        {
            activeCam = VirtualCameraType.None;
            UpdateCameras();
        }

        void UpdateCameras()
        {
            dollyCam.enabled = activeCam == VirtualCameraType.Dolly;
            lookAtCam.enabled = activeCam == VirtualCameraType.LookAt;
            followCam.enabled = activeCam == VirtualCameraType.Follow;
        }
    }
}
