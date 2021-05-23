using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 100.0f;
    public  GameObject pm;
    bool pause = false;
    private GameObject carryingObject = null;
    private bool delayInteraction = false;
    public float delay = 0.2f;
    public float rotation_speed = 5.0f;


    public float collision_speed;

    public float actual_speed_x, actual_speed_y;
    // Start is called before the first frame update
    void Start()
    {
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

    void interaction(GameObject go)
    {
        if (!delayInteraction && !pause) {
            if (go.CompareTag("Furniture"))
            {
                if (Input.GetKey("p"))
                {
                    delayInteraction = true;
                    StartCoroutine(Delay(delay));
                    if (carryingObject == null) //pick
                    {
                        carryingObject = ((Furniture)go.GetComponent(typeof(Furniture))).pick();
                    }

                    else //leave
                    {
                        bool l = ((Furniture)go.GetComponent(typeof(Furniture))).leave(carryingObject);
                        if (l) carryingObject = null;

                    }
                }
                else if (Input.GetKey("o"))
                {
                    delayInteraction = true;
                    StartCoroutine(Delay(delay));
                    ((Furniture)go.GetComponent(typeof(Furniture))).action();
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        interaction(other.gameObject);
    }
    void OnTriggerStay(Collider other)
    {
        interaction(other.gameObject);
    }
    void OnTriggerExit(Collider other)
    {

    }

    public void Pause() {
        pause = true;
        Time.timeScale = 0.0f;
        pm.gameObject.SetActive(pause);
    }

    public void Unpause()
    {
        pause = false;
        Time.timeScale = 1.0f;
        pm.gameObject.SetActive(pause);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (pause)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
        
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
            float actual_angle = transform.eulerAngles.y;

            float rotation = angle - actual_angle;
            if (rotation > 180) rotation = 180 - rotation;
            else if (rotation < -180) rotation = -180 - rotation;

            transform.eulerAngles += (new Vector3(0.0f, rotation, 0.0f) * rotation_speed * Time.deltaTime);
            transform.position += (new Vector3(movement.x * actual_speed_x, 0.0f, movement.z * actual_speed_y) * Time.deltaTime);

        }
        if (carryingObject != null) carryingObject.transform.position = new Vector3(transform.position.x, transform.position.y + 5.0f, transform.position.z);


    }

    protected IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        delayInteraction = false;
    }


}
