using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScore : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayingCards_7Spades" || other.gameObject.tag == "PlayingCards_7Club" || other.gameObject.tag == "PlayingCards_QHeart" || other.gameObject.tag == "PlayingCards_KDiamond" || other.gameObject.tag == "PlayingCards_JClub" || other.gameObject.tag == "PlayingCards_ASpades")
        {
            ScoreManager.sManager.IncreaseScore(1);
        }
    }
}
