using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PowerUpStrenght : PowerUp
{
    public float strength = 100f;
    public float duration = 5f;

    protected override void PowerUpPayload()  // Checklist item 1
    {
        base.PowerUpPayload();

        // Payload is to give some health bonus
        playerBrain.SetStrength(false);      
    }

    protected override void PowerUpHasExpired ()     // Checklist item 2
    {
        if (powerUpState == PowerUpState.IsExpiring)
        {
            return;
        }
        playerBrain.SetStrength(true);

        base.PowerUpHasExpired ();
    }

    private void Update ()                            // Checklist item 3
    {
        if (powerUpState == PowerUpState.IsCollected)
        {
            duration -= Time.deltaTime;
            if (duration < 0)
            {
                PowerUpHasExpired ();
            }
        }
    }
}
