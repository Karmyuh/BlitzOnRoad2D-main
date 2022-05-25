using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    MoverController _moverController;
    [SerializeField] Transform _PlayerTransform;
    [SerializeField] float _playerSpeed, _jumpForce;
    [SerializeField] bool _isHorizontalActive, _isJumpActive, _isFlipActive;
    [SerializeField] Rigidbody2D _playerRigidbody2D;
    [SerializeField] SpriteRenderer _spriteRenderer;
    /*  [SerializeField]*/
    bool _isSpaceControl;
    [SerializeField] Animator _animator;
    private void Awake()
    {
        _moverController = new MoverController();

    }
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _isSpaceControl = true;
        }
    }
    private void FixedUpdate()
    {
        Walk();
        Jump();
        Flip();

    }
    void Walk()
    {
        _moverController.Horizontal(_PlayerTransform, _playerSpeed, _isHorizontalActive);
        _animator.SetFloat("__Run", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
    void Jump()
    {
        if (_isSpaceControl)
        {
            _moverController.Jump(_playerRigidbody2D, _jumpForce, _isJumpActive);
            _animator.SetBool("__Jump", _isSpaceControl);
        }
        _isSpaceControl = false;

    }
    void Flip()
    {
        _moverController.Flip(_spriteRenderer, _isFlipActive);
    }
    void Climb()
    {

    }
}
