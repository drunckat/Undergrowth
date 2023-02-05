using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class deployLava : MonoBehaviour
{
        public Capsule capsule;
        public GameObject lava;
        public float respawnTime = 1.0f;
        private Vector2 screenBounds;

        // Use this for initialization
        void Start()
        {
                screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
                StartCoroutine(lavaWave());
        }
        private void spawnEnemy()
        {
                GameObject a = Instantiate(lava) as GameObject;
                a.transform.position = new Vector2(UnityEngine.Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y);
        }
        IEnumerator lavaWave()
        {
                yield return new WaitForSeconds(0.5f);
                System.Random rnd = new System.Random();
                while (true)
                {
                        respawnTime -= 0.001f * capsule.getScore();
                        if (respawnTime < 0) respawnTime = 0;
                        yield return new WaitForSeconds(respawnTime + rnd.Next(0, 10) / 10f);
                        spawnEnemy();
                }
        }
}