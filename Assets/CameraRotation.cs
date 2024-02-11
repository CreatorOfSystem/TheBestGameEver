using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;
    // Start is called before the first frame update
    public float minAngel;
    public float maxAngel;
    public float RotationSpeed;
    // Update is called once per frame
    void Update()
    {
        var newAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
      if (newAngleX > 180)
        {
            newAngleX = newAngleX - 360;
        }
        newAngleX = Mathf.Clamp(newAngleX, minAngel, maxAngel);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X"), 0);
        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
