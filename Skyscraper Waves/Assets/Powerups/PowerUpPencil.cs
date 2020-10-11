using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PowerUpPencil : PowerUp
{
    public int ammoAmount = 5;

    protected override void PowerUpPayload()  // Checklist item 1
    {
        base.PowerUpPayload();

        // Payload is to give some health bonus
        playerBrain.IncreaseAmmo(ammoAmount);      
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
