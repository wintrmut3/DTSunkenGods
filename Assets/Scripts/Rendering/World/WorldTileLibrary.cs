using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewTileLibrary", menuName = "World/Tile Library")]
public class WorldTileLibrary : ScriptableObject 
{
    [System.Serializable]
    public struct TileEntry {
        public TileType type;
        public TileBase tile;
    }

    public List<TileEntry> entries;

    // Optional: Quick access method
    public TileBase GetTile(TileType type) {
        // You can use a Dictionary here internally for O(1) speed, 
        // initialized once on startup.
        return entries.Find(e => e.type == type).tile;
    }

    private void OnValidate() {
    // Check if we have an entry for every enum value
    var enumValues = System.Enum.GetValues(typeof(TileType));
    if (entries.Count != enumValues.Length) {
        Debug.LogWarning("TileLibrary is missing some TileType definitions!");
    }
}
}