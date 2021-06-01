using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetController : MonoBehaviour
{
    int x = 0;
    public GameObject pfTarget;
    public GameObject pfBossTarget;
    public AudioSource leaksound;
    int gametime = 0;
    double spawn_liklehood = 0;
    double normal_enemy_filler = 0;
    double boss_enemy_filler = 0;
    int lastLeak;
    // Start is called before the first frame update
    void Start()
    {
        gametime = ScoreManager.TotalGameTime;
        spawn_liklehood = .02;
        lastLeak = 0;
        leaksound = GetComponents<AudioSource>()[2];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x += 1;
        normal_enemy_filler += spawn_liklehood;
        boss_enemy_filler += spawn_liklehood;
        if(normal_enemy_filler >= 1) {
            // create new thing
            Instantiate(pfTarget, new Vector3(12,Random.Range(-2,5),0),Quaternion.identity);
            normal_enemy_filler = 0;
        }
        if(boss_enemy_filler >= 15) {
            // create new thing
            Instantiate(pfBossTarget, new Vector3(12,Random.Range(-2,5),0),Quaternion.identity);
            boss_enemy_filler = 0;
        }

        if (x%((int)(gametime/4)) == 0) {
            Debug.Log(x);
            spawn_liklehood+=.015;
        }

        if ( x > ScoreManager.TotalGameTime) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        
        if (lastLeak < ScoreManager.leaks) {
            leaksound.Play();
        }
        lastLeak = ScoreManager.leaks;
    }
}
//changing to test it