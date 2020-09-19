using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour {

    [SerializeField] private GameObject hitVFX;

    private void OnTriggerEnter2D(Collider2D anotherObject) {
        WizardModel wizardModel = anotherObject.GetComponentInParent<WizardModel>();
        if (wizardModel) {
            wizardModel.lives--;
            if (wizardModel.lives < 0) {
                wizardModel.isAlive = false;
            }
        }

        GameObject visualEffectObject = Instantiate(hitVFX, transform.position, transform.rotation);
        Destroy(visualEffectObject, 1f);
        Destroy(gameObject);
    }
}
