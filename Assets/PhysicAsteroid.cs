using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicAsteroid : MonoBehaviour {


    Vector3 position;
    Rigidbody2D AsteroidP;
    float angv;
    float lineardrag;
    Vector2 direction;
    float mass;
    public GameObject go;
    ParticleSystem Trail_projectile;
    public GameObject PlayerShoot;
    // Use this for initialization
    void Start () {

        position = transform.position;
        AsteroidP = GetComponent<Rigidbody2D>();
        angv = AsteroidP.angularVelocity;
        lineardrag = AsteroidP.drag;
        mass = AsteroidP.mass;
        

        float radiants = 0;
        while (radiants == 0)
        {
            radiants = Random.Range(0, 2 * Mathf.PI);
        }
        direction = new Vector2(Mathf.Cos(radiants), Mathf.Sin(radiants));

        direction.Normalize();

        //AsteroidP.AddForce(direction * 1500);    
    }
	
	// Update is called once per frame
	void Update () {
        //print("Velocity of Game Object "+gameObject.name+":"+ AsteroidP.velocity.magnitude);
        if (Input.GetKeyDown(KeyCode.Keypad1)){
            AsteroidP.velocity = Vector3.zero;
            AsteroidP.AddForce(direction * 1500);
        }

                 
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag){
            case "Projectile":
                float ObjectVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;

                if (AsteroidP.velocity.magnitude > ObjectVelocity && AsteroidP.velocity.magnitude > 15f)
                {
                    Destroy(collision.gameObject);
                    Instantiate(go, collision.gameObject.transform.position, collision.gameObject.transform.rotation);


                }; break;

            case "Player":
                if (collision.gameObject != PlayerShoot)
                {
                    if (AsteroidP.velocity.magnitude > 2f)
                    {
                        collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

                        if (collision.gameObject.GetComponent<PlayerController>() == null)
                            collision.gameObject.GetComponent<PlayerController2>().DamageOutput(AsteroidP.velocity);
                        else
                            collision.gameObject.GetComponent<PlayerController>().DamageOutput(AsteroidP.velocity);
                    }
                }

                else
                {
                    if (AsteroidP.velocity.magnitude > 2f)
                    {
                        collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                        print("You're taking the damage prick");

                        if (collision.gameObject.GetComponent<PlayerController>() == null)
                            collision.gameObject.GetComponent<PlayerController2>().DamageOutput(AsteroidP.velocity);
                        else
                            collision.gameObject.GetComponent<PlayerController>().DamageOutput(AsteroidP.velocity);
                    }
                }
                break;

        }
    }
}
