using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public Tilemap darkMap;
    public Tilemap blurredMap;
    public Tilemap backgroundMap;

    public Tile darkTile;
    public Tile blurredTile;

    // Start is called before the first frame update
    void Start()
    {
        darkMap.origin = blurredMap.origin = backgroundMap.origin;
        darkMap.size = blurredMap.size = backgroundMap.size;

        foreach (Vector3Int p in darkMap.cellBounds.allPositionsWithin)
        {
            darkMap.SetTile(p, darkTile);
        }

        foreach (Vector3Int p in blurredMap.cellBounds.allPositionsWithin)
        {
            blurredMap.SetTile(p, blurredTile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishLevel()
    {
        SceneManager.LoadScene("End");
    }
}
