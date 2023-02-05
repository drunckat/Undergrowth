using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class deployCrystal : MonoBehaviour
{
        public GameObject crystal;
        public float respawnTime = 1.0f;
        private Vector2 screenBounds;

        // Use this for initialization
        void Start()
        {
                screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
                StartCoroutine(crystaWave());
        }
        private void spawnEnemy()
        {
                GameObject a = Instantiate(crystal) as GameObject;
                a.transform.position = new Vector3(UnityEngine.Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y, 5);
        }
        IEnumerator crystaWave()
        {
                yield return new WaitForSeconds(0.5f);
                System.Random rnd = new System.Random();
                while (true)
                {
                        yield return new WaitForSeconds(respawnTime + rnd.Next(0, 10) / 10f);
                        spawnEnemy();
                }
        }
}