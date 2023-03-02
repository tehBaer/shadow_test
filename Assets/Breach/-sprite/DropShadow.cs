using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShadow : MonoBehaviour
{
    public GameObject shadow;
    public float longestDistance = 0.25f;
    public bool variableSize = true;
    private Vector3 fullShadowScale;
    private RaycastHit hit;
    void Start(){
        fullShadowScale = shadow.transform.localScale;
    }
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit))
        {
            shadow.SetActive(true);
            
            // Set the position of the shadow on the ground below the character
            shadow.transform.position = new Vector3(transform.position.x, transform.position.y - hit.distance + 0.005f, transform.position.z);

            if (variableSize)
            {
                // Set the size of the shadow between 100% at ground level and 0% at longestDistance
                shadow.transform.localScale = fullShadowScale * Mathf.Clamp(1 - hit.distance / longestDistance, 0, 1);
            }
        }
        else
        {
            shadow.SetActive(false);
        }
    }
}
