// GameLoop              ← outermost, owns game lifecycle
// GameLoop    ← exists for the entire application lifetime
using UnityEngine;

public class GameLoop: MonoBehaviour
{
    [SerializeField] private WorldRenderer _worldRenderer;

    private SessionLoop _session;
    
    // MOCK
    void Start()
    {
        GameConfig defaultConfig;
        defaultConfig.worldHeight = 128;
        defaultConfig.worldWidth = 256;

        StartNewGame(defaultConfig);
    }

    public void StartNewGame(GameConfig config) {
        var world = WorldGenerator.GenerateWorld(config);
        _session = new SessionLoop(world, _worldRenderer);
        _session.Initialize();
    }

    // public void LoadGame(SaveData save) {
    //     var world = Serializer.Deserialize(save);
    //     _session = new SessionLoop(world, _worldRenderer);
    // }

    
    public void Update()
    {
        TickSession();
    }

    public void TickSession()
    {
        // For realtime effects - process input from player, play animations etc
        _session.Tick();
    }

}