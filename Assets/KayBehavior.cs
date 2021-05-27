using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KayBehavior : MonoBehaviour
{
    public int x;
    public bool hasBeenChecked;
    public int timer;
    public bool fire;
    public Animator animator;
    public GameObject pfKnife;
    public Vector3 myPos = new Vector3(215,180,0);
    public AudioSource audiosource;
    public AudioSource audiosource2;
    public bool LastWas1 = false;
    public int powerupState = 0;
    public int[] numbers = new int[4];
    //public AudioClip throwKnife;
    // Start is called before the first frame update
    void Start()
    {
        myPos = new Vector3(215,180,0);
        timer = 0;
        hasBeenChecked = false;
        x = 0;
        AudioSource[] temp = GetComponents<AudioSource>();
        audiosource = temp[0];
        audiosource2 = temp[1];

        //audiosource2 = GetComponent<AudioSource>();
        numbers[0] = 17; // throw animation time normal
        numbers[1] = 9; // throw animation time fast
        numbers[2] = 10; // time knife leaves hand normally
        numbers[3] = 5;
        animator.SetInteger("PowerupState",powerupState);
    }

    void Update() {
        if (!fire || hasBeenChecked) {
            fire = Input.GetKey(KeyCode.Space);
	        hasBeenChecked = false;
        } 
    }

    // Update is called once per frame
    void FixedUpdate() {
        hasBeenChecked = true;
        //if (x%10 == 0) {
        //    Debug.Log(timer);
        //}
        x+=1;


        if (fire) {
            animator.SetInteger("Throwing",1);
            if (timer<1) {
                timer = numbers[powerupState];
            }
        }
        // OLD NUMBERS: Timer is set to 33, lauch at frame 18
        if (timer == numbers[2+powerupState]) {
            Vector3 mousePos = Input.mousePosition - myPos;
            //Debug.Log(Input.mousePosition);
            //Debug.Log(myPos);
            float speed = Mathf.Abs(mousePos.x) + Mathf.Abs(mousePos.y);
            //Debug.Log(speed);
            mousePos.Normalize();
            speed = speed/70 + 4;
            GameObject knife = Instantiate(pfKnife, new Vector3(-9,0,0),Quaternion.identity);
            //projectile.rb.velocity = new Vector2(-3,0);//direction * speed;
            knife.GetComponent<KnifeBehavior>().Setup(mousePos*speed);
            if (LastWas1) {
                audiosource2.Play();
                LastWas1 = false;
            } else {
                audiosource.Play();
                LastWas1 = true;
            } 
        }
        
        timer -= 1;
        
        if (timer == 0) {
            animator.SetInteger("Throwing",0);
        }
    }
}

/*
                float height = mousePos.y;
                float grav = (float)-19.6;
                float vCalc = 0;
                float t = 0;
                float coefficient = (float).2;//10/1100;
                while (height > 0) {
                    vCalc += grav;
                    height += vCalc;
                    t+=1;
                }
                // try to correct rounding errors
                //float overshoot =-(height / vCalc);
                float overshoot = 0;
                //vCalc += overshoot * vCalc;
                vCalc *= -1;
                float xSpd = mousePos.x/(t+overshoot);
                Vector2 v = new Vector2(xSpd*coefficient,vCalc*coefficient);
                if ( mousePos.y <= 0) {
                    v = mousePos*speed;
                    v.y += 4 + Mathf.Abs(v.x)/4;
                }
                Debug.Log(v);
                knife.GetComponent<KnifeBehavior>().Setup(v);
                */