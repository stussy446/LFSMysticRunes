using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicalRunes;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    private float probability;
    private Texture2D image;
    private RewardType rewardType;
    private int coinsRewarded;
    private float amplitude = 1f;
    private float frequency = 5f;

    private void Update()
    {
        Animate();
    }

    public void SetupReward(RewardConfig rewardConfig)
    {
        probability = rewardConfig.probability;
        rewardType = rewardConfig.rewardType;
        coinsRewarded = rewardConfig.numberOfCoins;
        image = rewardConfig.rewardImage;

        GetComponent<RawImage>().texture = image;
    }


    private void Animate()
    {

        transform.localScale = Vector3.one + Vector3.one * (Mathf.Sin(Time.time
           * frequency) * amplitude);
       
    }


    public void DestroyReward()
    {
        Destroy(gameObject);
    }
}
