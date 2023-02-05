using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public static float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
                if (speed > 5f) speed = 5f;
                if (speed < 2f) speed = 2f;
    }
}
