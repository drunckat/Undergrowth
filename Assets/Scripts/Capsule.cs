using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System;

public class Capsule : MonoBehaviour
{
        public static float score;
        private Stopwatch stopwatch;
        private bool placed = false;
        private Transform _playerTransform = default;
        private Vector2 screenBounds;
        private int hp;
        public AudioSource musicBuf;
        public AudioSource musicDebuf;
        //Speed speedClass;
        void Start()
        {
                hp = 3;
                score = 0f;
                screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
                stopwatch = Stopwatch.StartNew();
                _playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
                if (hp <= 0)
                {
                        Destroy(this.gameObject);
                }
                Stopwatch.GetTimestamp();
                TimeSpan ts = stopwatch.Elapsed;
                Vector3 dist = _playerTransform.position;

                //speedClass = GetComponent<Speed>();
                if (dist.y < 3.7) {
                        Vector3 move = new Vector3(0, 1f);
                        this.transform.position += move * Speed.speed * Time.deltaTime;
                        if (placed)
                        {
                                Vector3 moveManually = new Vector3(Input.GetAxis("Horizontal"), 0);
                                this.transform.position += moveManually * Speed.speed * Time.deltaTime;
                                score += Speed.speed * 0.001f;
                        }
                }
                else {
                        if (Speed.speed < 5f) Speed.speed += 0.001f;
                        placed = true;
                        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0);
                        if (dist.x + move.x * Speed.speed * Time.deltaTime < screenBounds.x && dist.x + move.x * Speed.speed * Time.deltaTime > -screenBounds.x)

                        this.transform.position += move * Speed.speed * Time.deltaTime;
                        score += Speed.speed * 0.01f;
                }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision.gameObject.tag == "friend")
                {
                        musicBuf.PlayOneShot(musicBuf.clip);
                        if (hp < 3) ++hp;
                        Speed.speed += 2;
                        Destroy(collision.gameObject);
                        score += 20;
                } else 
                if (collision.gameObject.tag == "enemy")
                {
                        --hp;

                        if (hp > 0)
                        {
                                musicDebuf.PlayOneShot(musicDebuf.clip);
                                Speed.speed -= 3f;
                        } else
                        {
                                FindObjectOfType<GameManager>().GameOver();
                        }
                        //Destroy(collision.gameObject);
                }

        }

        public int getHP()
        {
                return hp;
        }

        public float getScore()
        {
                return score;
        }
}