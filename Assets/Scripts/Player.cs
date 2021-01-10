using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("m/s")] [SerializeField] float xSpeed = 4f;
    [Tooltip("m/s")] [SerializeField] float ySpeed = 4f;
    [SerializeField] float xLimit = 4f;
    [SerializeField] float yLimit = 4f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    [SerializeField] float yawLimit = 0.1f;

    [SerializeField] float rollLimit = 0.1f;

    float xThrow, yThrow;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
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
}
