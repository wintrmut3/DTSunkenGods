using UnityEngine.Tilemaps;

public enum TileType
{
    NIL=0,
    FOREST=1,
    SAND=2,
    ICE=3,
    WATER=4,
    DEEP_FOREST=5,
    ASHLAND=6,
    MASK=7
}

public enum StrategicResourceType
{
    NONE,
    IRON,
    STONE,
    COAL,
    OIL,
    URANIUM,
    FISH,
    SHEEP
}

public struct WorldTile {
    public TileType tileType;
    public byte z;                        

    public WorldTile (TileType tileType, byte z)
    {
        this.tileType = tileType;
        this.z = z;
    }
}
public class WorldMap {
    public readonly int Width, Height;
    public readonly WorldTile[] Tiles;        
    
    public ref WorldTile Get(int x, int y) => 
        ref Tiles[y * Width + x];   
    
    public int IndexOf(int x, int y) => y * Width + x;

    public WorldMap(int width, int height) {
        Width = width;
        Height = height;
        Tiles = new WorldTile[width * height];
    }
}