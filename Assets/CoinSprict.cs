using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSprict : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(1.0f, 0.0f, 0.0f);
    }
}
