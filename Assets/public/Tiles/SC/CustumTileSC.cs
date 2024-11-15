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
    public bool noPass = false;
    public string sceneName;

    public int onAddHP;
   


    public void OnPlayerStep()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}