using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "CustomTile", menuName = "Tiles/CustomTile")]
public class CustomTile : Tile
{
    public string tileName;
    public bool isNopass = false;
    public string sceneName;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);

        if (isNopass)
        {
            tileData.colliderType = Tile.ColliderType.Grid; // �ʍs�s�^�C��: �O���b�h�T�C�Y�̃R���C�_�[
        }
        else
        {
            tileData.colliderType = Tile.ColliderType.None; // �R���C�_�[�Ȃ�
        }
    }


    public void OnPlayerStep()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}