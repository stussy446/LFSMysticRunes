using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinLight : MonoBehaviour
{
    [SerializeField]
    private float velocity = 10f;

    [SerializeField]
    private RectTransform spinLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spinLight.Rotate(new Vector3(0, 0, Time.deltaTime * velocity));
    }
}
