using System;
using UnityEngine.Tilemaps;

public class WorldGenerator
{
    public static WorldMap GenerateWorld(GameConfig config)
    {
        // Given a game config, generate a world
        WorldMap map = new WorldMap(config.worldWidth, config.worldHeight);

        // if (DebugSettings.d.DEBUG_LoadWorldGenFromSave)
        // {
        //     InitializeMapFromSaveData();
        //     return;
        // }
        
        var noise = new FastNoiseLite(0);
        float noiseScale = 5;
        float falloff = 10;
        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                float z = (noise.GetNoise(x * noiseScale, y * noiseScale) + 1) / 2f * 10;
                // island - reduce outer height
                z /= Math.Clamp((MathF.Abs(x - map.Width / 2) + MathF.Abs(y - map.Height / 2)) * falloff, 1, 10);

                map.Tiles[map.IndexOf(x,y)] = new WorldTile(TileType.NIL, (byte) z);
            }
        }        
        
        return map;
    }

}