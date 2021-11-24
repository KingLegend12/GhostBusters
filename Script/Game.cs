using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; 
public class Game : MonoBehaviour
{
    
    public Tile[,] grid = new Tile[6, 15];
    public GameObject[,] Textgrid = new GameObject[6, 15];
    
    public double probabilitycount = 2; 
    public int gx;
    public  int gy;
    public  int lastcheckedX;
    public  int lastcheckedY;


    public double JointTableProbability(string color, int DistanceFromGhost) 
     { 
        //Table 1
         if(color.Equals("yellow") && (DistanceFromGhost==3 || DistanceFromGhost==4) ) return 0.5;
         if(color.Equals("red") && (DistanceFromGhost==3 || DistanceFromGhost==4)) return 0.05;
         if(color.Equals("green") && (DistanceFromGhost==3 || DistanceFromGhost==4)) return 0.3;
         if(color.Equals("orange") && (DistanceFromGhost==3 || DistanceFromGhost==4)) return 0.15;

        //Table2
         if(color.Equals("yellow") && (DistanceFromGhost==1 || DistanceFromGhost==2) ) return 0.3;
         if(color.Equals("red") && (DistanceFromGhost==1 || DistanceFromGhost==2)) return 0.15;
         if(color.Equals("green") && (DistanceFromGhost==1 || DistanceFromGhost==2)) return 0.05;
         if(color.Equals("orange") && (DistanceFromGhost==1 || DistanceFromGhost==2)) return 0.5;

        //Table3
         if(color.Equals("yellow") && DistanceFromGhost>=5 ) return 0.3;
         if(color.Equals("red") && DistanceFromGhost>=5) return 0.05;
         if(color.Equals("green") && DistanceFromGhost>=5) return 0.5;
         if(color.Equals("orange") && DistanceFromGhost>=5) return 0.15;

        //Table4
         if(color.Equals("red") && DistanceFromGhost==0) return 0.7;
         if(color.Equals("yellow") && DistanceFromGhost==0) return 0.1;
         if(color.Equals("green") && DistanceFromGhost==0) return 0.1;
         if(color.Equals("orange") && DistanceFromGhost==0) return 0.1;

         return 0;
    }
    
     
     
    
    void Start() { 
        PlaceGhost();
        

    }
    

     /* void CalculateBayesianProbability(int lastcheckedx, int lastcheckedy, int ghostx, int ghosty) 
    {
        int Distance=0, DistanceX=0, DistanceY=0;
         for (int y =0 ; y< 15; y++) { 
            for (int x = 0; x < 6; x++)
            {
                if(x!= lastcheckedx && y!= lastcheckedy) {
                    if(x>=ghostx) DistanceX = x-ghostx;
                             else DistanceX = ghostx-x;
                    if(y>=ghosty) DistanceY = y-ghosty;
                             else DistanceX = ghosty-y;
                    Distance=DistanceX+DistanceY;
                  

                }
                 else if(x== lastcheckedx && y== lastcheckedy) 
                 { 
                        probabilitycount = JointTableProbability("orange", Distance) * 2;
                 }
            }
         }
       
    }*/


