using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxHorizontal : MonoBehaviour {


    public float power=0;
    public GameObject PlayerShoot;
    public float timelimit = 1f;
    float time = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        float seconds = time % 60;

        print("Limit :" + timelimit + " Time:" + seconds);
        if (Mathf.Floor(timelimit) == Mathf.Floor(seconds))
        {
            print("Come on dude");
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            col.gameObject.GetComponent<PhysicAsteroid>().PlayerShoot = PlayerShoot;
            float radiants = 0;
            while (radiants == 0)
            {
                radiants = 2 * Mathf.PI;
            }
            var direction = new Vector2(Mathf.Cos(radiants), Mathf.Sin(radiants));
            direction.Normalize();
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 500 * power);
            print("colisao da pissa");
            Destroy(gameObject);
        }

    }

}
