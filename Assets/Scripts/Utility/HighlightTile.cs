using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightTile : MonoBehaviour
{
    public Tilemap TileMap;
    public Camera Camera;
//    public GameObject Player;

    private Vector3 _tileWidth;

    private int _maxMovementDistance = 1;

    private Tile _targetTile;

    // Start is called before the first frame update
    void Start()
    {
        if(TileMap == null)
            throw new UnityException("TileMap cannot be null");
        
        if(Camera == null)
            throw new UnityException("Camera cannot be null");


        _tileWidth = TileMap.cellSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            var mousePosition = GetMousePositionRelativeToTileMap();
            Debug.Log(mousePosition);
            var result = TileMap.GetTile<Tile>(mousePosition);
            if(result != null)
            {
                ColorTile(mousePosition);
              //  SetPlayerTile(mousePosition);
            }
            else
                Debug.Log("This is not a tile");
        }

    }

    private void ColorTile(Vector3Int tilePos)
    {
        TileMap.SetTileFlags(tilePos, TileFlags.None);
        TileMap.SetColor(tilePos, Color.black);
    }

    private Vector3Int GetMousePositionRelativeToTileMap()
    {
        var mousePosition = Input.mousePosition;
        var mousePositionRelativeToTileMap = TileMap.WorldToCell(Camera.ScreenToWorldPoint(mousePosition));
        return mousePositionRelativeToTileMap;
    }

    //private void SetPlayerTile(Vector3Int tilePosition)
    //{
    //    //var tileCenter = TileMap.GetCellCenterWorld(tilePosition);
    //    //var playerPos = Player.transform.position;
    //    //var playerTile = TileMap.GetCellCenterWorld(Vector3Int.RoundToInt(playerPos));

    //    //Debug.Log($"player center: ${playerPos} tile center: ${tileCenter}");

    //    //if (tileCenter.x >= playerPos.x - _maxMovementDistance && tileCenter.x <= playerPos.x + _maxMovementDistance &&
    //    //    tileCenter.y <= playerPos.y + _maxMovementDistance && tileCenter.y >= playerPos.y - _maxMovementDistance)
    //    //    Player.transform.position = tileCenter;
    //    //else
    //    //    Debug.Log("Cant move");
    //}
}

//World tile
//Has reference to entity standing on that tile
//MAybe some other useful info about the world and state of tile