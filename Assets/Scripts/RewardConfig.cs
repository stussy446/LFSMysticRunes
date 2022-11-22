using System;
using UnityEngine;
using UnityEngine.UI;

namespace MusicalRunes
{
    [CreateAssetMenu(fileName = "new Reward Config", menuName = "Configs/Reward",
        order = 1)]
    public class RewardConfig : ScriptableObject
    {
        public RewardType rewardType;
        public int numberOfCoins;
        public Texture2D rewardImage;
        public float probability;
    }
}
