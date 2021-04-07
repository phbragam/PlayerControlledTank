using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    Vector3 forwardVector;

    void Update()
    {
        forwardVector = transform.up;
        
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        //transform.Translate(0, translation, 0);

        transform.position += forwardVector * translation;

        //transform.Rotate(0, 0, -rotation);

        bool clockwise = false;

        if (rotation > 0)
        {
            clockwise = true;
        }

        // Always try to be sure if you are working with degrees or radians.
        // Dont just divide the rotationSpeed by something.
        // In this case, Rotate recieves angle in radians, so the conversion is necessary.
        transform.up = HolisticMath.Rotate(new Coords(forwardVector), Mathf.Abs(rotation) * Mathf.Deg2Rad, clockwise).ToVector();
    }
}
