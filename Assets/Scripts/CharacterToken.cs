using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterToken : MonoBehaviour
{
    private GameManager gameManager;
    public Character info;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // TODO: not every character can be moved all the time
    void OnMouseUp()
    {

        GameObject pos = gameManager.setActiveCharacter(info.name);
        MapTile mt = pos.GetComponent<MapTile>();
        HashSet<GameObject> reachables = mt.getAllInReach(gameManager.activeCharacter.maxDistance);
        gameManager.visualizeReachables(reachables);
    }

    // Move the character from one tile to another when clicked
    public void moveTo(GameObject destination)
    {

        // If Tile is blocked, dont move to it
        MapTile mt = destination.GetComponent<MapTile>();
        Tile newTile = mt.info;
        int[] newPos = { mt.x, mt.y };
        if (!newTile.isAccessible())
        {
            Debug.Log("Tile not accessible");
            return;
        }

        MapTile old_mt = gameManager.getCharacterPosition(info.name);
        Tile oldTile = old_mt.info;
        int[] oldPosition = { old_mt.x, old_mt.y };

        // set characters on Tile Objects correctly
        oldTile.character = null;
        newTile.character = info.name;

        // move character go to tile that is clicked on
        this.transform.position = destination.transform.position;

        Debug.Log("Moved from" + oldPosition[0] + "-" + oldPosition[1]);
        Debug.Log("Moved to" + newPos[0] + "-" + newPos[1]);

    }

    // check if lamp or other character is close
    public bool isVisible()
    {
        bool visibile = false;
        MapTile mt = gameManager.getCharacterPosition(info.name);

        HashSet<GameObject> neighbors = mt.getNeighbors();

        foreach (GameObject neighbor in neighbors)
        {
            Tile info = neighbor.GetComponent<MapTile>().info;

            if(info.type == Tile.Types.Lamp && info.active || info.character != null)
            {
                visibile = true;
                break;
            }
        }

        return visibile;
    }

}
