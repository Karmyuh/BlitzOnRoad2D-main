using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject _pinPrefab;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnPin();
        }
    }

    void SpawnPin()
    {
        Instantiate(_pinPrefab, transform.position, transform.rotation);
    }
}
