using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using SpatialSys.UnitySDK;
using UnityEngine.PlayerLoop;

namespace CreatorToolkitCustomScripts
{
    public class FollowCam : MonoBehaviour
    {
        CinemachineVirtualCamera vcam;
        void Awake()
        {
            vcam = GetComponent<CinemachineVirtualCamera>();

            // Check to make sure the avatar is loaded before setting Follow target
            if (SpatialBridge.actorService.localActor.avatar.isBodyLoaded)
            {
                SetCameraFollow();
            }

            // Spatial allows users to change their avatars, which can cause the initial Follow target
            // to be destroyed. We have to set it again once new avatar is loaded
            SpatialBridge.actorService.localActor.avatar.onAvatarLoadComplete += SetCameraFollow;
        }

        void OnDestroy()
        {
            SpatialBridge.actorService.localActor.avatar.onAvatarLoadComplete -= SetCameraFollow;
        }

        void SetCameraFollow()
        {
            // Set the Follow target to the chest of the player's avatar
            vcam.Follow = SpatialBridge.actorService.localActor.avatar.GetAvatarBoneTransform(HumanBodyBones.Chest);
        }
    }
}
