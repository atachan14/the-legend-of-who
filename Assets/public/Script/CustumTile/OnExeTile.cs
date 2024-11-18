using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "OnExeTile", menuName = "Tiles/OnExeTile")]
public class OnExeTile : Tile
{
    public string tileName;
    public string sceneName;



    public void OnExe()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            Debug.Log("シーンをロードします: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("シーン名が設定されていません");
        }
    }
}