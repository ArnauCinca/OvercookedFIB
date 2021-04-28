using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    private enum TileSpace {Empty, Path, Table, FakeTable, Deliver, Oven_Stove };
    private TileSpace[][] map;
    public GameObject Table;
    public GameObject Deliver;
    public GameObject Oven_Stove;
    public GameObject Player;

    public int trys = 1;

    public int n_oven_stove = 5;

    public int x_size = 10;
    public int y_size = 5;

    public int min_path = 20;
    private int n_path = 0;

    private int pos_player_x, pos_player_y;

    // Start is called before the first frame update
    void Start()
    {
        //Generate basic map with borders
        bool nice_map = false;
        min_path = Mathf.Min(min_path, x_size * y_size / 3);
        while (!nice_map)
        {
            n_path = 0;
            trys = 1;
            initEmptyMap();

            generateBorders();

            //Generate random structures
            while (Random.Range(0, trys) <= 2)
                if (tryAdd(Random.Range(0, 3)))
                    trys++;

            //Generate Delivers
            generateDeliversAndPath();
            nice_map = n_path >= min_path;
        }


        //fill table holes(?)
        for (int i = 0; i < x_size; ++i)
        {
            for (int j = 0; j < y_size; ++j)
            {
                if (!surroundedBy(i, j, TileSpace.Path)) setMap(i, j, TileSpace.FakeTable);
            }
        }
        fillEmpty(0, 0);

        for (int i = 0; i < x_size; ++i)
        {
            for (int j = 0; j < y_size; ++j)
            {
                if (getMap(i,j) == TileSpace.Empty && near(i, j, TileSpace.Path)) setMap(i, j, TileSpace.FakeTable);
            }
        }


        for (int i = 0; i < x_size; ++i)
        {
            for (int j = 0; j < y_size; ++j)
            {
                if (!border(i, j))
                {
                    if (getMap(i, j) == TileSpace.Table && !surroundedBy(i, j, TileSpace.Table) && !surroundedBy(i, j, TileSpace.Empty))
                    {
                        setMap(i, j, TileSpace.Empty);
                        if (getMap(i + 1, j) == TileSpace.FakeTable) setMap(i + 1, j, TileSpace.Table);
                        if (getMap(i - 1, j) == TileSpace.FakeTable) setMap(i - 1, j, TileSpace.Table);
                        if (getMap(i, j + 1) == TileSpace.FakeTable) setMap(i, j + 1, TileSpace.Table);
                        if (getMap(i, j - 1) == TileSpace.FakeTable) setMap(i, j - 1, TileSpace.Table);

                    }
                }
            }
        }




        //Generate Ovens
        generateOvens();

        
 

        //Spawn & rotations
        for (int i = 0; i<x_size; ++i)
        {
            for(int j = 0; j < y_size; ++j)
            {
                switch (getMap(i, j)){
                    case TileSpace.Empty:
                        break;
                    case TileSpace.Path:
                        break;
                    case TileSpace.Table:
                        Instantiate(Table, new Vector3(i * 2.0f - x_size, 1.0f, j * 2.0f - y_size), Quaternion.identity);
                        break;
                    case TileSpace.FakeTable:
                        Instantiate(Table, new Vector3(i * 2.0f - x_size, 1.0f, j * 2.0f - y_size), Quaternion.identity);
                        break;
                    case TileSpace.Deliver:
                        Instantiate(Deliver, new Vector3(i * 2.0f - x_size, 1.0f, j * 2.0f - y_size), Quaternion.identity);
                        break;
                    case TileSpace.Oven_Stove:
                        Instantiate(Oven_Stove, new Vector3(i * 2.0f - x_size, 1.0f, j * 2.0f - y_size), Quaternion.identity);
                        break;
                }
            }
        }
        Instantiate(Player, new Vector3(pos_player_x * 2.0f - x_size, 1.5f, pos_player_y * 2.0f - y_size), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initEmptyMap()
    {
        map = new TileSpace[x_size + 2][];
        for (int i = 0; i < x_size + 2; i++)
        {
            map[i] = new TileSpace[y_size + 2];
            for (int j = 0; j < y_size + 2; j++)
            {
                map[i][j] = TileSpace.Empty;

                if (i == 0 || i == x_size + 1 || j == 0 || j == y_size + 1)
                    map[i][j] = TileSpace.FakeTable;
            }
        }
    }
    void generateBorders()
    {
        for (int i = 0; i < x_size; i++)
            for (int j = 0; j < y_size; j++)
                if (border(i, j))
                    setMap(i, j, TileSpace.Table);
    }
    void generateDeliversAndPath()
    {
        int tblr = Random.Range(0, 4);
        int path_x, path_y;

        if (tblr == 0) //top
        {
            int x = Random.Range(1, x_size - 2);
            setMap(x, y_size - 1, TileSpace.Deliver);
            setMap(x + 1, y_size - 1, TileSpace.Deliver);
            path_x = x;
            path_y = y_size - 2;
            if (getMap(x, y_size - 2) != TileSpace.Empty) setMap(x, y_size - 2, TileSpace.Empty);
            if (getMap(x + 1, y_size - 2) != TileSpace.Empty) setMap(x + 1, y_size - 2, TileSpace.Empty);

        }
        else if (tblr == 1) //bottom
        {
            int x = Random.Range(1, x_size - 2);
            setMap(x, 0, TileSpace.Deliver);
            setMap(x + 1, 0, TileSpace.Deliver);
            path_x = x;
            path_y = 1;
            if (getMap(x, 1) != TileSpace.Empty) setMap(x, 1, TileSpace.Empty);
            if (getMap(x + 1, 1) != TileSpace.Empty) setMap(x + 1, 1, TileSpace.Empty);
        }
        else if (tblr == 2) //left
        {
            int y = Random.Range(1, y_size - 2);
            setMap(x_size - 1, y, TileSpace.Deliver);
            setMap(x_size - 1, y + 1, TileSpace.Deliver);
            path_x = x_size - 2;
            path_y = y;
            if (getMap(x_size - 2, y) != TileSpace.Empty) setMap(x_size - 2, y, TileSpace.Empty);
            if (getMap(x_size - 2, y + 1) != TileSpace.Empty) setMap(x_size - 2, y + 1, TileSpace.Empty);
        }
        else //right
        {
            int y = Random.Range(1, y_size - 2);
            setMap(0, y, TileSpace.Deliver);
            setMap(0, y + 1, TileSpace.Deliver);
            path_x = 1;
            path_y = y;
            if (getMap(1, y) != TileSpace.Empty) setMap(1, y, TileSpace.Empty);
            if (getMap(1, y + 1) != TileSpace.Empty) setMap(1, y + 1, TileSpace.Empty);
        }

        pos_player_x = path_x;
        pos_player_y = path_y;
        //Generate path
        fillPath(path_x, path_y);
    }

    void generateOvens()
    {
        int max_oven_stove = n_oven_stove;


        while (n_oven_stove > max_oven_stove/3)
        {
            int first_oven = Random.Range(0, x_size * y_size);
            int x = 1;
            int y = 1;
            while (first_oven > 0)
            {

                x = (x + 1) % x_size;
                if (x == 1) y = (y + 1) % y_size;
                if (getMap(x, y) == TileSpace.Table)
                {
                    --first_oven;
                }
            }
            setMap(x, y, TileSpace.Oven_Stove);
            --n_oven_stove;
            if (n_oven_stove > 0)
                addOven(x + 1, y);
            if (n_oven_stove > 0)
                addOven(x - 1, y);
            if (n_oven_stove > 0)
                addOven(x, y + 1);
            if (n_oven_stove > 0)
                addOven(x, y - 1);
        }
    }


    bool near(int x, int y, TileSpace type)
    {
        return surroundedBy(x, y, type) || getMap(x + 1, y + 1) == type || getMap(x - 1, y + 1) == type || getMap(x + 1, y - 1) == type || getMap(x - 1, y - 1) == type;
    }
    bool surroundedBy(int x, int y, TileSpace type)
    {
        return getMap(x, y - 1) == type || getMap(x, y + 1) == type || getMap(x + 1, y) == type || getMap(x - 1, y) == type;
    }

    void setMap(int x, int y, TileSpace type)
    {
        map[x + 1][y + 1] = type;
    }

    TileSpace getMap(int x, int y)
    {
        return map[x + 1][y + 1];
    }

    bool border_top(int x)
    {
        return x == 0;
    }
    bool border_bot(int x)
    {
        return x == x_size - 1;
    }
    bool border_left(int y)
    {
        return y == 0;
    }
    bool border_right(int y)
    {
        return y == y_size - 1;
    }


    bool border(int x, int y)
    {
        return border_top(x) || border_bot(x) || border_left(y) || border_right(y);
    }

    bool corner(int x, int y) {
        return (x == 0 && y == 0) || (x == 0 && y == y_size - 1) || (x == x_size - 1 && y == 0) || (x == x_size - 1 && y == y_size - 1);
    }

    bool borderAndNotCorner(int x, int y) {
        return border(x, y) && !corner(x,y);
    }


    bool tryAdd(int form)
    {
        int length_x, length_y, x, y;
        switch (form)
        {
            case 0:
                length_x = Random.Range(4, x_size - 4);
                length_y = 1;
                x = Random.Range(1, x_size - length_x - 1);
                y = Random.Range(3, y_size - 3);

                break;
            case 1:
                length_x = 1;
                length_y = Random.Range(3, y_size - 4);
                x = Random.Range(3, x_size - 3);
                y = Random.Range(1, y_size - length_y - 1);

                break;
            default:
                return false;
        }

        for (int i = 0; i < length_x; i++)
            for (int j = 0; j < length_y; j++)
                setMap(x + i,y + j, TileSpace.Table);

        return true;
    }

    void fillPath(int x, int y)
    {
        if (getMap(x,y) != TileSpace.Empty) return;
        
        setMap(x, y, TileSpace.Path);
        ++n_path;
        fillPath(x, y + 1);
        fillPath(x, y - 1);
        fillPath(x + 1, y);
        fillPath(x - 1, y);

    }

    void fillEmpty(int x, int y)
    {
        if (map[x][y] != TileSpace.FakeTable) return;

        map[x][y] = TileSpace.Empty;
        if(y < y_size+1)
            fillEmpty(x, y + 1);
        if(y > 0)
            fillEmpty(x, y - 1);
        if(x < x_size+1)
            fillEmpty(x + 1, y);
        if(x >0)
            fillEmpty(x - 1, y);
    }

    void addOven(int x, int y)
    {
        if (n_oven_stove <= 0 || getMap(x, y) != TileSpace.Table ) return;

        setMap(x, y, TileSpace.Oven_Stove);
        --n_oven_stove;
        addOven(x, y + 1);
        addOven(x, y - 1);
        addOven(x + 1, y);
        addOven(x - 1, y);

    }
}
