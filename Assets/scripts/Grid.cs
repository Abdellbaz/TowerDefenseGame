using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {

    private Tile[,] grid_raster;
    public int width, height;
    private float posx, posy;
    public Grid(int width, int height, GameObject tilePrefab)
    {
        grid_raster = new Tile[width, height];
        posx = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        posy = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.y;

        tilePrefab.transform.position = new Vector2(-12f, 6f);
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //MonoBehaviour.print("1: " + tilePrefab.transform.position.x);
                Tile tile = new Tile(tilePrefab);
                //MonoBehaviour.print("2: " + tilePrefab.transform.position.x);
                tile.setPosition(j * tile.getDimensions().x, i * tile.getDimensions().y);
                grid_raster[j, i] = tile;
            }
        }

        this.width = width;
        this.height = height;
    }

    public void Display()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                grid_raster[j, i].getObject().SetActive(true);
                MonoBehaviour.Instantiate(grid_raster[j, i].getObject(), new Vector2(j * posx, i * posy), Quaternion.identity);
            }
        }
    }

    public Tile getTile(int x, int y)
    {
        return grid_raster[x, y];
    }

    public void setTexture(int x, int y, GameObject tile)
    {
        tile.transform.position = grid_raster[x,y].getObject().transform.position;
        grid_raster[x, y].setObject(tile);
    }

    public void FillRect(int Xstart, int Ystart, int Xend, int Yend, GameObject tile)
    {
        for(int i = 0; i < grid_raster.GetLength(1); i++)
            for(int j = 0; j < grid_raster.GetLength(0); j++)
            {
               if(j >= Xstart && j <= Xend && i >= Ystart && i <= Yend)
                {
                    tile.transform.position = grid_raster[j, i].getObject().transform.position;
                    grid_raster[j,i].setObject(tile);
                }
            }
    }

    public void FillRect(Vector2 begin, Vector2 end, GameObject tile)
    {
        for (int i = 0; i < grid_raster.GetLength(1); i++)
            for (int j = 0; j < grid_raster.GetLength(0); j++)
            {
                if (j >= begin.x && j <= end.x && i >= begin.y && i <= end.y)
                {
                    tile.transform.position = grid_raster[j, i].getObject().transform.position;
                    grid_raster[j, i].setObject(tile);
                }
            }
    }

    public GameObject getTileAsGameObject(int x, int y)
    {
        return grid_raster[x, y].getObject();
    }

    public enum Turn
    {
        LEFT_UP, LEFT_DOWN, DOWN_LEFT, RIGHT_DOWN, RIGHT_UP
    }

    public Turn[] FindWalkPattern(GameObject sprite, int turningPoints)
    {
        Sprite texture = sprite.GetComponent<SpriteRenderer>().sprite;

        Turn[] points = new Turn[turningPoints];
        int k = 0;

        for(int i = 0; i < points.Length; i++)
        {
            MonoBehaviour.print(points[i]);
        }

        for (int i = 0; i < grid_raster.GetLength(1); i++)
        {
            for (int j = 0; j < grid_raster.GetLength(0); j++)
            {
                if(grid_raster[j,i].getObject().GetComponent<SpriteRenderer>().sprite == sprite)
                {
                    Turn direction = Turn.DOWN_LEFT;
                    bool left = false, right = false, up = false, down = false;
                    MonoBehaviour.print("test");

                    if (grid_raster[j - 1, i].getObject().GetComponent<SpriteRenderer>().sprite == sprite)
                    {
                        left = true;
                    }
                    if (grid_raster[j + 1, i].getObject().GetComponent<SpriteRenderer>().sprite == sprite)
                    {
                        right = true;
                    }
                    if (grid_raster[j, i + 1].getObject().GetComponent<SpriteRenderer>().sprite == sprite)
                    {
                        up = true;
                    }
                    if (grid_raster[j, i - 1].getObject().GetComponent<SpriteRenderer>().sprite == sprite)
                    {
                        down = true;
                    }

                    if((down && up)||(left && right))
                    {
                        //do nothing
                        MonoBehaviour.print("do nothing");
                    }
                    else
                    {
                        if ((up && right) && (!down && !left))
                        {
                            //LEFT_&_UP
                            //
                            ////
                            direction = Turn.LEFT_UP;
                            points[k] = direction;
                            MonoBehaviour.print("test");
                        }
                        if (down && right)
                        {
                            //LEFT_&_DOWN
                            ////
                            //
                            direction = Turn.LEFT_DOWN;
                            points[k] = direction;
                            MonoBehaviour.print("test1");
                        }
                        else if (left && up)
                        {
                            //DOWN & LEFT
                            //
                            ////
                            direction = Turn.DOWN_LEFT;
                            points[k] = direction;
                            MonoBehaviour.print("test2");
                        }
                        else if (left && down)
                        {
                            //RIGHT & DOWN
                            ////
                            //
                            direction = Turn.RIGHT_DOWN;
                            points[k] = direction;
                            MonoBehaviour.print("test3");
                        }
                        k += 1;
                    }
                }
            }
        }
        return points;
    }

}
