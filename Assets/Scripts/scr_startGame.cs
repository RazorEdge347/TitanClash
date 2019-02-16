using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scr_startGame : MonoBehaviour {

    public GameObject canvas;
    public GameObject text;
    public GameObject image;
    public GameObject blackBar;
    private int img = 1;

    // Use this for initialization
    void Start () {
        text = GameObject.Find("storyText");
        image = GameObject.Find("storyImage");
        canvas = GameObject.Find("Canvas");
        getImage();
    }
	
	// Update is called once per frame
	void Update () {

        //CHANGE IMAGE
        if ((Input.GetKeyDown("return") || Input.GetMouseButtonDown(0)) && img<8)
        {
            img++;
            if (img >= 8) {
                var world = Instantiate(Resources.Load("intro00"), canvas.transform.position, canvas.transform.rotation) as GameObject;
                text.SetActive(false);
                image.SetActive(false);
                blackBar.SetActive(false);
            }
            createFadeOut();           
            getImage();
        }

    }


    void getImage()
    {
        if (img == 1) { image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Ilustrations/img_1");
            text.GetComponent<Text>().text = "Have life.. come by chance?";
            text.transform.localPosition = new Vector3(0, -115, 0);
            blackBar.transform.localPosition = new Vector3(0, -115, 0);
        };


        if (img == 2)
        {
            image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Ilustrations/img_1");
            text.GetComponent<Text>().text = "What are we meant to be?";
            text.transform.localPosition = new Vector3(0, -115, 0);
            blackBar.transform.localPosition = new Vector3(0, -115, 0);
        };


        if (img == 3) { image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Ilustrations/img_2");
            text.GetComponent<Text>().text = "Some people try to live to the fullest..";
            text.transform.localPosition = new Vector3(0,-550,0);
            blackBar.transform.localPosition = new Vector3(0, -460, 0);
        };


        if (img == 4) { image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Ilustrations/img_3");
            text.GetComponent<Text>().text = "Others... are busy spreading death, violence and devastation in the name of religion, to prove their might...";
            text.transform.localPosition = new Vector3(0, -345, 0);
            blackBar.transform.localPosition = new Vector3(0, -275, 0);
        };


        if (img == 5) { image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Ilustrations/img_4");
            text.GetComponent<Text>().text = "Nature being torn apart";
            text.transform.localPosition = new Vector3(0, -555, 0);
            blackBar.transform.localPosition = new Vector3(0, -465, 0);
        };


        if (img == 6) { image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Ilustrations/img_5");
            text.GetComponent<Text>().text = "and when its too late.. they start to realize how powerless they are";
            text.transform.localPosition = new Vector3(0, -350, 0);
            blackBar.transform.localPosition = new Vector3(0, -260, 0);
        };

        if (img == 7)
        {
            image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Ilustrations/img_6");
            text.GetComponent<Text>().text = "And be desperate enough to believe to be protected from something greater!";
            text.transform.localPosition = new Vector3(0, -390, 0);
            blackBar.transform.localPosition = new Vector3(0, -300, 0);
        };

    }

    void createFadeOut()
    {
        //FadeOut
        var Canv = Instantiate(Resources.Load("SFX/FadeOut"), new Vector3(0, 0, 0), canvas.transform.rotation) as GameObject;
        Canv.transform.SetParent(canvas.transform, false);
        Canv.gameObject.GetComponent<FadeOut>().fadeSpeed = 0.01f;
        //Canv.transform.localPosition = new Vector3(canvas.transform.localPosition.x, canvas.transform.localPosition.y, canvas.transform.localPosition.z);
    }


}
