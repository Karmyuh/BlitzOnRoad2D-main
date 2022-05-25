using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    [SerializeField] float _speed = 20f;
    [SerializeField] Rigidbody2D _rb;
    bool isPinned = false;

    private void Update()
    {
        if (!isPinned)
        {
            _rb.MovePosition(_rb.position + Vector2.up * _speed * Time.deltaTime);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rotater")
        {
            transform.SetParent(collision.transform);
            ScoreScript.PinCount++;
            //collision.GetComponent<RotaterScript>()._speed *= -1;
            isPinned = true;
        }
        else if (collision.tag == "Pin")
        {
            FindObjectOfType<GameManScript>().EndGame();
        }
    }


}
