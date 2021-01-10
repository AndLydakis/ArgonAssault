using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    Time startTime;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    void Start() {
        Invoke("LoadFirstLevel", 2f);
    }

    // Update is called once per frame
    void Update() {

    }

    void LoadFirstLevel() {
        SceneManager.LoadScene(1);
    }
}
