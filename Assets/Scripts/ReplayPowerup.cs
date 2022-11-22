using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayPowerup : Powerup
{
    protected override void PerformPowerupEffect()
    {
        GameManager.Instance.PlaySequencePreview();
    }
}