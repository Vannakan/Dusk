using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Vector3 = UnityEngine.Vector3;

public class GameController : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

    public GameObject PlayerGameObject;
    public GameObject EnemyGameObject;

    public Tilemap Map;
    public UnityEngine.Vector3 SpawnPosition;

    public event EventHandler PlayerCreated;

    private ActionManager _actionManager;

    private System.Random _random;

    public bool SpawnEnemies;
    public int NumberOfEnemies = 1;


   public Camera Camera;

    protected virtual void OnPlayerCreated(EventArgs e)
    {
        var handler = PlayerCreated;
        handler?.Invoke(this, e);
    }

    void Start()
    {
        Map.CompressBounds();
        Debug.Log(Map.size);
        _random = new System.Random();
        _actionManager = new ActionManager();
        CreatePlayer(CreateRandomSpawn());
    }


    void SpawnRandomEnemies()
    {
        if (SpawnEnemies == true)
        {
            for (int i = 0; i < NumberOfEnemies; i++)
            {
                CreateEnemy(CreateRandomSpawn());
            }
        }

    }
    void Update()
    {
        _actionManager.Update();
        if(Input.GetKeyDown(KeyCode.Insert))
            SpawnRandomEnemies();

    }

    //Move spawning logic into seperate system 
    //make this extension
    Vector3 CreateRandomSpawn() => new Vector3(_random.Next(1, Map.size.x), _random.Next(1, Map.size.y), 0);

    private void CreateEnemy(Vector3 spawnPoint)
    {

        EnemyGameObject = Instantiate(EnemyPrefab);
        var tileCenter = Map.GetCellCenterWorld(Vector3Int.FloorToInt(spawnPoint));
        EnemyGameObject.transform.position = tileCenter;

        var enemyActionResolver = EnemyGameObject.GetComponent<EnemyMediator>();
        enemyActionResolver.Player = PlayerGameObject;
        enemyActionResolver.Map = Map;
        //Player created event

        _actionManager.AddMediator(enemyActionResolver);
    }

    private void CreatePlayer(Vector3 spawnPoint)
    {
        PlayerGameObject = Instantiate(PlayerPrefab);
        var tileCenter = Map.GetCellCenterWorld(Vector3Int.FloorToInt(spawnPoint));
        PlayerGameObject.transform.position = tileCenter;
        var actionResolver = PlayerGameObject.GetComponent<PlayerMediator>();
        actionResolver.Map = Map;

        _actionManager.AddMediator(actionResolver);

        //Camera.transform.position = new Vector3(PlayerGameObject.transform.position.x, PlayerGameObject.transform.position.y,-3);
        //Camera.transform.parent = PlayerGameObject.transform;
    }
}
