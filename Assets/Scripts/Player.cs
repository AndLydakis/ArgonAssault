using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("General")]
    [Tooltip("m/s")] [SerializeField] float xSpeed = 4f;
    [Tooltip("m/s")] [SerializeField] float ySpeed = 4f;
    [Tooltip("s")] [SerializeField] float levelLoadDealy = .5f;
    [SerializeField] float xLimit = 4f;
    [SerializeField] float yLimit = 4f;
    [Tooltip("FX prefab")] [SerializeField] GameObject deathFx;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    [SerializeField] float yawLimit = 0.1f;
    [SerializeField] float rollLimit = 0.1f;

    float xThrow, yThrow;
    bool controlsEnabled = true;
    void Start() {

    }
    void Update() {
        if (!controlsEnabled) return;
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessTranslation() {
        float xPos = Mathf.Clamp(transform.localPosition.x + xThrow * xSpeed * Time.deltaTime, -xLimit, xLimit);
        float yPos = Mathf.Clamp(transform.localPosition.y + yThrow * ySpeed * Time.deltaTime, -yLimit, yLimit);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    void ProcessRotation() {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void DisableControls() {
        controlsEnabled = false;
    }

    private void ReloadLevel() {
        SceneManager.LoadScene(1);
    }
    // called by string reference
    void OnPlayerDeath() {
        print("Player Death");
        DisableControls();
        deathFx.SetActive(true);
        Invoke("ReloadLevel", levelLoadDealy);

    }
}
