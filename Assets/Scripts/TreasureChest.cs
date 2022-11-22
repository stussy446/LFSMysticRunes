using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicalRunes;
using System;
using UnityEngine.UI;

public class TreasureChest : MonoBehaviour
{
    [SerializeField] private RewardConfig[] rewardConfigs;
    [SerializeField] private float rewardDelay;
    [SerializeField] private GameObject rewardPrefab;
    [SerializeField] private Transform rewardSpawnLocation;

    private Button treasureButton;
    private RawImage treasureImage;
    private GameObject rewardGameObject;
    private Reward reward;

    private void Awake()
    {
        treasureButton = GetComponent<Button>();
        treasureImage = GetComponent<RawImage>();
    }

    private void OnEnable()
    {
        treasureButton.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        treasureButton.onClick.RemoveListener(OnClick);
    }

    /// <summary>
    /// if the probabilities are valid (Add up to 1), choose a reward and add
    /// that reward's number of coins to the players current total coins
    /// </summary>
    /// <exception cref="System.Exception"></exception>
    private void OnClick()
    {
        if (!ValidProbabilities())
        {
            throw new System.Exception("invalid probabilities, please make sure" +
                " the sum of the probabilities is 1");
        }

        RewardConfig chosenRewardConfig = ChooseReward();

        rewardGameObject = Instantiate(rewardPrefab, rewardSpawnLocation);
        reward = rewardGameObject.GetComponent<Reward>();

        reward.SetupReward(chosenRewardConfig);

        GameManager.Instance.coinsAmount += chosenRewardConfig.numberOfCoins;

        StartCoroutine(TempRewardDisable());
    }

    private IEnumerator TempRewardDisable()
    {
        Color greyedOut = new Color(1, 1, 1, 0.2f);
        treasureImage.color = greyedOut;
        treasureButton.interactable = false;

        yield return new WaitForSeconds(rewardDelay);

        reward.DestroyReward();
        treasureImage.color = new Color(1, 1, 1, 1);
        treasureButton.interactable = true;
    }


    /// <summary>
    /// Adds up all of the reward probabilities, returns true if the sum is 1
    /// and false otherwise
    /// </summary>
    /// <returns>bool</returns>
    private bool ValidProbabilities()
    {
        float sum = 0;

        foreach (var rewardConfig in rewardConfigs)
        {
            sum += rewardConfig.probability;
        }

        return sum == 1;
    }

    /// <summary>
    /// Chooses a reward based on cumulative proabilities of each potential
    /// reward type and returns the chosen reward
    /// </summary>
    /// <returns>RewardConfig</returns>
    private RewardConfig ChooseReward()
    {
        float cumulativeProbability = 0;
        float randomValue = UnityEngine.Random.value;

        foreach (var rewardConfig in rewardConfigs)
        {
            cumulativeProbability += rewardConfig.probability;

            if (randomValue < cumulativeProbability)
            {
                return rewardConfig;
            }
        }

        return null;
    }
}
