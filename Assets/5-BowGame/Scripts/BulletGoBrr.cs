using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGoBrr : MonoBehaviour
{
    [SerializeField] Rigidbody2D _bullet;
    [SerializeField] float _bulletspeed;
    private void FixedUpdate()
    {
        BulletGoes();
    }

    void BulletGoes()   
    {
        _bullet.AddForce(Vector2.right * _bulletspeed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

}
