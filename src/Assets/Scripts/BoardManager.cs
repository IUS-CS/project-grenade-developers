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

    public int columns = 100; //columns and rows are size of board/room
    public int rows = 100;
    public GameObject[] floorTiles; //Array of floor prefabs
    public GameObject[] wallTiles; //Array of wall prefabs
    public GameObject[] enemyTiles; //Array of enemy prefabs
    public GameObject[] itemTiles; //Array of item prefabs

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
        //Generates a random mesh for placing walls in the level.
        // 1 = Wall
        // 0 = Floor
        int[,] levelGen = new int[columns,rows];
        for (int k = 0; k < columns/5; k++){
            for(int l = 0; l < rows/5; l++){
                levelGen[k, l] = 1; //start with a grid full of walls.
            }
        }
        levelGen[0, 0] = 0; //starting empty cell
        List<int> wallList = new List<int>(){1,0,0,1}; //initilize wallList with first neighbors
        
        while(wallList.Count > 0){
            // select a random wall to be a potential new path
            int randomWall = 2 * Random.Range(0, ((wallList.Count)/2));
            int newWallX = wallList[randomWall];
            int newWallY = wallList[randomWall+1];
            
            //now test if the new wall could become a valid path
            int connectedPaths = 0;
            if (newWallX-1 >= 0 && levelGen[newWallX-1,newWallY] == 0 )
                connectedPaths++;
            if (newWallX+1 <= (rows-1)/5 && levelGen[newWallX+1,newWallY] == 0 )
                connectedPaths++;
            if (newWallY-1 >= 0 && levelGen[newWallX,newWallY-1] == 0 )
                connectedPaths++;
            if (newWallY+1 <= (columns-1)/5 && levelGen[newWallX,newWallY+1] == 0 )
                connectedPaths++;
            if (newWallX-1 >= 0 && newWallY-1 >= 0 && levelGen[newWallX-1,newWallY-1] == 0 )
                connectedPaths++;
            if (newWallX+1 <= (rows-1)/5 && newWallY-1 >= 0 && levelGen[newWallX+1,newWallY-1] == 0 )
                connectedPaths++;
            if (newWallX-1 >= 0 && newWallY+1 <= (columns-1)/5 && levelGen[newWallX-1,newWallY+1] == 0 )
                connectedPaths++;
            if (newWallX+1 <= (rows-1)/5 && newWallY+1 <= (columns-1)/5 && levelGen[newWallX+1,newWallY+1] == 0 )
                connectedPaths++;

            if (connectedPaths == 1 || connectedPaths == 2) {

                levelGen[newWallX,newWallY] = 0; //turn the wall into a path
                
                //add the new neighbors to wallList
                if (newWallX-1 >= 0 && levelGen[newWallX-1,newWallY] == 1 ){
                    wallList.Add(newWallX-1);
                    wallList.Add(newWallY);
                }
                if (newWallX+1 <= rows-1 && levelGen[newWallX+1,newWallY] == 1 ){
                    wallList.Add(newWallX+1);
                    wallList.Add(newWallY);
                }
                if (newWallY-1 >= 0 && levelGen[newWallX,newWallY-1] == 1 ){
                    wallList.Add(newWallX);
                    wallList.Add(newWallY-1);
                }
                if (newWallY+1 <= columns-1 && levelGen[newWallX,newWallY+1] == 1 ){
                    wallList.Add(newWallX);
                    wallList.Add(newWallY+1);
                }
            }
            wallList.RemoveAt(randomWall); //remove the wall from the list
            wallList.RemoveAt(randomWall); //remove the wall from the list
        }//while
        
        //initialize levelGenRooms as a scale-up of levelgen
        int[,] levelGenRooms = new int[columns,rows];
        for (int k = 0; k < columns; k++){
            for(int l = 0; l < rows; l++){
                levelGenRooms[k, l] = levelGen[k/5,l/5]; //start with a grid full of walls.
            }
        }
        
        boardHolder = new GameObject("Board").transform;
        for(int i = -5; i < columns + 5; i++)
        {
            for(int j = -5; j < rows + 5; j++)
            {
                GameObject toCreate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (i <= -1 || i >= columns || j <= -1 || j >= rows || levelGenRooms[i, j] >= 1)
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
        int enemyCount = 2;
        int itemCount = 3;
        LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);
        LayoutObjectAtRandom(itemTiles, itemCount, itemCount);
    }
}