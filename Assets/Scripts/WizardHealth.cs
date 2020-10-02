using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class WizardHealth : MonoBehaviour {

    [SerializeField] private GameObject healthIndicatorPrefab;

    private GameObject healthIndicator;
    private Slider healthSlider;
    private Text playerName;
    private WizardModel wizardModel;
    private Vector3 offset = new Vector3(0f, 30f, 0f);

    private void Awake() {
        healthIndicator = Instantiate(healthIndicatorPrefab);
        healthIndicator.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);
        healthSlider = healthIndicator.transform.GetComponent<Slider>();
        playerName = healthIndicator.transform.GetComponentInChildren<Text>();
        wizardModel = GetComponent<WizardModel>();
        wizardModel.OnPlayerNameChanged += SetPlayerName;
    }

    void Update() {
        healthIndicator.transform.position = Camera.main.WorldToScreenPoint(wizardModel.transform.position) + offset;
        healthSlider.value = wizardModel.GetLives();
    }

    private void SetPlayerName(string value) {
        playerName.text = value;
    }
}
