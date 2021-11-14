using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    public GameObject[,] grid = new GameObject[6, 15];
    // Start is called before the first frame update
    void Start()
    {
        PlaceGhost();
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaceGhost () 
    { 
             int x = UnityEngine.Random.Range(0, 6);
             int y = UnityEngine.Random.Range(0, 15);

            if( grid[x, y]==null)
             { 
                GameObject ghostTile =  Instantiate(Resources.Load("Prefabs/ghostpic", typeof(GameObject)), new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                grid[x, y]=ghostTile;

                Debug.Log("("+x+", "+ y+ ")");
                PlaceColor(x, y);
                
            } else { 
                PlaceGhost();
            }

    }

    void PlaceColor(int X, int Y)
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
                        GameObject color =  Instantiate(Resources.Load("Prefabs/green", typeof(GameObject)), new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                        grid[x, y]=color;
                        }
                         else if (Distance==3 || Distance == 4) {
                        GameObject color =  Instantiate(Resources.Load("Prefabs/yellow", typeof(GameObject)), new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                        grid[x, y]=color;
                        }
                              else if (Distance==2 || Distance == 1) {
                        GameObject color =  Instantiate(Resources.Load("Prefabs/orange", typeof(GameObject)), new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                        grid[x, y]=color;
                        }
                                  else if (Distance==0) {
                        GameObject color =  Instantiate(Resources.Load("Prefabs/red", typeof(GameObject)), new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                        grid[x, y]=color;
                        }
                                    
                
            }
        }
    }
}
