using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

namespace CreatorToolkitCustomScripts
{
    [RequireComponent(typeof(Slider))]
    public class PrioritySlider : MonoBehaviour
    {
        public CinemachineVirtualCamera lookAtCam;
        public CinemachineVirtualCamera dollyCam;
        public CinemachineVirtualCamera followCam;
        public TextMeshProUGUI priorityText;
        Slider slider;
        void Start()
        {
            slider = GetComponent<Slider>();
            slider.onValueChanged.AddListener(HandleOnValueChanged);
        }

        void HandleOnValueChanged(float value)
        {
            lookAtCam.Priority = (int)value;
            dollyCam.Priority = (int)value;
            followCam.Priority = (int)value;
            priorityText.text = $"{(int)value}";
        }
    }
}
