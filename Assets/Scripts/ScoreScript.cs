using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text score;
    public Capsule capsule;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
         if (capsule.getHP() > 0) score.text = "SCORE: " + (int)capsule.getScore();
    }
}
