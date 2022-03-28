using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Resources.Tiles
{
    public class DuskTile : TileBase
    {

        public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
        {
            go = new GameObject("DuskTile", typeof(IsTileOccupied), typeof(TilemapCollider2D));
            return base.StartUp(position, tilemap, go);
        }

        #if UNITY_EDITOR
        [MenuItem("Assets/Create/DuskTile")]
        public static void CreateRoadTile()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Dusk Tile", "New Dusk Tile", "Asset", "Save Dusk Tile", "Assets");
            if (path == "")
                return;
            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<DuskTile>(), path);
        }
        #endif
    }
}

