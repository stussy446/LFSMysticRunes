using System;
using UnityEngine;

namespace MusicalRunes
{
    [CreateAssetMenu(fileName = "new Powerup Config", menuName = "Configs/Power up", order = 0)]
    public class PowerupConfig : ScriptableObject
    {
        public PowerupType powerupType;
        public string powerupNameID;
        public string descriptionID;
        public int[] pricePerLevel = { 50, 100, 200 };
        public int[] cooldownAtlevel = { 5, 4, 3 };
        public bool decreaseCooldownOnRuneActivation;

        public int MaxLevel => pricePerLevel.Length;
        public int GetUpgradePrice(int level) => level >= MaxLevel ? Int32.MaxValue : pricePerLevel[level];
        public int GetCooldown(int level) => level == 0 ? 0 : cooldownAtlevel[level - 1];

        public string PowerupName => Localization.GetLocalizedText(powerupNameID);
        public string Description => Localization.GetLocalizedText(descriptionID);


    }
}
