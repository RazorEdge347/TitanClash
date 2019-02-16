using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class FadeIn : MonoBehaviour
{

    public Image image;
    public float fade;
    public float fadeSpeed;
    public float fadeDestroy; //Duração do Black Screen
    public bool changeScene; //Se é para mudar de cena (true || false)
    public int zone; //a zona/Scene (ID) em que vai mudar para, após atingir o valor de fadeDestroy

    // Use this for initialization
    void Start()
    {
        //changeScene = false;
        image = GetComponent<Image>();
        image.color = new Color(0, 0, 0, 0); // meter com 0 de Alpha (invisível)
        //fade = 0f;
        //fadeSpeed = 0.01f;
        //zone = 0;
        //fadeDestroy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fade += fadeSpeed;
        image.color = new Color(0, 0, 0, fade); //aumentar o Alpha

        if (changeScene == false && fade > fadeDestroy)
        { Destroy(gameObject); }
        else
            {
            if (changeScene == true && fade > fadeDestroy)
            {
            SceneManager.LoadScene(zone, LoadSceneMode.Single);
            }
        }

    }
}