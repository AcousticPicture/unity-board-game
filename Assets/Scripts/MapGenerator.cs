using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject hexPrefab;
    public GameObject sewerPrefab;
    public GameObject streetPrefab;
    public GameObject lampPrefab;
    public GameObject obstaclePrefab;
    public GameObject exitPrefab;
    public GameObject characterPrefab;

    // x and y in 2d orientation, Offset for positioning in real Unity Units
    private static float xOffset = 0.760f; 
    private static float yOffset = 0.900f;
    private static float oddYoffset = yOffset / 2;

    
    public void createMap(GameConfig gameconfig)
    {
        
        for (int x = 0; x < gameconfig.witdh; x++){
            float collOffset = 0f;
                if ( x % 2 == 0 ) { // odd rows need to start a little higher to fit the tile map
                collOffset = oddYoffset;
                }
            for (int y = 0; y < gameconfig.height; y++) {

                Tile tile = gameconfig.map[x,y];
                GameObject prfab = null;
                if (tile.type == Tile.Types.Free) {
                    prfab = streetPrefab;
                } else if (tile.type == Tile.Types.Obstacle) {
                    prfab = obstaclePrefab;
                } else if (tile.type == Tile.Types.Sewer) {
                    prfab = sewerPrefab;
                } else if (tile.type == Tile.Types.Lamp) {
                    prfab = lampPrefab;
                } else if (tile.type == Tile.Types.Exit){
                    prfab = exitPrefab;
                } else {
                    prfab = hexPrefab;
                }
               

                GameObject go_tile = (GameObject) Instantiate(prfab, new Vector3(x * xOffset, 0, (y * yOffset) + collOffset), Quaternion.identity);
                tile.go = go_tile;

                go_tile.name = "Tile_" + x + "_" + y;
                if (go_tile.GetComponent<MapTile>())
                {
                    go_tile.GetComponent<MapTile>().x = x;
                    go_tile.GetComponent<MapTile>().y = y;
                    go_tile.GetComponent<MapTile>().info = tile;
                }
                                    
                go_tile.transform.SetParent(this.transform);

                if(tile.character != null)
                {
                    // set the character on the current tile
                    GameObject go_char = (GameObject)Instantiate(characterPrefab, go_tile.transform.position, Quaternion.identity);
                    go_char.name = "Character_" + tile.character;
                    go_char.transform.SetParent(this.transform);
                    // set character information on gameobject
                    Character c = gameconfig.getCharacter(tile.character);
                    c.characterGO =  go_char;
                    go_char.GetComponent<CharacterToken>().info = c;

                }
            }
        }
    }

   
}
