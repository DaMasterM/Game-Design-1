using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
 public int coinValue = 1; // als de player tegen een coin aanloopt verandert de score
 
 void OnTriggerEnter2D(Collider2D Collision){
	  if(Other.gameObject.CompareTag("Player"){ 
			CoinCounter.instance.ChangeScore(coinValue)
	  }
 }

private void OnTrigerEnter2D(Collider2D other){ // als de player tegen de coin aanloopt verwijdert het spel de coin
	if(other.gameObject.CompareTag("Coin"")) {
		Destroy(other.gameObject);
		}
	}
}