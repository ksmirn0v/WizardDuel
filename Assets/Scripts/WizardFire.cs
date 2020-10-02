using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardFire : MonoBehaviour {

    [SerializeField] private GameObject weaponObject;
    [SerializeField] private Transform mainTransform;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private AudioClip soundEffect;

    public void Fire() {
        GameObject weapon = Instantiate(weaponObject, spawnTransform.position, spawnTransform.rotation);
        WeaponModel weaponModel = weapon.transform.GetComponent<WeaponModel>();
        weaponModel.xVelocity = mainTransform.localScale.x * weaponModel.horizontalVelocity;
        AudioSource.PlayClipAtPoint(soundEffect, Camera.main.transform.position, 0.5f);
    }
}
