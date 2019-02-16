using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;
    public int hp = 100;
    public float powerbar = 0;
    float velocityx = 0f;
    float velocityy = 0f;
    public float energy = 0;

    public Animator anim;

    //get UI
    public GameObject p1powerbar;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        velocityx = gameObject.GetComponent<Rigidbody2D>().velocity.x;
        velocityy = gameObject.GetComponent<Rigidbody2D>().velocity.y;

            //powerbar
            if (Input.GetKey("space"))
            {
                powerbar += 2;
                if (powerbar > 100) { powerbar = 0; }
            }

            if (Input.GetKeyUp("space"))
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Punch", true);

                //create hitbox
                var pos = new Vector3(transform.position.x + 2f, transform.position.y+2.5f, transform.position.z);
                var hitbox = Instantiate(Resources.Load("Hitboxes/hitboxHorizontal"), pos, transform.rotation) as GameObject;
                hitbox.gameObject.GetComponent<hitboxHorizontal>().power = 2 + (powerbar / 10);
                hitbox.gameObject.GetComponent<hitboxHorizontal>().PlayerShoot = gameObject;
                powerbar = 0;
            }
        

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 45f;
        }
        else
        {
           speed -= 2;
        }

        //refresh power bar visual
        p1powerbar.GetComponent<RectTransform>().sizeDelta = new Vector2((powerbar / 100f) * 550, 25);

        if (powerbar < 35) { p1powerbar.GetComponent<Image>().color = Color.green; }
        if (powerbar >= 35 && powerbar < 75) { p1powerbar.GetComponent<Image>().color = Color.yellow; }
        if (powerbar >= 75) { p1powerbar.GetComponent<Image>().color = Color.red; }


    }

    void FixedUpdate()
    {
        //movement
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Clamp(velocityx, 0f, 50f), Mathf.Clamp(velocityy, 0f, 50f));
        transform.position += move * Mathf.Clamp(speed, 10f, 45f) * Time.deltaTime;
    }

    public void DamageOutput(Vector2 velocity)
    {
        
        float speed = velocity.magnitude;
        int counter = 0;
        int counterhp = 0;

        while (counter < speed)
        {
            counterhp += 2;
            counter++;
        }

        hp = hp - counterhp;
        print(hp);
    }
}