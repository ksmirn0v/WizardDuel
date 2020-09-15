using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    [SerializeField] private Text playerName;
    [SerializeField] private Slider playerHealth;

    private PlayerManager target;
    private Lives livesComponent;
    private Vector3 offset = new Vector3(0f, 30f, 0f);

    private void Awake() {
        this.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);
    }

    public void SetTarget(PlayerManager _target) {
        if (_target == null) {
            Debug.LogError("SetTarget() is called with null.");
            return;
        }

        target = _target;
        livesComponent = target.GetComponentInChildren<Lives>();
        if (playerName != null) {
            playerName.text = target.photonView.Owner.NickName;
        }
    }

    private void Update() {
        if (playerHealth != null) {
            playerHealth.value = livesComponent.GetLives();
        }
        if (target == null) {
            Destroy(this.gameObject);
            return;
        }
    }

    private void LateUpdate() {
        this.transform.position = Camera.main.WorldToScreenPoint(target.transform.position) + offset;
    }
}
