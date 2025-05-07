using UnityEngine;
using UnityEngine.Tilemaps;

public class debug : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var tilemap = GetComponent<Tilemap>();
        var bounds = tilemap.cellBounds;
        Debug.Log("Tilemap bounds: " + bounds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
