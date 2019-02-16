using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour {

    private float speed = 0;
    public GameObject canvas;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        speed += 0.001f;
        Camera.main.fieldOfView += 0.001f + speed;

        if (Camera.main.fieldOfView >= 179) {

            SceneManager.LoadScene("battleScene");

        }

    }
}
