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

    public static int mazeSize = 15; //how big od a maze to generate.
    public static int scaleFactor = 9; //how much to scale the rooms by.
    public static int columns = mazeSize * scaleFactor; //columns and rows are size of board/room
    public static int rows = mazeSize * scaleFactor;
    
    public GameObject[] floorTiles; //Array of floor prefabs
    public GameObject[] wallTiles; //Array of wall prefabs
    public GameObject[] enemyTiles; //Array of enemy prefabs
    public GameObject[] itemTiles; //Array of item prefabs
    public GameObject[] levelExit; //The level exit
    
    public int[,] levelGenRooms = new int[columns,rows];//final Array used to place GameObjects

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
        for (int k = 0; k < mazeSize; k++){
            for(int l = 0; l < mazeSize; l++){
                levelGen[k, l] = 0; //start with a grid full of walls.
            }
        }
        levelGen[0, 0] = 1; //starting empty cell
        List<int> wallList = new List<int>(){1,0,0,1}; //initilize wallList with first neighbors
        
        while(wallList.Count > 0){
            // select a random wall to be a potential new path
            int randomWall = 2 * Random.Range(0, ((wallList.Count)/2));
            int newWallX = wallList[randomWall];
            int newWallY = wallList[randomWall+1];
            
            //now test if the new wall could become a valid path
            int connectedPaths = 0;
            if (newWallX-1 >= 0 && levelGen[newWallX-1,newWallY] == 1 )
                connectedPaths++;
            if (newWallX+1 <= (rows-1)/scaleFactor && levelGen[newWallX+1,newWallY] == 1 )
                connectedPaths++;
            if (newWallY-1 >= 0 && levelGen[newWallX,newWallY-1] == 1 )
                connectedPaths++;
            if (newWallY+1 <= (columns-1)/scaleFactor && levelGen[newWallX,newWallY+1] == 1 )
                connectedPaths++;
            if (newWallX-1 >= 0 && newWallY-1 >= 0 && levelGen[newWallX-1,newWallY-1] == 1 )
                connectedPaths++;
            if (newWallX+1 <= (rows-1)/scaleFactor && newWallY-1 >= 0 && levelGen[newWallX+1,newWallY-1] == 1 )
                connectedPaths++;
            if (newWallX-1 >= 0 && newWallY+1 <= (columns-1)/scaleFactor && levelGen[newWallX-1,newWallY+1] == 1 )
                connectedPaths++;
            if (newWallX+1 <= (rows-1)/scaleFactor && newWallY+1 <= (columns-1)/scaleFactor && levelGen[newWallX+1,newWallY+1] == 1 )
                connectedPaths++;

            if (connectedPaths == 1 || connectedPaths == 2) {

                levelGen[newWallX,newWallY] = 1; //turn the wall into a path
                
                //add the new neighbors to wallList
                if (newWallX-1 >= 0 && levelGen[newWallX-1,newWallY] == 0){
                    wallList.Add(newWallX-1);
                    wallList.Add(newWallY);
                }
                if (newWallX+1 <= rows-1 && levelGen[newWallX+1,newWallY] == 0){
                    wallList.Add(newWallX+1);
                    wallList.Add(newWallY);
                }
                if (newWallY-1 >= 0 && levelGen[newWallX,newWallY-1] == 0){
                    wallList.Add(newWallX);
                    wallList.Add(newWallY-1);
                }
                if (newWallY+1 <= columns-1 && levelGen[newWallX,newWallY+1] == 0){
                    wallList.Add(newWallX);
                    wallList.Add(newWallY+1);
                }
            }
            wallList.RemoveAt(randomWall); //remove the wall from the list
            wallList.RemoveAt(randomWall); //remove the wall from the list
        }//while
        
        //redefine levelGen tiles based on neightbors.
        int[,] levelGen2 = new int[mazeSize,mazeSize];
        for (int k = 0; k < mazeSize; k++){
            for(int l = 0; l < mazeSize; l++){
                 
                if (levelGen[k,l] == 1){

                    int cellRight = (k == (mazeSize)-1) ? 0 : levelGen[k+1,l];
                    int cellLeft = (k == 0) ? 0 : levelGen[k-1,l];
                    int cellUp = (l == (mazeSize)-1) ? 0 : levelGen[k,l+1];
                    int cellDown = (l == 0) ? 0 : levelGen[k,l-1];

                    //cell has neighbors up and left
                    if (cellUp == 1 && cellDown == 0 && cellRight == 0 && cellLeft == 1) {
                        levelGen2[k,l] = 1;
                    }
                    //cell has neighbors up and right
                    else if (cellUp == 1 && cellDown == 0 && cellRight == 1 && cellLeft == 0) {
                        levelGen2[k,l] = 2;
                    }
                    //cell has neighbors down and right
                    else if (cellUp == 0 && cellDown == 1 && cellRight == 1 && cellLeft == 0) {
                        levelGen2[k,l] = 3;
                    }
                    //cell has neighbors down and left
                    else if (cellUp == 0 && cellDown == 1 && cellRight == 0 && cellLeft == 1) {
                        levelGen2[k,l] = 4;
                    }
                    //cell has neighbors left and right
                    else if (cellUp == 0 && cellDown == 0 && cellRight == 1 && cellLeft == 1) {
                        levelGen2[k,l] = 5;
                    }
                    //cell has neighbors up and down
                    else if (cellUp == 1 && cellDown == 1 && cellRight == 0 && cellLeft == 0) {
                        levelGen2[k,l] = 6;
                    }
                    //cell has neighbor only left
                    else if (cellUp == 0 && cellDown == 0 && cellRight == 0 && cellLeft == 1) {
                        levelGen2[k,l] = 7;
                    }
                    //cell has neighbor only up
                    else if (cellUp == 1 && cellDown == 0 && cellRight == 0 && cellLeft == 0) {
                        levelGen2[k,l] = 8;
                    }
                    //cell has neighbor only right
                    else if (cellUp == 0 && cellDown == 0 && cellRight == 1 && cellLeft == 0) {
                        levelGen2[k,l] = 9; 
                    }
                    //cell has neighbor only down
                    else if (cellUp == 0 && cellDown == 1 && cellRight == 0 && cellLeft == 0) {
                        levelGen2[k,l] = 10;
                    } else {
                    //ELSE cell has different pattern of neighbors:
                        levelGen2[k,l] = 11;
                    }
                } else {
                    levelGen2[k,l] = 0; //otherwise it's a wall
                }//if-else
            }//for l
        }//for k
        
        //initialize levelGenRooms as a scale-up of levelgen
        int[,] room =  new int[scaleFactor,scaleFactor];
        for (int k = 0; k < mazeSize; k++){
            for(int l = 0; l < mazeSize; l++){
                int randomRoom = Random.Range(0,3);
                switch(levelGen2[k,l]) {
                //THESE ROOMS ARE ROTATED 90 DEGREES CLOCKWISE OF HOW THEY WILL APPEAR IN GAME
                //THIS MUST BE EQUAL TO THE SIZE OF THE SCALE FACTOR
                    case 0:
                        room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                            {0,0,0,0,0,0,0,0,0}, 
                                            {0,0,0,0,0,0,0,0,0}, 
                                            {0,0,0,0,0,0,0,0,0}, 
                                            {0,0,0,0,0,0,0,0,0}, 
                                            {0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0} };
                        break;
                    case 1:
                        switch(randomRoom) {
                            case 0:
                                room = new int[,] { {0,1,1,1,1,1,1,1,1}, 
                                                    {0,1,1,1,1,1,1,1,1}, 
                                                    {0,0,1,1,1,1,1,1,1},
                                                    {0,0,1,1,1,1,1,1,1},
                                                    {0,0,0,1,1,1,1,1,1},
                                                    {0,0,0,1,1,1,1,1,1},
                                                    {0,0,0,0,0,1,1,1,1},
                                                    {0,0,0,0,0,0,0,1,1},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 1: 
                                room = new int[,] { {0,0,1,1,1,1,0,0,0}, 
                                                    {0,1,1,1,1,0,0,0,0}, 
                                                    {1,1,1,1,1,0,0,0,0},
                                                    {1,1,1,1,0,0,0,0,1},
                                                    {1,1,1,0,0,0,1,1,1},
                                                    {1,1,1,0,0,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,0,1,1,1,1,1,0,0} };
                                break;
                            case 2:
                                room = new int[,] { {0,0,1,1,1,0,0,0,0}, 
                                                    {0,0,1,1,1,0,0,0,0}, 
                                                    {0,0,1,1,1,0,0,0,0},
                                                    {0,0,1,1,1,0,0,0,0},
                                                    {0,0,1,1,1,1,1,1,1},
                                                    {0,0,1,1,1,1,1,1,1},
                                                    {0,0,1,1,1,1,1,1,1},
                                                    {0,0,0,0,0,0,0,0,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 3:
                                room = new int[,] { {0,0,0,1,1,1,1,0,0}, 
                                                    {0,0,1,1,1,1,1,1,0}, 
                                                    {0,1,1,1,1,1,1,1,1},
                                                    {0,1,1,1,0,0,1,1,1},
                                                    {0,1,1,1,0,0,1,1,1},
                                                    {0,1,1,1,1,1,1,1,1},
                                                    {0,0,1,1,1,1,1,1,0},
                                                    {0,0,0,1,1,1,1,0,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                        }
                        break;
                    case 2:
                        switch(randomRoom) {
                            case 0:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,0,0,0,0,0,1,1}, 
                                                    {0,0,0,0,0,1,1,1,1},
                                                    {0,0,0,1,1,1,1,1,1},
                                                    {0,0,0,1,1,1,1,1,1},
                                                    {0,0,1,1,1,1,1,1,1},
                                                    {0,0,1,1,1,1,1,1,1},
                                                    {0,1,1,1,1,1,1,1,1},
                                                    {0,1,1,1,1,1,1,1,1} };
                                break;
                            case 1: 
                                room = new int[,] { {0,0,1,1,1,1,1,0,0}, 
                                                    {0,1,1,1,1,1,1,1,0}, 
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,0,0,1,1,1,1},
                                                    {1,1,1,0,0,0,1,1,1},
                                                    {1,1,1,1,0,0,0,0,1},
                                                    {1,1,1,1,1,0,0,0,0},
                                                    {0,1,1,1,1,0,0,0,0},
                                                    {0,0,1,1,1,1,0,0,0} };
                                break;
                            case 2:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,1,1,1,1,1,1,1},
                                                    {0,0,1,1,1,1,1,1,1},
                                                    {0,0,1,1,1,1,1,1,1},
                                                    {0,0,1,1,1,0,0,0,0},
                                                    {0,0,1,1,1,0,0,0,0},
                                                    {0,0,1,1,1,0,0,0,0},
                                                    {0,0,1,1,1,0,0,0,0} };
                                break;
                            case 3:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,0,1,1,1,1,0,0}, 
                                                    {0,0,1,1,1,1,1,1,0},
                                                    {0,1,1,1,1,1,1,1,1},
                                                    {0,1,1,1,0,0,1,1,1},
                                                    {0,1,1,1,0,0,1,1,1},
                                                    {0,1,1,1,1,1,1,1,1},
                                                    {0,0,1,1,1,1,1,1,0},
                                                    {0,0,0,1,1,1,1,0,0} };
                                break;
                        }
                        break;
                    case 3:
                        switch(randomRoom) {
                            case 0:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {1,1,0,0,0,0,0,0,0}, 
                                                    {1,1,1,1,0,0,0,0,0},
                                                    {1,1,1,1,1,1,0,0,0},
                                                    {1,1,1,1,1,1,0,0,0},
                                                    {1,1,1,1,1,1,1,0,0},
                                                    {1,1,1,1,1,1,1,0,0},
                                                    {1,1,1,1,1,1,1,1,0},
                                                    {1,1,1,1,1,1,1,1,0} };
                                break;
                            case 1: 
                                room = new int[,] { {0,0,1,1,1,1,1,0,0}, 
                                                    {0,1,1,1,1,1,1,1,0}, 
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,0,0,1,1,1},
                                                    {1,1,1,0,0,0,1,1,1},
                                                    {1,0,0,0,0,1,1,1,1},
                                                    {0,0,0,0,1,1,1,1,1},
                                                    {0,0,0,0,1,1,1,1,0},
                                                    {0,0,0,1,1,1,1,0,0} };
                                break;
                            case 2:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,0,0,0,0,0,0,0}, 
                                                    {1,1,1,1,1,1,1,0,0},
                                                    {1,1,1,1,1,1,1,0,0},
                                                    {1,1,1,1,1,1,1,0,0},
                                                    {0,0,0,0,1,1,1,0,0},
                                                    {0,0,0,0,1,1,1,0,0},
                                                    {0,0,0,0,1,1,1,0,0},
                                                    {0,0,0,0,1,1,1,0,0} };
                                break;
                            case 3:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,1,1,1,1,0,0,0}, 
                                                    {0,1,1,1,1,1,1,0,0},
                                                    {1,1,1,1,1,1,1,1,0},
                                                    {1,1,1,0,0,1,1,1,0},
                                                    {1,1,1,0,0,1,1,1,0},
                                                    {1,1,1,1,1,1,1,1,0},
                                                    {0,1,1,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,0,0,0} };
                                break;
                        }
                        break;
                    case 4:
                        switch(randomRoom) {
                            case 0:
                                room = new int[,] { {1,1,1,1,1,1,1,1,0}, 
                                                    {1,1,1,1,1,1,1,1,0}, 
                                                    {1,1,1,1,1,1,1,0,0},
                                                    {1,1,1,1,1,1,1,0,0},
                                                    {1,1,1,1,1,1,0,0,0},
                                                    {1,1,1,1,1,1,0,0,0},
                                                    {1,1,1,1,0,0,0,0,0},
                                                    {1,1,0,0,0,0,0,0,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 1: 
                                room = new int[,] { {0,0,0,1,1,1,1,0,0}, 
                                                    {0,0,0,0,1,1,1,1,0}, 
                                                    {0,0,0,0,1,1,1,1,1},
                                                    {1,0,0,0,0,1,1,1,1},
                                                    {1,1,1,0,0,0,1,1,1},
                                                    {1,1,1,1,0,0,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,0,1,1,1,1,1,0,0} };
                                break;
                            case 2:
                                room = new int[,] { {0,0,0,0,1,1,1,0,0}, 
                                                    {0,0,0,0,1,1,1,0,0}, 
                                                    {0,0,0,0,1,1,1,0,0},
                                                    {0,0,0,0,1,1,1,0,0},
                                                    {1,1,1,1,1,1,1,0,0},
                                                    {1,1,1,1,1,1,1,0,0},
                                                    {1,1,1,1,1,1,1,0,0},
                                                    {0,0,0,0,0,0,0,0,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 3:
                                room = new int[,] { {0,0,1,1,1,1,0,0,0}, 
                                                    {0,1,1,1,1,1,1,0,0}, 
                                                    {1,1,1,1,1,1,1,1,0},
                                                    {1,1,1,0,0,1,1,1,0},
                                                    {1,1,1,0,0,1,1,1,0},
                                                    {1,1,1,1,1,1,1,1,0},
                                                    {0,1,1,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,0,0,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                        }
                        break;
                    case 5:
                        switch(randomRoom) {
                            case 0:
                                room = new int[,] { {0,0,1,1,1,1,0,0,0}, 
                                                    {0,0,1,1,1,1,0,0,0}, 
                                                    {0,0,0,1,1,1,1,0,0},
                                                    {0,0,0,0,1,1,1,1,0},
                                                    {0,0,0,0,1,1,1,1,0},
                                                    {0,0,0,0,1,1,1,1,0},
                                                    {0,0,0,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,0,0,0},
                                                    {0,0,1,1,1,1,0,0,0} };
                                break;
                            case 1: 
                                room = new int[,] { {0,0,0,1,1,1,1,0,0}, 
                                                    {0,0,0,1,1,1,1,0,0}, 
                                                    {0,0,1,1,1,1,0,0,0},
                                                    {0,1,1,1,1,0,0,0,0},
                                                    {0,1,1,1,1,0,0,0,0},
                                                    {0,1,1,1,1,0,0,0,0},
                                                    {0,0,1,1,1,1,0,0,0},
                                                    {0,0,0,1,1,1,1,0,0},
                                                    {0,0,0,1,1,1,1,0,0} };
                                break;
                            case 2:
                                room = new int[,] { {0,1,1,1,1,1,1,0,0}, 
                                                    {0,0,1,1,1,1,1,1,0}, 
                                                    {0,1,1,1,1,1,0,0,0},
                                                    {0,0,0,1,1,1,1,1,0},
                                                    {0,1,1,1,1,1,1,0,0},
                                                    {0,0,0,1,1,1,1,1,0},
                                                    {0,1,1,1,1,1,0,0,0},
                                                    {0,0,1,1,1,1,1,1,0},
                                                    {0,1,1,1,1,1,1,0,0} };
                                break;
                            case 3:
                                room = new int[,] { {0,0,1,1,1,1,1,0,0}, 
                                                    {0,0,1,1,1,1,1,0,0}, 
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,1,0,0} };
                                break;
                        }
                        break;
                    case 6:
                        switch(randomRoom) {
                            case 0:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,0,1,1,1,0,0,0}, 
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,0,0,0,1,1,1},
                                                    {1,1,0,0,0,0,0,1,1},
                                                    {0,0,0,0,0,0,0,0,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 1: 
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,0,0,0,0,0,0,0}, 
                                                    {1,1,0,0,0,0,0,1,1},
                                                    {1,1,1,0,0,0,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,0,0,1,1,1,0,0,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 2:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {1,0,1,0,1,0,1,0,1}, 
                                                    {1,1,1,0,1,0,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,0,1,1,1,0,1,1},
                                                    {0,1,0,1,0,1,0,1,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 3:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,0,0,0,0,0,0,0}, 
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {0,0,0,0,0,0,0,0,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                        }
                        break;
                    case 7:
                        switch(randomRoom) {
                            case 0:
                                room = new int[,] { {0,1,1,1,1,1,1,1,0}, 
                                                    {0,1,1,1,1,1,1,1,0}, 
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,0,1,1,1,0,0,0},
                                                    {0,0,0,0,1,0,0,0,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 1: 
                                room = new int[,] { {0,0,0,1,1,1,0,0,0}, 
                                                    {0,0,1,1,1,1,1,0,0}, 
                                                    {0,1,0,1,1,0,1,1,0},
                                                    {0,1,0,1,1,0,1,1,0},
                                                    {0,1,0,1,1,0,1,1,0},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,1,0,1,0,1,0,1,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 2:
                                room = new int[,] { {0,1,1,1,1,1,1,1,0}, 
                                                    {0,0,1,1,1,1,1,0,0}, 
                                                    {0,0,0,1,1,1,0,0,0},
                                                    {0,0,0,1,1,1,0,0,0},
                                                    {0,0,0,1,1,1,0,0,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 3:
                                room = new int[,] { {0,0,1,1,1,1,1,0,0}, 
                                                    {0,1,1,1,1,1,1,1,0}, 
                                                    {0,1,1,1,0,1,1,1,0},
                                                    {0,1,1,0,0,0,1,1,0},
                                                    {0,1,1,0,0,0,1,1,0},
                                                    {0,1,1,1,0,1,1,1,0},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                        }
                        break;
                    case 8:
                        switch(randomRoom) {
                            case 0:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,0,0,0,0,1,1,1}, 
                                                    {0,0,0,1,1,1,1,1,1},
                                                    {0,0,1,1,1,1,1,1,1},
                                                    {0,1,1,1,1,1,1,1,1},
                                                    {0,0,1,1,1,1,1,1,1},
                                                    {0,0,0,1,1,1,1,1,1},
                                                    {0,0,0,0,0,0,1,1,1},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 1: 
                                room = new int[,] { {0,1,1,1,1,1,1,1,0}, 
                                                    {1,1,1,0,0,0,1,1,1}, 
                                                    {1,1,1,1,0,1,1,1,1},
                                                    {1,1,0,1,0,1,0,1,1},
                                                    {1,1,0,1,0,1,0,1,1},
                                                    {1,1,0,1,0,1,0,1,1},
                                                    {1,1,1,0,0,0,1,1,1},
                                                    {0,1,1,1,0,1,1,1,0},
                                                    {0,0,1,0,0,0,1,0,0} };
                                break;
                            case 2:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,1,1,0,0,0,0,0,1}, 
                                                    {0,1,1,1,0,0,0,1,1},
                                                    {0,1,1,1,1,1,1,1,1},
                                                    {0,1,1,1,1,1,1,1,1},
                                                    {0,1,1,1,1,1,1,1,1},
                                                    {0,1,1,1,0,0,0,1,1},
                                                    {0,1,1,0,0,0,0,0,1},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 3:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,1,1,1,1,1,1,0}, 
                                                    {0,1,1,1,1,1,1,1,1},
                                                    {0,1,1,1,0,0,1,1,1},
                                                    {0,1,1,0,0,0,0,1,1},
                                                    {0,1,1,1,0,0,1,1,1},
                                                    {0,1,1,1,1,1,1,1,1},
                                                    {0,0,1,1,1,1,1,1,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                        }
                        break;
                    case 9:
                        switch(randomRoom) {
                            case 0:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,0,0,1,0,0,0,0}, 
                                                    {0,0,0,1,1,1,0,0,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,1,1,1,1,1,1,1,0} };
                                break;
                            case 1: 
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,1,1,1,1,1,1,1,1}, 
                                                    {0,1,0,0,1,1,0,0,1},
                                                    {0,1,0,0,1,1,0,0,1},
                                                    {0,1,1,1,0,0,1,1,1},
                                                    {0,1,1,0,0,0,0,1,1},
                                                    {0,1,1,0,0,0,0,1,1},
                                                    {0,1,1,0,1,1,0,1,1},
                                                    {0,1,1,1,1,1,1,1,1} };
                                break;
                            case 2:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,1,1,1,1,1,1,1,0}, 
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,0,1,1,1,0,0,0},
                                                    {0,0,0,1,1,1,0,0,0},
                                                    {0,0,0,1,1,1,0,0,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,1,1,1,1,1,1,1,0} };
                                break;
                            case 3:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,1,1,1,1,1,0,0}, 
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,1,1,1,0,1,1,1,0},
                                                    {0,1,1,0,0,0,1,1,0},
                                                    {0,1,1,0,0,0,1,1,0},
                                                    {0,1,1,1,0,1,1,1,0},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,0,1,1,1,1,1,0,0} };
                                break;
                        }
                        break;
                    case 10:
                        switch(randomRoom) {
                            case 0:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {1,1,1,0,0,0,0,0,0}, 
                                                    {1,1,1,1,1,1,0,0,0},
                                                    {1,1,1,1,1,1,1,0,0},
                                                    {1,1,1,1,1,1,1,1,0},
                                                    {1,1,1,1,1,1,1,0,0},
                                                    {1,1,1,1,1,1,0,0,0},
                                                    {1,1,1,0,0,0,0,0,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 1: 
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,0,1,1,1,1,0,0,0}, 
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {1,1,1,1,1,0,0,0,0},
                                                    {1,1,1,1,0,0,0,0,0},
                                                    {1,1,1,1,1,0,0,0,0},
                                                    {0,1,1,1,1,1,1,0,0},
                                                    {0,0,1,1,1,1,0,0,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 2:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {1,0,0,0,0,0,1,1,0}, 
                                                    {1,1,0,0,0,1,1,1,0},
                                                    {1,1,1,1,1,1,1,1,0},
                                                    {1,1,1,1,1,1,1,1,0},
                                                    {1,1,1,1,1,1,1,1,0},
                                                    {1,1,0,0,0,1,1,1,0},
                                                    {1,0,0,0,0,0,1,1,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                            case 3:
                                room = new int[,] { {0,0,0,0,0,0,0,0,0}, 
                                                    {0,1,1,1,1,1,1,0,0}, 
                                                    {1,1,1,1,1,1,1,1,0},
                                                    {1,1,1,0,0,1,1,1,0},
                                                    {1,1,0,0,0,0,1,1,0},
                                                    {1,1,1,0,0,1,1,1,0},
                                                    {1,1,1,1,1,1,1,1,0},
                                                    {0,1,1,1,1,1,1,0,0},
                                                    {0,0,0,0,0,0,0,0,0} };
                                break;
                        }
                        break;
                    case 11:
                        switch(randomRoom) {
                            case 0:
                                room = new int[,] { {1,1,1,1,1,1,1,1,1}, 
                                                    {1,1,1,1,1,1,1,1,1}, 
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1} };
                                break;
                            case 1: 
                                room = new int[,] { {0,0,0,1,1,1,0,0,0}, 
                                                    {0,0,1,1,1,1,1,0,0}, 
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,0,1,1,1,1,1,0,0},
                                                    {0,0,0,1,1,1,0,0,0} };
                                break;
                            case 2:
                                room = new int[,] { {1,1,1,1,1,1,1,1,1}, 
                                                    {1,1,1,0,1,0,1,1,1}, 
                                                    {1,1,1,0,1,0,1,1,1},
                                                    {1,0,0,0,1,0,0,0,1},
                                                    {1,1,1,1,1,1,1,1,1},
                                                    {1,0,0,0,1,0,0,0,1},
                                                    {1,1,1,0,1,0,1,1,1},
                                                    {1,1,1,0,1,0,1,1,1},
                                                    {1,1,1,1,1,1,1,1,1} };
                                break;
                            case 3:
                                room = new int[,] { {0,0,0,1,1,1,0,0,0}, 
                                                    {0,1,1,1,1,1,1,1,0}, 
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {1,1,1,1,0,1,1,1,1},
                                                    {1,1,1,0,0,0,1,1,1},
                                                    {1,1,1,1,0,1,1,1,1},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,1,1,1,1,1,1,1,0},
                                                    {0,0,0,1,1,1,0,0,0} };
                                break;
                        }
                        break;
   
                }//switch
                
                for(int k2 = k*scaleFactor; k2 < (k*scaleFactor)+scaleFactor; k2++){
                    for(int l2 = l*scaleFactor; l2 < (l*scaleFactor)+scaleFactor; l2++){
                        levelGenRooms[k2,l2] = room[k2%scaleFactor,l2%scaleFactor];
                    }//for l2
                }//for k2
                
            }//for l
        }//for k
        
        boardHolder = new GameObject("Board").transform;
        for(int i = -1 * (scaleFactor); i < columns + scaleFactor; i++)
        {
            for(int j = -1 * (scaleFactor); j < rows + scaleFactor; j++)
            {
                GameObject toCreate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (i <= -1 || i >= columns || j <= -1 || j >= rows || levelGenRooms[i, j] == 0)
                    toCreate = wallTiles[Random.Range(0, wallTiles.Length)];
                GameObject instance = Instantiate(toCreate, new Vector3(i, j, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    //Gives a random vector3 position on the board and removes double spawns
    Vector3 RandomPosition()
    {
        int workingTile = 0;
        do {
            
            int randomIndex = Random.Range(0, gridPositions.Count);
            int randomRow = (int) gridPositions[randomIndex][0];
            int randomColumn = (int) gridPositions[randomIndex][1];
            workingTile = levelGenRooms[randomRow, randomColumn];

            if (workingTile == 1){
                
                Vector3 randomPosition = gridPositions[randomIndex];
                gridPositions.RemoveAt(randomIndex);
                return randomPosition;
                
            }//if
        } while (workingTile == 0);
        return Vector3.zero;
    }

    //Spawn tiles at random positions such as enemies
    void LayoutObjectAtRandom(GameObject[] tileArray, int objectCount)
    {
        for(int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }
    
    void LayoutExitAtRandom(GameObject[] tileArray)
    {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
    }
    
    //What is called by GameManager to setup new random board 
    public void SetupScene (int level)
    {
        BoardSetup();
        InitialiseList();
        int enemyCount = Random.Range(mazeSize,mazeSize+scaleFactor);
        int itemCount = Random.Range(mazeSize,mazeSize*scaleFactor);
        LayoutObjectAtRandom(enemyTiles, enemyCount);
        LayoutObjectAtRandom(itemTiles, itemCount);
        LayoutExitAtRandom(levelExit);
    }
}
