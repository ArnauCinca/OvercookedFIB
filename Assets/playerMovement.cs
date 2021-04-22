using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float speed = 100.0f;


    public float rotation_speed = 0.05f;

    public float collision_speed;

    public float actual_speed_x, actual_speed_y;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        collision_speed = speed / 10.0f;
        actual_speed_x = speed;
        actual_speed_y = speed;
        transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);


    }

    void OnCollisionEnter(Collision col)
    {
        bool h = false;
        bool v = false;
        Vector3 directionVector;
        foreach (ContactPoint cp in col.contacts)
        {

            directionVector = (cp.point - transform.position);
            float angle = Mathf.Atan2(directionVector.x, directionVector.z) / Mathf.PI * 180f;
            if (angle < 0) angle += 360f;
            if (angle >= 315 && angle < 45) //left
            {
                h = true;
            }
            else if (angle >= 45 && angle < 135) //top
            {
                v = true;
            }
            else if (angle >= 135 && angle < 225)//right
            {
                h = true;
            }
            else if (angle >= 225 && angle < 315)//bot
            {
                v = true;
            }
        }
        if (v) actual_speed_x = collision_speed;
        if (h) actual_speed_y = collision_speed;
    }

    void OnCollisionStay(Collision col)
    {
        bool h = false;
        bool v = false;
        Vector3 directionVector;
        foreach (ContactPoint cp in col.contacts)
        {

            directionVector = (cp.point - transform.position);
            float angle = Mathf.Atan2(directionVector.x, directionVector.z) / Mathf.PI * 180f;
            if (angle < 0) angle += 360f;
            if (angle >= 315 || angle < 45) //left
            {
                h = true;
            }
            else if (angle >= 45 && angle < 135) //top
            {
                v = true;
            }
            else if (angle >= 135 && angle < 225)//right
            {
                h = true;
            }
            else if (angle >= 225 && angle < 315)//bot
            {
                v = true;
            }
        }
        if (v) actual_speed_x = collision_speed;
        if (h) actual_speed_y = collision_speed;
    }


    void OnCollisionExit(Collision col)
    {
        bool h = false;
        bool v = false;
        Vector3 directionVector;
        foreach (ContactPoint cp in col.contacts)
        {

            directionVector = (cp.point - transform.position);
            float angle = Mathf.Atan2(directionVector.x, directionVector.z) / Mathf.PI * 180f;
            if (angle < 0) angle += 360f;
            if (angle >= 315 && angle < 45) //left
            {
                h = true;
            }
            else if (angle >= 45 && angle < 135) //top
            {
                v = true;
            }
            else if (angle >= 135 && angle < 225)//right
            {
                h = true;
            }
            else if (angle >= 225 && angle < 315)//bot
            {
                v = true;
            }
        }
        if (!v) actual_speed_x = speed;
        if (!h) actual_speed_y = speed;

    
}
    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
        bool move = false;
        if (Input.GetKey("w")) {
            movement.z += 1.0f;
            move = true;
        }
        if (Input.GetKey("s"))
        {
            movement.z -= 1.0f;
            move = true;

        }
        if (Input.GetKey("d"))
        {
            movement.x += 1.0f;
            move = true;

        }
        if (Input.GetKey("a"))
        {
            movement.x -= 1.0f;
            move = true;

        }
        if (move)
        {
            float angle = Mathf.Atan2(movement.x, movement.z) / Mathf.PI * 180f;
            if (angle < 0) angle += 360f;

            // 0 -> 0
            //180 -> +- 1

            //angle = angle / 180.0f;
            float actual_angle = transform.eulerAngles.y;


            float rotation = angle - actual_angle;
            if (rotation > 180) rotation = 180 - rotation;
            else if (rotation < -180) rotation = -180 - rotation;
            //if (actual_angle < 0) actual_angle += 360f;

            Debug.Log("A:");
            Debug.Log(angle);
            Debug.Log(actual_angle);
            Debug.Log("RES:");
            Debug.Log(rotation);
            transform.eulerAngles += (new Vector3(0.0f, rotation, 0.0f)*rotation_speed);

            transform.position += (new Vector3(movement.x * actual_speed_x, 0.0f, movement.z * actual_speed_y) * Time.deltaTime);

        }

    }
}
