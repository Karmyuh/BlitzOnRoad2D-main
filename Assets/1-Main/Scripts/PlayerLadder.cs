using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadder : MonoBehaviour
{
    MoverController _moverController;
    [SerializeField] Transform _PlayerTransform;
    [SerializeField] float _vPlayerSpeed;
    [SerializeField] Rigidbody2D _playerRigidbody2D;
    [SerializeField] bool _isVerticalActive;
    [SerializeField] Animator _animator;
    private void Awake()
    {
        _moverController = new MoverController();

    }
    private void FixedUpdate()
    {
        Climb();
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ladder"))
        {
            _isVerticalActive = true;
            _animator.SetBool("__Climb", true);
            _playerRigidbody2D.gravityScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ladder"))
        {
            _isVerticalActive = false;
            _animator.SetBool("__Climb", false);
            _playerRigidbody2D.gravityScale = 1;
        }
    }
    void Climb()
    {
        _moverController.Vertical(_PlayerTransform, _vPlayerSpeed, _isVerticalActive);
    }
}
