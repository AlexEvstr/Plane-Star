using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _speed);
        if (transform.position.x < -4)
        {
            Destroy(gameObject);
        }
    }
}