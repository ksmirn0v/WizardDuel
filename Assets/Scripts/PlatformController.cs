using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    private PlatformModel platformModel;

    private void Start() {
        platformModel = GetComponent<PlatformModel>();
        platformModel.SetYVelocity(-platformModel.verticalVelocity);
    }
}
