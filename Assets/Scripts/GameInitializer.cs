using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ConfigurationUtils.Initialize();
    }

    private void Update()
    {
        ScreenUtils.Initialize();
    }

}
