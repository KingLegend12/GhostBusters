using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    
    public Tile[,] grid = new Tile[6, 15];
    
    public int gx;
    public  int gy;
    public  int lastcheckedX;
    public  int lastcheckedY;

    void Start() { 
        PlaceGhost();
    }
    
    public void CheckInputGrid() { 
          
            
          
            if(Input.GetButtonDown("Fire1")) 
            { 
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    int a = Mathf.RoundToInt(mousePosition.x);
                    int b = Mathf.RoundToInt(mousePosition.y);
                    if(a>5 || b >14 || a<0 || b<0)
                     {      
                            return;
                    }
                     mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    int x = Mathf.RoundToInt(mousePosition.x);
                    int y = Mathf.RoundToInt(mousePosition.y);
                    lastcheckedX=x; lastcheckedY=y;
                   // Debug.Log(x+"  "+ y);
                   
                    Tile tile = grid[x, y];

                    tile.SetIsCovered(false);
            }
    }

    public void PlaceGhost () 
    { 
                 int x = UnityEngine.Random.Range(0, 6);
                 int y = UnityEngine.Random.Range(0, 15);
            if( grid[x, y]==null)
             { 
                Tile ghostTile =  Instantiate(Resources.Load("Prefabs/red", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;
                grid[x, y]=ghostTile;
                gx=x; gy=y;
                Debug.Log("("+gx+", "+ gy+ ")");
                
                PlaceColor(x, y);
                 
                
            } else { 
                PlaceGhost();
            }

    }
    
    public void PlaceColor(int X, int Y)
    {   int DistanceX=0, DistanceY=0, Distance=0;
        for (int y =0 ; y< 15; y++) { 
            for (int x = 0; x < 6; x++)
            {
                
                    if(x>=X) DistanceX = x-X;
                             else DistanceX = X-x;
                    if(y>=Y) DistanceY = y-Y;
                             else DistanceX = Y-y;
                    Distance=DistanceX+DistanceY;

                    if(Distance>=5) {
                        Tile color =  Instantiate(Resources.Load("Prefabs/green", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;
                        grid[x, y]=color;
                        }
                         else if (Distance==3 || Distance == 4) {
                        Tile color =  Instantiate(Resources.Load("Prefabs/yellow", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;
                        grid[x, y]=color;
                        }
                              else if (Distance==2 || Distance == 1) {
                        Tile color =  Instantiate(Resources.Load("Prefabs/orange", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;
                        grid[x, y]=color;
                        }
                                 
                                    
                
            }
        }
    }

   
}
