using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehavior : MonoBehaviour
{
    public int x;
    public Rigidbody2D rb;
    public Vector2 where = new Vector2(5,1);
    public bool setup_done = false;
    public int hits = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        rb = GetComponent<Rigidbody2D>();
        //GetComponent<Renderer>().enabled = false;
        rb.transform.position = new Vector2(-15,20);
    }
    public void Setup(Vector2 dir) {
        where = dir;
        where.y += 5 + Mathf.Abs(where.x)/4;
        float correction = where.y/16;
        correction *= correction;
        where.y += (10-where.x)/6 * correction;
        where.x *=(float)1.5;
        // low Y, overshoots, high Y, undershoots
        where.y += correction*2;
        //Debug.Log(where.y);
        setup_done = true;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (x%2 == 0) {
            Vector3 v = new Vector3(rb.transform.position.x+rb.velocity.x,rb.transform.position.y+rb.velocity.y,0);
            transform.right = v - transform.position;
        }
        //if (x%10 == 0) {
        //    Debug.Log(transform.position);
        //}
        if (setup_done) {
            if (x==0) {
                GetComponent<Renderer>().enabled = true;
                rb.velocity = where;
                rb.transform.position = new Vector2(-6,-2);
                
                Vector3 v3 = new Vector3(rb.transform.position.x+rb.velocity.x,rb.transform.position.y+rb.velocity.y,0);
                transform.right = v3 - transform.position;
                //Debug.Log("Value when sent:",where);
            }
            x+=1;
        }
        
        if (x>500) {Debug.Log("ERROR: PROJECTILE EXISTS TOO LONG");}
        //Debug.Log(rb.transform.position.y);
        if (rb.transform.position.y < -5) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
	    //Debug.Log("Knife has made contact with something");
        // do nothing (at least for now)
        //Debug.Log(col.name);
        /*
        bool already_hit = false;
        for (int i = 0; i < 5; i += 1) {
           if (col.GetInstanceID() == collided[i]) {
                already_hit = true;
                break;
            }
        }
        if (!already_hit) {*/
            hits += 1;
            /*
            collided[arr_c] = col.GetInstanceID();
            arr_c+=1;
            if (arr_c >= 5) {
                arr_c = 0;
            }
            //Debug.Log(collided);
        } else {
            Debug.Log("Not hitting again");
        }*/
    }
}
