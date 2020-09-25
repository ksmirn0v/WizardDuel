using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour {

    [SerializeField] private GameObject hitVFX;

    private void OnTriggerEnter2D(Collider2D anotherObject) {
        GameObject visualEffectObject = Instantiate(hitVFX, transform.position, transform.rotation);
        Destroy(visualEffectObject, 1f);
        Destroy(gameObject);

        WizardModel wizardModel = anotherObject.GetComponentInParent<WizardModel>();
        if (wizardModel && wizardModel.GetLives() > 0 && !wizardModel.isOwned) {
            int updatedLives = wizardModel.GetLives() - 1;
            wizardModel.SetLives(updatedLives);
        }
    }
}
