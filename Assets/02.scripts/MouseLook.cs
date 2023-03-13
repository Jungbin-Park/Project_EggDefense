using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 500f;
    public float rotX = 0;
    public float rotY = -60;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (Input.GetButton("Fire1"))
        {
            rotX += mouseX * sensitivity * Time.deltaTime;
            rotY += mouseY * sensitivity * Time.deltaTime;

            // 고개 들어 45도 까지 
            if (rotY > 90f)
                rotY = 90f;
            // 고개 숙여 -20도 까지
            if (rotY < -90f)
                rotY = -90f;

            this.transform.eulerAngles = new Vector3(-rotY, rotX, 0f);
        }
    }

    
}
