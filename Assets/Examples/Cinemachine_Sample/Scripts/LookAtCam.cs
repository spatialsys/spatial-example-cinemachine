using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;
using Cinemachine;
[RequireComponent(typeof(CinemachineVirtualCamera))]
public class LookAtCam : MonoBehaviour
{
    CinemachineVirtualCamera vcam;
    void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();

        // Check to make sure the avatar is loaded before setting LookAt target
        if (SpatialBridge.actorService.localActor.avatar.isBodyLoaded)
        {
            SetCameraLookAt();
        }

        // Spatial allows users to change their avatars, which can cause the initial LookAt target
        // to be destroyed. We have to set it again once new avatar is loaded
        SpatialBridge.actorService.localActor.avatar.onAvatarLoadComplete += SetCameraLookAt;
    }

    void OnDestroy()
    {
        SpatialBridge.actorService.localActor.avatar.onAvatarLoadComplete -= SetCameraLookAt;
    }

    void SetCameraLookAt()
    {
        // Set the LookAt target to the chest of the player's avatar
        vcam.LookAt = SpatialBridge.actorService.localActor.avatar.GetAvatarBoneTransform(HumanBodyBones.Chest);
    }
}
