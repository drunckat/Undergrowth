using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    public Capsule capsule;
    private int old_hp;
    public Heart[] hearts = new Heart[3];
        // Start is called before the first frame update
    void Start()
    {
         old_hp = capsule.getHP();
         for (int i = 0; i < old_hp; i++)
         {
              hearts[i].transform.position = new Vector3(i + 5, 4, 10);
         }
    }

    // Update is called once per frame
    void Update()
    {
         int new_hp = capsule.getHP();
         if (old_hp < new_hp)
         {
              hearts[old_hp++].transform.position = new Vector3(old_hp + 4, 4, 10);
         } else if (old_hp > new_hp)
         {
              hearts[--old_hp].transform.position = new Vector3(-20, -20, -10);
         }
    }
}
