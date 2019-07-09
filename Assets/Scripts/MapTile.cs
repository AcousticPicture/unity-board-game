using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapTile : MonoBehaviour
{

    private GameManager gameManager;

    // positions in tile array
    public int x;
    public int y;
    public Tile info;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp()
    {   
        // Check if Mouse is over UI-Element. Don't do anything if it is.
        //if(EventSystem.current.IsPointerOverGameObject())
        //{
        //    return;
        //}
        gameManager.activeCharacter.characterGO.GetComponent<CharacterToken>().moveTo(this.gameObject);
    }

    public HashSet<GameObject> getNeighbors()
    {
        HashSet<GameObject> neighbors = new HashSet<GameObject>();

        GameObject top = GameObject.Find("Tile_" + x + "_" + (y + 1));
        Debug.Log(top);
        if (top && top.GetComponent<MapTile>() && top.GetComponent<MapTile>().info.isAccessible())
            neighbors.Add(top);

        GameObject bottom = GameObject.Find("Tile_" + x + "_" + (y + 1));
        if (bottom && bottom.GetComponent<MapTile>() && bottom.GetComponent<MapTile>().info.isAccessible())
            neighbors.Add(bottom);

        if(x % 2 == 0) // even column 
        {
            GameObject topRight = GameObject.Find("Tile_" + (x - 1) + "_" + (y + 1));
            if (topRight && topRight.GetComponent<MapTile>() && topRight.GetComponent<MapTile>().info.isAccessible())
                neighbors.Add(topRight);

            GameObject bottomRight = GameObject.Find("Tile_" + (x - 1) + "_" + y);
            if (bottomRight && bottomRight.GetComponent<MapTile>() && bottomRight.GetComponent<MapTile>().info.isAccessible())
                neighbors.Add(bottomRight);

            GameObject topLeft = GameObject.Find("Tile_" + (x + 1) + "_" + (y + 1));
            if (topLeft && topLeft.GetComponent<MapTile>() && topLeft.GetComponent<MapTile>().info.isAccessible())
                neighbors.Add(topLeft);

            GameObject bottomLeft = GameObject.Find("Tile_" + (x + 1) + "_" + y);
            if (bottomLeft && bottomLeft.GetComponent<MapTile>() && bottomLeft.GetComponent<MapTile>().info.isAccessible())
                neighbors.Add(bottomLeft);

        } else  { // odd column

            GameObject topRight = GameObject.Find("Tile_" + (x - 1) + "_" + y);
            if (topRight && topRight.GetComponent<MapTile>() && topRight.GetComponent<MapTile>().info.isAccessible())
                neighbors.Add(topRight);

            GameObject bottomRight = GameObject.Find("Tile_" + (x - 1) + "_" + (y - 1) );
            if (bottomRight && bottomRight.GetComponent<MapTile>() && bottomRight.GetComponent<MapTile>().info.isAccessible())
                neighbors.Add(bottomRight);

            GameObject topLeft = GameObject.Find("Tile_" + (x + 1) + "_" + y);
            if (topLeft && topLeft.GetComponent<MapTile>() && topLeft.GetComponent<MapTile>().info.isAccessible())
                neighbors.Add(topLeft);

            GameObject bottomLeft = GameObject.Find("Tile_" + (x + 1) + "_" + (y - 1));
            if (bottomLeft && bottomLeft.GetComponent<MapTile>() && bottomLeft.GetComponent<MapTile>().info.isAccessible())
                neighbors.Add(bottomLeft);
        }

        Debug.Log("Neighbors: " + neighbors.Count);
        return neighbors;
    }

    public HashSet<GameObject> getAllInReach(int maxDistance)
    {
        HashSet<GameObject> reachables = getNeighbors();
        Debug.Log("getting all");
        for (int i = 1; i < maxDistance; i++)
        {
            Debug.Log("Step: " + i);
            HashSet<GameObject> currLevel = new HashSet<GameObject>();
            foreach (var tile in reachables)
            {
                var info = tile.GetComponent<MapTile>();
                Debug.Log("x: " + info.x + " y: " + info.y);
                var currTile = tile.GetComponent<MapTile>();
                currLevel.UnionWith(currTile.getNeighbors());

                // add all sewers if one of the tile is a sewer (acts like a tunnel)
                // all sewers are reachable
                if(currTile.info.type == Tile.Types.Sewer)
                {
                    var sewers = new HashSet<GameObject>(GameObject.FindGameObjectsWithTag("Sewer"));
                    currLevel.UnionWith(sewers);
                }
            }
            reachables.UnionWith(currLevel);
        }
        return reachables;
    }
}
