using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    
    Vector2 offset = new Vector2(0, 5f);

    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.y + offset.y < ScreenUtils.ScreenBottom) && !flag)
        {
            flag = true;
            SpawnManager.instance.InstantiateNew(gameObject.transform.position);

            Destroy(gameObject);
            //instantiate new...
        }
    }


}
