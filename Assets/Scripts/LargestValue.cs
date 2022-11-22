using UnityEngine;

public class LargestValue : MonoBehaviour
{
    [SerializeField] private int[] maxArray;
    [SerializeField] private int minRandomNumber;
    [SerializeField] private int maxRandomNumber;
    [SerializeField] private float secondsBetweenCalls = 3f;
    
    private float timer;

    private void Start()
    {
        ResetTimer(secondsBetweenCalls);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= float.Epsilon )
        {
            FindLargestNumber(maxArray);
            ResetTimer(secondsBetweenCalls);
        }
    }

    /// <summary>
    /// given an array of numbers, finds the value and index of largest number
    /// and logs them to the console
    /// </summary>
    /// <param name="arr">int[]</param>
    private void FindLargestNumber(int[] arr)
    {
        if (arr.Length == 0)
        {
            print($"Provided array is empty, please provide populated array");
            return;
        }

        int currentLargestNum = arr[0];
        int currentLargestIndex = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > currentLargestNum)
            {
                currentLargestNum = arr[i];
                currentLargestIndex = i;
            }
        }

        print($"largest number found is {currentLargestNum}");
        print($"largest index found is {currentLargestIndex}");

        ReplaceNumber(arr, currentLargestIndex, minRandomNumber, maxRandomNumber);
    }

    /// <summary>
    /// sets timer back to however many second it is provided
    /// </summary>
    /// <param name="seconds">float</param>
    private void ResetTimer(float seconds)
    {
        timer = seconds;
    }

    /// <summary>
    /// replaces element at the provided index of the array with a random number
    /// between min and max inclusive
    /// </summary>
    /// <param name="arr">int[]</param>
    /// <param name="largestIndex">int</param>
    /// <param name="min">int</param>
    /// <param name="max">int</param>
    private void ReplaceNumber(int[] arr, int index, int min, int max)
    {
        arr[index] = Random.Range(min, max + 1);
    }
}
