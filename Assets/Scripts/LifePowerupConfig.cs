using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicalRunes;

[CreateAssetMenu(fileName = "new LifePowerup Config", menuName = "Configs/Life Powerup")]
public class LifePowerupConfig : PowerupConfig
{
    public int startingLives;
    public int livesToAdd;
}
