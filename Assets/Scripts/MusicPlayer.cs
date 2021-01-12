using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake() {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        print("Found " + numMusicPlayers + " MusicPlayer objects");
        if (numMusicPlayers > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

}
