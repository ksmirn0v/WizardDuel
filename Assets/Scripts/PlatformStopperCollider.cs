using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStopperCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 8) {
            PlatformModel platformModel = collision.GetComponentInParent<PlatformModel>();
            platformModel.SetYVelocity(0.0f);
            StartCoroutine(SetVelocity(platformModel));
        }
    }

    private IEnumerator SetVelocity(PlatformModel platformModel) {
        yield return new WaitForSecondsRealtime(2.0f);
        if (platformModel.transform.position.y > 0.0f) {
            platformModel.SetYVelocity(-platformModel.verticalVelocity);
        } else {
            platformModel.SetYVelocity(platformModel.verticalVelocity);
        }
    }
}
