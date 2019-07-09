using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameConfig
{
    // Amout of tiles
    public int witdh = 13;
    public int height = 9;

    public Tile[,] map; 
    public Character[] characters;
    public Round[] rounds;

    // TODO: store the special lamp positions

    public GameConfig ()
    {
        map = new Tile[this.witdh, this.height];
        characters = new Character[8];
        createCharacters();
        fillMap();
        setRounds();
    }

    private void createCharacters ()
    {
        characters[0] = new Character( "Sherlock Holmes" , null);
        characters[1] = new Character( "John H. Watson" , null);
        characters[2] = new Character( "John Smith" , null);
        characters[3] = new Character( "Inspektor Lestrade" , null);
        characters[4] = new Character( "Miss Stealthy" , null);
        characters[5] = new Character( "Sergant Goodley" , null);
        characters[6] = new Character( "Sir William Gull" , null);
        characters[7] = new Character( "Jeremy Bert" , null);
    }

    private void fillMap()
    {
        // creating actual map
        // Type, active, game object, character
        map[0,0] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[0,1] = new Tile(Tile.Types.Free, false, null, null);
        map[0,2] = new Tile(Tile.Types.Free, false, null, null);
        map[0,3] = new Tile(Tile.Types.Free, false, null, characters[4].name);
        map[0,4] = new Tile(Tile.Types.Free, false, null, null);
        map[0,5] = new Tile(Tile.Types.Free, false, null, null);
        map[0,6] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[0,7] = new Tile(Tile.Types.Exit, true, null, null);
        map[0,8] = new Tile(Tile.Types.Obstacle, false, null, null);

        map[1,0] = new Tile(Tile.Types.Exit, false, null, null);
        map[1,1] = new Tile(Tile.Types.Sewer, false, null, null);
        map[1,2] = new Tile(Tile.Types.Lamp, true, null, null); // 1
        map[1,3] = new Tile(Tile.Types.Free, false, null, null);
        map[1,4] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[1,5] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[1,6] = new Tile(Tile.Types.Sewer, true, null, null);
        map[1,7] = new Tile(Tile.Types.Free, false, null, null);
        map[1,8] = new Tile(Tile.Types.Obstacle, false, null, null);

        map[2,0] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[2,1] = new Tile(Tile.Types.Free, false, null, null);
        map[2,2] = new Tile(Tile.Types.Free, false, null, null);
        map[2,3] = new Tile(Tile.Types.Sewer, true, null, null);
        map[2,4] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[2,5] = new Tile(Tile.Types.Free, false, null, null);
        map[2,6] = new Tile(Tile.Types.Lamp, true, null, null); // 3
        map[2,7] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[2,8] = new Tile(Tile.Types.Obstacle, false, null, null);

        map[3,0] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[3,1] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[3,2] = new Tile(Tile.Types.Free, false, null, null);
        map[3,3] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[3,4] = new Tile(Tile.Types.Free, false, null, null);
        map[3,5] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[3,6] = new Tile(Tile.Types.Free, false, null, null);
        map[3,7] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[3,8] = new Tile(Tile.Types.Obstacle, false, null, null);

        map[4,0] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[4,1] = new Tile(Tile.Types.Free, false, null, null);
        map[4,2] = new Tile(Tile.Types.Free, false, null, null);
        map[4,3] = new Tile(Tile.Types.Free, false, null, characters[3].name);
        map[4,4] = new Tile(Tile.Types.Free, false, null, null);
        map[4,5] = new Tile(Tile.Types.Free, false, null, null);
        map[4,6] = new Tile(Tile.Types.Free, false, null, null);
        map[4,7] = new Tile(Tile.Types.Free, false, null, characters[6].name);
        map[4,8] = new Tile(Tile.Types.Obstacle, false, null, null);

        map[5,0] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[5,1] = new Tile(Tile.Types.Free, false, null, null);
        map[5,2] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[5,3] = new Tile(Tile.Types.Lamp, true, null, null);
        map[5,4] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[5,5] = new Tile(Tile.Types.Free, false, null, null);
        map[5,6] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[5,7] = new Tile(Tile.Types.Lamp, false, null, null);
        map[5,8] = new Tile(Tile.Types.Sewer, true, null, null);

        map[6,0] = new Tile(Tile.Types.Free, false, null, null);
        map[6,1] = new Tile(Tile.Types.Free, false, null, null);
        map[6,2] = new Tile(Tile.Types.Free, false, null, characters[0].name);
        map[6,3] = new Tile(Tile.Types.Sewer, true, null, null);
        map[6,4] = new Tile(Tile.Types.Free, false, null, null);
        map[6,5] = new Tile(Tile.Types.Free, false, null, characters[2].name);
        map[6,6] = new Tile(Tile.Types.Free, false, null, null);
        map[6,7] = new Tile(Tile.Types.Free, false, null, null);
        map[6,8] = new Tile(Tile.Types.Obstacle, false, null, null);

        map[7,0] = new Tile(Tile.Types.Sewer, true, null, null);
        map[7,1] = new Tile(Tile.Types.Lamp, true, null, null);
        map[7,2] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[7,3] = new Tile(Tile.Types.Free, false, null, null);
        map[7,4] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[7,5] = new Tile(Tile.Types.Lamp, false, null, null);
        map[7,6] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[7,7] = new Tile(Tile.Types.Free, false, null, null);
        map[7,8] = new Tile(Tile.Types.Obstacle, false, null, null);

        map[8,0] = new Tile(Tile.Types.Free, false, null, characters[1].name);
        map[8,1] = new Tile(Tile.Types.Free, false, null, null);
        map[8,2] = new Tile(Tile.Types.Free, false, null, null);
        map[8,3] = new Tile(Tile.Types.Free, false, null, null);
        map[8,4] = new Tile(Tile.Types.Free, false, null, characters[7].name);
        map[8,5] = new Tile(Tile.Types.Free, false, null, null);
        map[8,6] = new Tile(Tile.Types.Free, false, null, null);
        map[8,7] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[8,8] = new Tile(Tile.Types.Obstacle, false, null, null);

        map[9,0] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[9,1] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[9,2] = new Tile(Tile.Types.Free, false, null, null);
        map[9,3] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[9,4] = new Tile(Tile.Types.Free, false, null, null);
        map[9,5] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[9,6] = new Tile(Tile.Types.Free, false, null, null);
        map[9,7] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[9,8] = new Tile(Tile.Types.Obstacle, false, null, null);

        map[10,0] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[10,1] = new Tile(Tile.Types.Lamp, true, null, null); //4
        map[10,2] = new Tile(Tile.Types.Free, false, null, null);
        map[10,3] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[10,4] = new Tile(Tile.Types.Sewer, true, null, null);
        map[10,5] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[10,6] = new Tile(Tile.Types.Free, false, null, null);
        map[10,7] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[10,8] = new Tile(Tile.Types.Obstacle, false, null, null);

        map[11,0] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[11,1] = new Tile(Tile.Types.Free, false, null, null);
        map[11,2] = new Tile(Tile.Types.Sewer, true, null, null);
        map[11,3] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[11,4] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[11,5] = new Tile(Tile.Types.Free, false, null, null);
        map[11,6] = new Tile(Tile.Types.Lamp, true, null, null); //2
        map[11,7] = new Tile(Tile.Types.Sewer, false, null, null);
        map[11,8] = new Tile(Tile.Types.Exit, false, null, null);

        map[12,0] = new Tile(Tile.Types.Exit, true, null, null);
        map[12,1] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[12,2] = new Tile(Tile.Types.Free, false, null, null);
        map[12,3] = new Tile(Tile.Types.Free, false, null, null);
        map[12,4] = new Tile(Tile.Types.Free, false, null, characters[5].name);
        map[12,5] = new Tile(Tile.Types.Free, false, null, null);
        map[12,6] = new Tile(Tile.Types.Free, false, null, null);
        map[12,7] = new Tile(Tile.Types.Obstacle, false, null, null);
        map[12,8] = new Tile(Tile.Types.Obstacle, false, null, null);

    }

    private void setRounds()
    {
        rounds = new Round[8];
        bool[] x = { false, true, true, false };
        rounds[0] = new Round(x, true, 1);
    }

    public Character getCharacter(string name)
    {
        for(int i = 0; i < characters.Length; i ++)
        {
            if(characters[i].name == name)
            {
                return characters[i];
            }
        }

        return null;
    }

    public int[] findCharacterPosition(string name)
    {
        for (int x = 0; x < this.witdh; x++)
        {   
            for (int y = 0; y < this.height; y++)
            {
                if (map[x,y].character == name)
                {
                    int[] pos = new int[2];
                    pos[0] = x;
                    pos[1] = y;
                    return pos;
                }
            }
        }

        return null;
    }
}
