using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilations : MonoBehaviour
{
    [SerializeField] float periodX;
    [SerializeField] float periodY;
    [SerializeField] float amplitudeX;
    [SerializeField] float amplitudeY;
    [SerializeField] bool isVertical = false;


    // Update is called once per frame
    void Update()
    {
        float factorX = Time.time / periodX;
        float x = amplitudeX * Mathf.Sin(2 * Mathf.PI * factorX);
        float factorY = Time.time / periodY;
        float y = amplitudeY * Mathf.Sin(2 * Mathf.PI * factorY);

        if (!isVertical) transform.position = new Vector3(x, transform.position.y, transform.position.z);
        if(isVertical)transform.position = new Vector3(x, y, transform.position.z);

    }
}
