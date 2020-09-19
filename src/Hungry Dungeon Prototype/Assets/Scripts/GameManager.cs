using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null; //Required to make singleton and allow access to public functions from any script

    public BoardManager boardScript;

    private int level = 3;

    // Start is called before the first frame update
    void Awake()
    {
        //Check to see if instance already exists
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject); //Sets this to not be destroyed on reload
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        boardScript.SetupScene(level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
