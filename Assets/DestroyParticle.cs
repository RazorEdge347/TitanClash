using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {

    ParticleSystem effect;
	// Use this for initialization
	void Start () {
        effect = GetComponent<ParticleSystem>();	
	}
	
	// Update is called once per frame
	void Update () {

        if(effect.IsAlive() == false)
        {
            Destroy(gameObject);
        }

		
	}
}
