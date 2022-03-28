using UnityEngine;
using UnityEngine.Tilemaps;

public class IsTileOccupied : MonoBehaviour
{
    public bool IsOccupied { get; private set; }

    public void Awake()
    {
        var collider = GetComponent<TilemapCollider2D>();
        if(collider != null)
            collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsOccupied = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsOccupied = false;
    }
}
