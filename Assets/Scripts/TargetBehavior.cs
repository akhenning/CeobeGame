using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    Vector2 move;
    public int type;
    public int hp;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (type == 1) {
            //boss
            hp = 10;
            move = new Vector2((float)(Random.value+.2)/-25,0);
        } else {
            hp = 2;
            move = new Vector2((float)(Random.value+.2)/-10,0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(move);
        if (transform.position.x < -10) {
            // fail
            ScoreManager.leaks += 1;
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D col) {
        hp -= 1;
        if (hp <= 0) {
            Destroy(gameObject);
        } else {
            if (type == 0) {
                animator.SetInteger("State",1);
            }
        }
    }
}
