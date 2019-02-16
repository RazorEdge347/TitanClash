using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleIntro : MonoBehaviour {


    private int timer = 0;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;


    // Use this for initialization
    void Start () {

        cam2.SetActive(false);
        cam3.SetActive(false);

        //FadeOut
        var canvas = GameObject.Find("Canvas");
        var Canv = Instantiate(Resources.Load("SFX/FadeOut"), new Vector3(0, 0, 0), canvas.transform.rotation) as GameObject;
        Canv.transform.SetParent(canvas.transform, false);
        Canv.gameObject.GetComponent<FadeOut>().fadeSpeed = 0.01f;
    }
	
	// Update is called once per frame
	void Update () {

        timer++;

        if (timer == 120)
        {
            cam2.SetActive(true);
            cam1.SetActive(false);
            //FadeOut
            var canvas = GameObject.Find("Canvas");
            var Canv = Instantiate(Resources.Load("SFX/FadeOut"), new Vector3(0, 0, 0), canvas.transform.rotation) as GameObject;
            Canv.transform.SetParent(canvas.transform, false);
            Canv.gameObject.GetComponent<FadeOut>().fadeSpeed = 0.01f;
        }


        if (timer == 240)
        {
            cam3.SetActive(true);
            cam2.SetActive(false);

            //FadeOut
            var canvas = GameObject.Find("Canvas");
            var Canv = Instantiate(Resources.Load("SFX/FadeOut"), new Vector3(0,0,0), canvas.transform.rotation) as GameObject;
            Canv.transform.SetParent(canvas.transform, false);
            Canv.gameObject.GetComponent<FadeOut>().fadeSpeed = 0.005f;

        }



    }
}
