using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Extinguisher : Object
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public override GameObject pick()
    {
        //StopCooking
        return gameObject;
    }

    
    public override void move(Vector3 pos) {
        transform.position = pos;
    }

    public override void leave(Vector3 pos)
    {
        transform.position = pos;
    }
}
