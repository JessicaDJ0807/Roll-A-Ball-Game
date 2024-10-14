using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public int speed = 1;
    int score = 0;
    float timer = 0.0f;
    public Text instruction_text1, instruction_text2, score_text, gameover_text, time_text, congrats_text, finished_text;
    public Button restart_button, play_again_button;
    public GameObject lock_icon, unlock_icon;
    bool jumping = false;
    bool init_lock = false;
    bool isLocked = false;
    Material last;
    int coin_count = 8;

    // Start is called before the first frame update
    void Start()
    {
        score_text.gameObject.SetActive(true);
        time_text.gameObject.SetActive(true);
        instruction_text1.gameObject.SetActive(true);
        instruction_text1.gameObject.SetActive(true);
        instruction_text2.gameObject.SetActive(false);
        gameover_text.gameObject.SetActive(false);
        congrats_text.gameObject.SetActive(false);
        finished_text.gameObject.SetActive(false);
        restart_button.gameObject.SetActive(false);
        play_again_button.gameObject.SetActive(false);
        lock_icon.gameObject.SetActive(false);
        unlock_icon.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, speed);
        }
        if (!jumping && Input.GetKey(KeyCode.Space))
        {
            jumping = true;
            GetComponent<Rigidbody>().AddForce(0, speed*20, 0);
        }
        if (init_lock && Input.GetKeyDown(KeyCode.L))
        {
            if (isLocked) {
                lock_icon.gameObject.SetActive(false);
                unlock_icon.gameObject.SetActive(true);
                GetComponent<Renderer>().material = last;
                isLocked = false;
            } else {
                unlock_icon.gameObject.SetActive(false);
                lock_icon.gameObject.SetActive(true);
                isLocked = true;
            }
        }

        // disable the first instuction
        if (transform.position.x <= 0) {
            instruction_text1.gameObject.SetActive(false);
        }

        // show lock/unlock and show the second instruction
        if (!init_lock && transform.position.y < -0.76) {
            unlock_icon.gameObject.SetActive(true);
            instruction_text2.gameObject.SetActive(true);
            isLocked = false;
            init_lock = true;
        }

        // when win
        if (coin_count == 0) {
            congrats_text.gameObject.SetActive(true);
            finished_text.gameObject.SetActive(true);
            play_again_button.gameObject.SetActive(true);
        }
        // when lose
        else if (transform.position.y < -2.5)
        {
            gameover_text.gameObject.SetActive(true);
            restart_button.gameObject.SetActive(true);
        }
        // updating timer
        else
        {
            timer += Time.deltaTime;
            time_text.text = "Time: " + Mathf.Round(timer * 100.0f) * 0.01f + 's';
        }

        // Quit game on Esc
        if (Input.GetKey(KeyCode.Escape)) {            
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    private void OnTriggerEnter(Collider other) // other: 撞到的東西
    {
        if (other.tag == "coin") {
            if (other.GetComponent<Renderer>().material.name == GetComponent<Renderer>().material.name) {
                score++;
                coin_count--;
                instruction_text2.gameObject.SetActive(false);
            } else {
                return;
            }
        }
        else if (other.tag == "gold coin") score += 3;
        else if (other.tag == "silver coin") score += 2;

        other.gameObject.SetActive(false);
        score_text.text = "Score: " + score;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "grid") {
            last = collision.gameObject.GetComponent<Renderer>().sharedMaterial;
            jumping = false;
        }
        if (!isLocked && collision.gameObject.tag == "grid") {
            GetComponent<Renderer>().material = collision.gameObject.GetComponent<Renderer>().sharedMaterial;
        }
    }
}
