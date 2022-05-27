using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    MoverController _moverController;

    [SerializeField] Transform _PlayerTransform;

    [SerializeField] float _playerSpeed,_vPlayerSpeed ,_jumpForce;
    [SerializeField] bool _isHorizontalActive,_isVerticalActive, _isJumpActive, _isFlipActive;

    [SerializeField] Rigidbody2D _playerRigidbody2D;
    [SerializeField] SpriteRenderer _spriteRenderer;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumpActive = PlayerRaycast.IsOnGroud;
            Jump();
        }
        if (PlayerRaycast.IsOnGroud)
            _animator.SetBool("__Jump", false);
        else
            _animator.SetBool("__Jump", true);


    }
    private void FixedUpdate()
    {
        Walk();
        Flip();
        

    }
    void Walk()
    {
        _moverController.Horizontal(_PlayerTransform, _playerSpeed, _isHorizontalActive);
        
        _animator.SetFloat("__Run", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
    void Jump()
    {
            _moverController.Jump(_playerRigidbody2D, _jumpForce, _isJumpActive);
    }
    void Flip()
    {
        _moverController.Flip(_spriteRenderer, _isFlipActive);
    }
   
    

}
