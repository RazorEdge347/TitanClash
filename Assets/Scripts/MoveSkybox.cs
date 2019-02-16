using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSkybox : MonoBehaviour
{

    float curRot = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        curRot += 1 * Time.deltaTime;
        curRot %= 360;
        RenderSettings.skybox.SetFloat("_Rotation", curRot);
    }
}
