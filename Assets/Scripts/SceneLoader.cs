using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start() {
        Invoke("LoadFirstLevel", 2f);
    }
    void Update() {

    }

    void LoadFirstLevel() {
        SceneManager.LoadScene(1);
    }
}
