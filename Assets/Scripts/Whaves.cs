using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whaves : MonoBehaviour
{
    [SerializeField] int circlesCount;
    [SerializeField] GameObject circlePrefab;
    [SerializeField] float amplitude;

    List<GameObject> circles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < circlesCount; i++)
        {
            var circle = Instantiate(circlePrefab, transform);
            circles.Add(circle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < circlesCount; i++)
        {
            var circle = circles[i];
            float x = 0.6f * i;
            float y = amplitude * Mathf.Sin(i + Time.time);
            circle.transform.localPosition = new Vector3(x, y);
        }
    }
}
