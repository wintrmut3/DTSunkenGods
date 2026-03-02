
using UnityEngine;
using UnityEngine.Tilemaps;
public class WorldRenderer : MonoBehaviour {
    public Tilemap worldTilemap;
    private WorldMap _world;
    [SerializeField]
    private WorldTileLibrary tileLib;
    public void Initialize(WorldMap world) {
        // Called once at session start - spawn tile visuals, set up camera bounds etc.
        _world = world;

        BakeWorldIntoTilemap(_world);
    }
    
    public void Sync(WorldMap world) {
        // read world state, update visuals

    }

    void BakeWorldIntoTilemap(WorldMap worldMap)
    {
        int w = worldMap.Width;
        int h = worldMap.Height;
        worldTilemap.ClearAllTiles();

        // Create an array of TileBase objects to match the map size
        TileBase[] tileArray = new TileBase[w * h];
        string s = "";
        
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                TileType type = worldMap.Tiles[worldMap.IndexOf(x,y)].tileType;
                tileArray[x + y * w] = tileLib.entries[(int)type].tile;
                s+=((int) type)+"";
            }
            s+="\n";
        }
        Debug.Log(s);

        // Set all tiles at once for efficiency
        BoundsInt area = new BoundsInt(0, 0, 0, w, h, 1);
        worldTilemap.SetTilesBlock(area, tileArray);   
    }
}