using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySound1 : MonoBehaviour
{
    float time1 = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time1 = time1 - Time.deltaTime;
        if (time1 <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
