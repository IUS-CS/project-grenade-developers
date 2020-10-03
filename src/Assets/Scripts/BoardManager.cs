using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Collections.Specialized;

public class BoardManager : MonoBehaviour {

    //
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 20; //columns and rows are size of board/room
    public int rows = 20;
    public GameObject[] floorTiles; //Array of floor prefabs
    public GameObject[] wallTiles; //Array of wall prefabs
    public GameObject[] enemyTiles; //Array of enemy prefabs


    private Transform boardHolder; //Reference to the transform of the board object
    private List<Vector3> gridPositions = new List<Vector3>(); //List of possible locations to put tiles such as enemies

    //Clears board list and files array with positions of board with a vector3
    void InitialiseList()
    {
        gridPositions.Clear();
        for(int i = 1; i < columns - 1; i++)
        {
            for(int j = 1; j < rows - 1; j++)
            {
                gridPositions.Add(new Vector3(i, j, 0f));
            }
        }
    }

    //Lays out floor and walls
    //Setup for random patterns
    private void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for(int i = -1; i < columns + 1; i++)
        {
            for(int j = -1; j < rows + 1; j++)
            {
                GameObject toCreate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (i == -1 || i == columns || j == -1 || j == rows)
                    toCreate = wallTiles[Random.Range(0, wallTiles.Length)];
                GameObject instance = Instantiate(toCreate, new Vector3(i, j, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    //Gives a random vector3 position on the board and removes double spawns
    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    //Spawn tiles at random positions such as enemies
    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for(int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }
    
    //What is called by GameManager to setup new random board 
    public void SetupScene (int level)
    {
        BoardSetup();
        InitialiseList();
        int enemyCount = 1;
        LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);
    }
}
