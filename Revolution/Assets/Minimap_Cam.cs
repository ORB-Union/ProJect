using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap_Cam : MonoBehaviour {

    public Transform Player_Cam;

    void LateUpdate()
    {
        Vector3 newPosition = Player_Cam.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, Player_Cam.eulerAngles.y, 0f);
    }
}
