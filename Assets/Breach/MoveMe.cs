using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMe : MonoBehaviour
{

    [SerializeField] Transform destination; 
    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, destination.position)) < 0.001f) {
            this.transform.position = initialPosition;
        }

        else {
            this.transform.position = Vector3.MoveTowards(transform.position, destination.position, 0.1f * Time.deltaTime);
        }


    }
}
