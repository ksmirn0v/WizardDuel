using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour {

    [SerializeField] private GameObject hitVFX;

    private void OnTriggerEnter2D(Collider2D anotherObject) {
        WizardModel wizardModel = anotherObject.GetComponent<WizardModel>();
        if (wizardModel) {
            wizardModel.lives--;
        }

        GameObject visualEffectObject = Instantiate(hitVFX, transform.position, transform.rotation);
        Destroy(visualEffectObject, 1f);
        Destroy(gameObject);
    }
}
