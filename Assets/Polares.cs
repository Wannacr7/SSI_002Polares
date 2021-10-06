using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polares : MonoBehaviour
{
    [Header("Coordenadas polares")]
    [SerializeField] public float angle;
    [SerializeField] public float radius;

    [Header("Coordenadas cartesianas")]
    [SerializeField] private float x;
    [SerializeField] private float y;

    [Header("VElocidad y acelareción")]
    [SerializeField] private float radialVelocity;
    [SerializeField] private float angularVelocity;
    [SerializeField] private float radialAceleration;
    [SerializeField] private float angularAceleration;



    private Vector2 origin;
    private Vector2 cartesianPoint;
    [Header("")]
    [SerializeField] public GameObject sphere;
    [SerializeField] public bool activateSpiral;
    

    private void Start()
    {
        origin = new Vector2(0,0);
        sphere.transform.position = origin;
        angle = 0;
        radius = 0;
    }
    private void Update()
    {
        
        cartesianPoint = TransformToCartesian(angle, radius);
        sphere.transform.position = cartesianPoint;
        if (activateSpiral)
        {
            //angle += Time.deltaTime * factor;
            //radius += Time.deltaTime * factor;
            Spiral();
        }

        Debug.DrawLine(origin,cartesianPoint);
    }

    private Vector2 TransformToCartesian(float _angle, float _radius)
    {
        x = _radius * Mathf.Cos(_angle);
        y = _radius * Mathf.Sin(_angle);
        return new Vector2(x, y);
    }
    private void Spiral()
    {
        angle += angularVelocity * Time.deltaTime;
        radius += radialVelocity * Time.deltaTime;
        angularVelocity += angularAceleration * Time.deltaTime;
        radialVelocity += radialAceleration * Time.deltaTime;

        if (radius >= 9.5 || radius <= -9.5)
        {
            radialVelocity = radialVelocity * -1;
            radialAceleration = radialAceleration * -1;
        }
        if (radius <= 0)
        {
            radialVelocity = radialVelocity * -1;
            radialAceleration = radialAceleration * -1;
        }
    }

}
