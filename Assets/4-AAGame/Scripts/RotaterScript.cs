using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaterScript : MonoBehaviour
{
    [SerializeField] public float _speed = 100f;

    private void Update()
    {
        transform.Rotate(0f, 0f, _speed * Time.deltaTime);
    }



}
