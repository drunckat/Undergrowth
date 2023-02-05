using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class crystal : MonoBehaviour
{
        // Start is called before the first frame update
    private Rigidbody2D rb;
    private Stopwatch stopwatch;
    public float speed = 5f;
    

    void Start()
    {
                stopwatch = Stopwatch.StartNew();
                rb = this.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(0 , speed);
    }

    // Update is called once per frame
    void Update()
    {

                Stopwatch.GetTimestamp();
                TimeSpan ts = stopwatch.Elapsed;
                if (ts.Seconds > 3)
                {
                        Destroy(this.gameObject);
                }
    }
}
