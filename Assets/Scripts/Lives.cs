using Photon.Pun;
using UnityEngine;

public class Lives : MonoBehaviourPunCallbacks {

    [SerializeField] private int lives = 10;

    private Wizard wizard;

    private void Start() {
        wizard = GetComponentInParent<Wizard>();
    }

    public void SubtractLives() {
        lives--;
        if (lives <= 0) {
            wizard.TriggerDeath();
        }
    }

    public int GetLives() {
        return lives;
    }
}
