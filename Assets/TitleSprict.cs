using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSprict : MonoBehaviour
{
    public string nextSceneName;
    public GameObject hitKey;
    private int flamecounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        flamecounter++;
        if(flamecounter%100>50)
        {
            hitKey.SetActive(false);
        }
        else
        {
            hitKey.SetActive(true);
        }

    }
}
