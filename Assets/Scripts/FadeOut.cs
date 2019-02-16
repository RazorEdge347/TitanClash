using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class FadeOut : MonoBehaviour {

    public Image image;
    private float fade;
    public float fadeSpeed;

	// Use this for initialization
	void Start () {

        image = GetComponent<Image>();
        fade = 1f;
        //fadeSpeed = 0;
    }
	
	// Update is called once per frame
	void Update () {
        fade -= fadeSpeed;
        image.color = new Color(0, 0, 0, fade);

        if (fade <= 0)
        {
            Destroy(gameObject);
        }
    }
}