    public void CheckInputGrid() { 
          int Distance=0, DistanceX=0, DistanceY=0;
            
          
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
                   
                      if(lastcheckedX>=gx) DistanceX = lastcheckedX-gx;
                             else DistanceX = gx-lastcheckedX;
                    if(lastcheckedY>=gy) DistanceY = lastcheckedY-gy;
                             else DistanceY = gy-lastcheckedY;
                    Distance=DistanceX+DistanceY;
                    Tile tile = grid[x, y];
                    grid[x,y].probability.text=2.ToString();

                     if(JointTableProbability("green", Distance)>=0.5 )
                     { 
                            grid[x,y].probability.text=Math.Round((JointTableProbability("green", Distance)*1/Distance),3).ToString();

                             for (int yy =0 ; yy< 15; yy++) { 
                        for (int xx = 0; xx < 6; xx++)
                                                   {
                                   if(xx!= lastcheckedX && yy!= lastcheckedY) 
                                   {   
                                        if(xx>=gx) DistanceX = xx-gx;
                                         else DistanceX = gx-xx;
                                     if(yy>=gy) DistanceY = yy-gy;
                                           else DistanceY = gy-yy;
                                           Distance=DistanceX+DistanceY;
                                       if(JointTableProbability("green", Distance)>=0.5)  grid[xx,yy].probability.text=Math.Round((JointTableProbability("green", Distance)*1/Distance),3).ToString();
                                        if(JointTableProbability("yellow", Distance)>=0.5) grid[xx,yy].probability.text=Math.Round((JointTableProbability("yellow", Distance)*1/Distance),3).ToString();
                                        if(JointTableProbability("orange", Distance)>=0.5) grid[xx,yy].probability.text=Math.Round((JointTableProbability("orange", Distance)*1/Distance),3).ToString();
                                        if(JointTableProbability("red", Distance)>=0.5) grid[xx,yy].probability.text=Math.Round((JointTableProbability("red", Distance)*1/(Distance+1)),3).ToString();

                                   }
                                                      }
                                          }
                            
                    } 
                         else if (JointTableProbability("yellow", Distance)>=0.5 ) {
                                                       grid[x,y].probability.text=Math.Round((JointTableProbability("yellow", Distance)*1/Distance), 3).ToString();

                                             for (int yy =0 ; yy< 15; yy++) { 
                        for (int xx = 0; xx < 6; xx++)
                                                   {
                                   if(xx!= lastcheckedX && yy!= lastcheckedY) 
                                   {   
                                        if(xx>=gx) DistanceX = xx-gx;
                                         else DistanceX = gx-xx;
                                     if(yy>=gy) DistanceY = yy-gy;
                                           else DistanceY = gy-yy;
                                           Distance=DistanceX+DistanceY;
                                    if(JointTableProbability("yellow", Distance)>=0.5) grid[xx,yy].probability.text=Math.Round((JointTableProbability("yellow", Distance)*1/Distance), 3).ToString();
                                       
                                       if(JointTableProbability("green", Distance)>=0.5)  grid[xx,yy].probability.text=Math.Round((JointTableProbability("green", Distance)*1/Distance), 3).ToString();
                                        if(JointTableProbability("orange", Distance)>=0.5) grid[xx,yy].probability.text=Math.Round((JointTableProbability("orange", Distance)*1/Distance), 3).ToString();
                                        if(JointTableProbability("red", Distance)>=0.5) grid[xx,yy].probability.text=Math.Round((JointTableProbability("red", Distance)*1/(Distance+1)), 3).ToString();

                                   }
                                                      }
                                          }

                        }
                              else if (JointTableProbability("orange", Distance)>=0.5  ) {
                                                 grid[x,y].probability.text=Math.Round((JointTableProbability("orange", Distance)*1/Distance), 3).ToString();

                                                  for (int yy =0 ; yy< 15; yy++) { 
                        for (int xx = 0; xx < 6; xx++)
                                                   {
                                   if(xx!= lastcheckedX && yy!= lastcheckedY) 
                                   {   
                                        if(xx>=gx) DistanceX = xx-gx;
                                         else DistanceX = gx-xx;
                                     if(yy>=gy) DistanceY = yy-gy;
                                           else DistanceY = gy-yy;
                                           Distance=DistanceX+DistanceY;
                                      if(JointTableProbability("yellow", Distance)>=0.5)   grid[xx,yy].probability.text=Math.Round((JointTableProbability("yellow", Distance)*1/Distance), 3).ToString();
                                       if(JointTableProbability("green", Distance)>=0.5)  grid[xx,yy].probability.text=Math.Round((JointTableProbability("green", Distance)*1/Distance), 3).ToString();
                                        if(JointTableProbability("red", Distance)>=0.5) grid[xx,yy].probability.text=Math.Round((JointTableProbability("red", Distance)*1/(Distance+1)),3).ToString();
                                       if(JointTableProbability("orange", Distance)>=0.5) grid[xx,yy].probability.text=Math.Round((JointTableProbability("orange", Distance)*1/Distance),3).ToString();

                                   }
                                                      }
                                          }

                        }
                         else { 
                            grid[x,y].probability.text=Math.Round((JointTableProbability("red", Distance)*1/(Distance+1)+0.3),3).ToString();
                            
                             for (int yy =0 ; yy< 15; yy++) { 
                        for (int xx = 0; xx < 6; xx++)
                                                   {
                                   if(xx!= lastcheckedX && yy!= lastcheckedY) 
                                   {   
                                        if(xx>=gx) DistanceX = xx-gx;
                                         else DistanceX = gx-xx;
                                     if(yy>=gy) DistanceY = yy-gy;
                                           else DistanceX = gy-yy;
                                           Distance=DistanceX+DistanceY;
                                  if(JointTableProbability("yellow", Distance)>=0.5)  grid[xx,yy].probability.text=Math.Round((JointTableProbability("yellow", Distance)*1/Distance),3).ToString();
                                 if(JointTableProbability("orange", Distance)>=0.5)   grid[xx,yy].probability.text=Math.Round((JointTableProbability("orange", Distance)*1/Distance),3).ToString();
                                   if(JointTableProbability("green", Distance)>=0.5)  grid[xx,yy].probability.text=Math.Round((JointTableProbability("green", Distance)*1/Distance),3).ToString();

                                   }
                                                      }
                                          }

                         }
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
                PlaceNoisyPrint();
                PlaceColor(x, y);
                 
                
            } else { 
                PlaceGhost();
            }

    }
    public void PlaceNoisyPrint()  
    {
        int x = UnityEngine.Random.Range(0, 6);
        int y = UnityEngine.Random.Range(0, 15);
            if( grid[x, y]==null )
             { 
                Tile noisyPrint =  Instantiate(Resources.Load("Prefabs/red", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;
                grid[x, y]=noisyPrint;
            } else { 
                PlaceNoisyPrint();
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
                             else DistanceY = Y-y;
                    Distance=DistanceX+DistanceY;

                    
                    
                    if(JointTableProbability("green", Distance)>=0.5 && JointTableProbability("yellow", Distance)<0.5 && JointTableProbability("orange", Distance)<0.5 && grid[x,y]==null)
                     { 
                        Tile color =  Instantiate(Resources.Load("Prefabs/green", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;
                        grid[x, y]=color;

                    } 
                         else if (JointTableProbability("yellow", Distance)>=0.5 && grid[x,y]==null) {
                        Tile color =  Instantiate(Resources.Load("Prefabs/yellow", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;
                        grid[x, y]=color;
                        }
                              else if (JointTableProbability("orange", Distance)>=0.5  && grid[x,y]==null) {
                        Tile color =  Instantiate(Resources.Load("Prefabs/orange", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;
                        grid[x, y]=color;
                        }
                                 
                                    
                
            }
        }
    }

   
}
