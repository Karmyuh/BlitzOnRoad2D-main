using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    [SerializeField] float _LifeTime;
    float _currentTime;
    private void FixedUpdate()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _LifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
