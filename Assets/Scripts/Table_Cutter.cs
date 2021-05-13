using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table_Cutter : Table
{
    public GameObject Cutter;

    // Start is called before the first frame update
    void Start()
    {
        o = Instantiate(Cutter, new Vector3(transform.position.x, transform.position.y + 1.05f, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
