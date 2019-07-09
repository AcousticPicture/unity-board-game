// A class for describing a map tile. 
// An Object will keep track of every attribute

using UnityEngine;

public class Tile
{

    public Tile(Types type, bool active, GameObject gameObject, string character)
    {
        this.type = type;
        this.active = active;
        this.go = gameObject;
        this.character = character;
    } 

    public enum Types
    {
        Lamp, Sewer, Obstacle, Exit, Free
    }

    // a lamp is lightened, a sewer is open, an exit doesn't have a barrier
    public bool active;

    // Place for the actual gameobject inside the game
    public GameObject go;

    // Place for a character that could be standing on this tile
    public string character;

    public Types type;

    public bool isAccessible()
    {
        // lamps and obstacles (houses) can not be entered --- DEPRECATED
        // bool noObstacle = this.type != Types.Obstacle && this.type != Types.Lamp;

        // you can not stand on a tile that is occupied by another character
        bool free = this.character == null;

        // you can stay on an open exit
        bool openExit = this.type == Types.Exit && active;

        // you can stand on a sewer
        bool sewer = this.type == Types.Sewer;

        // you can stand on the street
        bool street = this.type == Types.Free;
        

        return (street || sewer || openExit) & free;
    }


}
