using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class Background : MonoBehaviour
{
        private Stopwatch stopwatch;
        private CharacterController capsuleController;
        private int placed = 1;
        public Background()
        {
                stopwatch = Stopwatch.StartNew();
        }
        void Start()
        {
                capsuleController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
                Stopwatch.GetTimestamp();
                TimeSpan ts = stopwatch.Elapsed;
                Vector2 move = new Vector2(0, 1f);
                if (ts.Seconds < 9) capsuleController.Move(move * Time.deltaTime * Speed.speed * placed);
                else Destroy(this.gameObject);
        }
}