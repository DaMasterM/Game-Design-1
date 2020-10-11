using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Coins : PowerUp
{
    public int coinValue = 1;

    protected override void PowerUpPayload()  // Checklist item 1
    {
        base.PowerUpPayload();

        // Payload is to give some health bonus
        playerBrain.IncreaseCoins(coinValue);      
    }

    protected override void PowerUpHasExpired ()     // Checklist item 2
    {
        if (powerUpState == PowerUpState.IsExpiring)
        {
            return;
        }

        base.PowerUpHasExpired ();
    }

    private void Update ()                            // Checklist item 3
    {
        
    }
}
