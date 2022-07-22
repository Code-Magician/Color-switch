using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] bool clockwise;
    // Update is called once per frame
    int rotationMaker;

    private void Start()
    {
        if (clockwise)
            rotationMaker = -1;
        else
            rotationMaker = 1;
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationMaker * ConfigurationUtils.RotationSpeed) * Time.deltaTime);
    }
}
