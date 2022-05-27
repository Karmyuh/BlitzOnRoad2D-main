using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _ship;
    [SerializeField] Transform _PlayerTransform;
    [SerializeField] float _playerSpeed;
    bool _isVerticalActive = true;
    MoverController _moverController;
    private void Awake()
    {
        _moverController = new MoverController();
    }
    
    void Update()
    {
        BulletSpawnStart();
    }

    private void FixedUpdate()
    {
        Walk();
    }
    void Walk()
    {
        _moverController.Vertical(_PlayerTransform, _playerSpeed, _isVerticalActive);
    }

    void BulletSpawnStart()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_bullet, _ship.transform.position, _ship.transform.rotation, transform);
        }
    }

}
