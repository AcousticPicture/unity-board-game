using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    public GameObject characterGO {
        get { return go; }
        set {  if ( this.go == null ) this.go = value; } // set only once!
    }

    public string name { get; }
    public int maxDistance { get; }
    private GameObject go;

    public Character (string name, GameObject go)
    {
        this.name = name;
        this.go = go;
        this.maxDistance = 3;
    }
    
}
