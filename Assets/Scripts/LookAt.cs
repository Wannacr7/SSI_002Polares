using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    Vector2 velocity;
    Vector2 aceleration;
    
    [Header("Activa o desactiva el movimiento")][SerializeField]private bool isMoving = false;

    // Update is called once per frame
    void Update()
    {
        
        Vector2 mousePosition = GetWorldMousePosition();
        Vector2 thisPosition = this.transform.position;

        Debug.DrawLine(Vector3.zero, mousePosition, Color.white);

        if(!isMoving)Look(mousePosition);
        if (isMoving) Move(mousePosition, thisPosition);
       

        
        
    }

    private void Look(Vector2 targetPosition)
    {
        Vector2 thisPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 forward = targetPosition - thisPosition;
        float radians = Mathf.Atan2(forward.y, forward.x);
        RotateZ(radians);
    }

    private void Move(Vector2 _mousePosition, Vector2 _thisPosition)
    {
        aceleration = _mousePosition - _thisPosition;
        velocity = velocity + aceleration * Time.deltaTime;

        Look(_mousePosition + velocity);

        Vector3 finalPosition = new Vector3(velocity.x, velocity.y, 0);
        this.transform.position += finalPosition * Time.deltaTime;

    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        return worldPos;
    }

    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
