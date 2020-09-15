using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D target) {
        var livesComponent = target.GetComponent<Lives>();
        if (livesComponent) {
            livesComponent.SubtractLives();
        }
        Destroy(gameObject);
    }
}
