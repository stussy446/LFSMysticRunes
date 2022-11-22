using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : Powerup
{
    private int LivesPerLevel => ((LifePowerupConfig)powerupConfig).livesPerLevel;
    protected override void PerformPowerupEffect()
    {
        GameManager manager = GameManager.Instance;
        manager.RemainingLives += LivesPerLevel;
    }
}
