using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class BackgroundScroller : MonoBehaviour
{
        private float offset;
        private Material mat;

        void Start()
        {
                mat = GetComponent<Renderer>().material;
        }

        // Update is called once per frame
        void Update()
        {
                offset += (Time.deltaTime * Speed.speed) / 10f;
                mat.SetTextureOffset("_MainTex", new Vector2(0, -offset));
        }
}