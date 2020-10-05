using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// assign value to the coins. Each time a player collects a coin, the score will be adjusted according to the amount of collected coins
public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CoinCounter.instance.ChangeScore(coinValue);
        }
    }
 }
  