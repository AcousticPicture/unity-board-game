using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // game / map configuration file
    private GameConfig gameconfig;

    public Character activeCharacter;

    public HashSet<GameObject> sewers;
    public HashSet<GameObject> lamps;

    public int activeRound = 0;

    void Start()
    {
        gameconfig = new GameConfig();
        FindObjectOfType<MapGenerator>().createMap(gameconfig);
        activeCharacter = gameconfig.characters[0];
    }

   

    public GameObject setActiveCharacter(string name)
    {
        Character character = gameconfig.getCharacter(name);
        this.activeCharacter = character;
        Debug.Log("Set active: " + name);

        // return the current position
        var pos = gameconfig.findCharacterPosition(name);
        return gameconfig.map[pos[0], pos[1]].go;
    }

    public MapTile getCharacterPosition(string name)
    {
        var pos = gameconfig.findCharacterPosition(name);
        return gameconfig.map[pos[0], pos[1]].go.GetComponent<MapTile>();
    }

    public void visualizeReachables(HashSet<GameObject> reachables)
    {
        Debug.Log("Visualizing");
        GameObject[] markers = GameObject.FindGameObjectsWithTag("StepMarker");
        foreach (GameObject marker in markers)
            GameObject.Destroy(marker);

        foreach (var tile in reachables)
        {
            var info = tile.GetComponent<MapTile>();
            Debug.Log("x: " + info.x + " y: " + info.y);
            GameObject go_marker = (GameObject)Instantiate(Resources.Load("StepMarker"), tile.transform.position, Quaternion.identity);

            //MeshRenderer mr = tile.GetComponentInChildren<MeshRenderer>();
            //mr.material.color = info.info.type == Tile.Types.Sewer ? Color.black : Color.red;

        }
    }



}
