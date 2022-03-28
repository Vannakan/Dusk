using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts
{
    public class LightingTile : TileBase
    {
        [SerializeField]
        public GameObject LightNodePrefab;

        [SerializeField]
        public Sprite Sprite;

        //TODO: tile animations?
        private Animator _animator;

        public LightingTile()
        {
            Debug.Log("TILE");
        }
        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            if (LightNodePrefab) tileData.gameObject = LightNodePrefab;

            if (Sprite) tileData.sprite = Sprite;
            base.GetTileData(position, tilemap, ref tileData);
        }

        public override void RefreshTile(Vector3Int position, ITilemap tilemap)
        {
            base.RefreshTile(position, tilemap);
        }

        public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
        {
          //  if (go)
              //  go.transform.position = new Vector3(-1, -1, 0);
            return base.StartUp(position, tilemap, go);
        }


        #if UNITY_EDITOR
        [MenuItem("Assets/Create/LightingTile")]
        public static void CreateLightingTile()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Lighting tile", "New Lighting Tile", "Asset", "Save Lighting Tile", "Assets");
            if (string.IsNullOrEmpty(path))
                return;
            AssetDatabase.CreateAsset(CreateInstance<LightingTile>(), path);
        }

        #endif

    }
}
