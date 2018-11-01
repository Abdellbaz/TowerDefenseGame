using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {

    private Tile[,] grid_raster;
    public int width, height;
    Vector2 pos;

    public Grid(int width, int height, GameObject tilePrefab)
    {
        grid_raster = new Tile[width, height];
        pos.x = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        pos.y = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.y;
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Tile tile = new Tile(tilePrefab);
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
            }
        }
    }

    public Tile getTile(int x, int y)
    {
        return grid_raster[x, y];
    }

    public GameObject getTileAsGameObject(int x, int y)
    {
        return grid_raster[x, y].getObject();
    }

    public void setTexture(int x, int y, Sprite sprite)
    {
        grid_raster[x, y].getObject().GetComponent<SpriteRenderer>().sprite = sprite;
    }
    
    public void FillRect(int Xstart, int Ystart, int Xend, int Yend, Sprite sprite)
    {
        for(int i = 0; i < grid_raster.GetLength(1); i++)
            for(int j = 0; j < grid_raster.GetLength(0); j++)
            {
               if(j >= Xstart && j <= Xend && i >= Ystart && i <= Yend)
                {
                    grid_raster[j, i].getObject().GetComponent<SpriteRenderer>().sprite = sprite;
                }
            }
    }

    public void FillRect(Vector2 begin, Vector2 end, Sprite sprite)
    {
        for (int i = 0; i < grid_raster.GetLength(1); i++)
            for (int j = 0; j < grid_raster.GetLength(0); j++)
            {
                if (j >= begin.x && j <= end.x && i >= begin.y && i <= end.y)
                {
                    grid_raster[j, i].getObject().GetComponent<SpriteRenderer>().sprite = sprite;
                }
            }
    }
    
    /*Use Vector4's for begin x/y and end x/y*/
    public void FillRect(Sprite sprite, params Vector4[] positions)
    {
        for(int k = 0; k < positions.Length; k++)
        {
            for (int i = 0; i < grid_raster.GetLength(1); i++)
                for (int j = 0; j < grid_raster.GetLength(0); j++)
                {
                    if (j >= positions[k].x && j <= positions[k].z && i >= positions[k].y && i <= positions[k].w)
                    {
                        grid_raster[j, i].getObject().GetComponent<SpriteRenderer>().sprite = sprite;
                    }
                }
        }
    }

}
