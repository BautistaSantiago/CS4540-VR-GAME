using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionDetect : MonoBehaviour
{
    public int score = 0;
    private void OnCollisionEnter(Collision Collision)
    {
        score++;
        Debug.Log("you got hit");
    }
}
