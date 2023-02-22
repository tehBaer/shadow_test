using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShadow : MonoBehaviour
{

    public float maxDistance;
    public GameObject shadow;
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit))
        {
            shadow.SetActive(true);
            if (hit.distance < 1)
            {
                shadow.transform.position = new Vector3(transform.position.x, transform.position.y - hit.distance + 0.005f, transform.position.z);
            }
        }
        else
        {
            shadow.SetActive(false);
        }

    }
}
