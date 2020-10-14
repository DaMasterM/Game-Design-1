using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SpecialCollectable : PowerUp
{
    public int scoreValue = 1000;

    protected override void PowerUpPayload()  // Checklist item 1
    {
        base.PowerUpPayload();

        // Payload is to give some health bonus
        playerBrain.SpecialCollectable(scoreValue);      
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
