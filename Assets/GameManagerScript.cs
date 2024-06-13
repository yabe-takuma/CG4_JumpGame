using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;
    public GameObject goal;
    public GameObject coin;
    public TextMeshProUGUI scoreText;
    public GameObject goalParticle;
    public GameObject backgroud;
    public static int score = 0;
    enum Block
    {
        NONE,
        BLOCK,
        COIN,
        GOAL,
    };

    int[,] map =
    {
        {1,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,2,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,3,0,1},
        {1,0,2,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,1,0,0,0,0,0,1,1,1,1,1,1,1},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1},
        {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,2,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,1,1,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,1},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    };

   

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = Vector3.zero;
        int lenY = map.GetLength(0);
        int lenX = map.GetLength(1);
        Screen.SetResolution(1920, 1080, false);
        for (int x = 0; x < lenX; x++)
            for (int y = 0; y < lenY; y++)
            {
                {
                    position.x = x;
                    position.y = -y+5;
                    if (map[y, x] == (int)Block.BLOCK)
                    {
                        Instantiate(block, position, Quaternion.identity);
                    }
                    if (map[y, x] == (int)Block.GOAL)
                    {
                        goal.transform.position = position;
                        goalParticle.transform.position = position;
                    }
                    if (map[y, x] == (int)Block.COIN)
                    {
                        Instantiate(coin, position, Quaternion.identity);
                    }
                  
                }
            }
        for (int x = 0; x < lenX; x++)
            for (int y = 0; y < lenY; y++)
            {
                {
                    position.x = x;
                    position.y = -y + 5;
                    position.z = 2;
                    Instantiate(backgroud, position, Quaternion.identity);
                }
            }
                    score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームクリアでスペースキーでタイトルへ移行
        if(GoalSprict.isGameClear==true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        scoreText.text = "SCORE" + score;
    }
    
}
