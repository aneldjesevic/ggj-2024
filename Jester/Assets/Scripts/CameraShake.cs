using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains;
using MoreMountains.Feedbacks;

public class CameraShake : MonoBehaviour
{
    MMFeedbacks feel;
    void Start()
    {
        feel = GetComponent<MMFeedbacks>();
    }

    public void ShakeCamera()
    {
        feel.PlayFeedbacks();
    }
}
