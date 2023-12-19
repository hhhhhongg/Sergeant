using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharactreController _controller;
    private CharacterStatsHandler _stats;

    private Vector2 _movementDirection = Vector2.zero;
    private Vector2 _aimDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private Vector2 _knockback = Vector2.zero;
    private float knockBackDuration = 0f;

    bool _isDash = false;
    float Dashreload = 1f;
    float DashTime = 1f;


    private void Awake() 
    {
        _controller = GetComponent<TopDownCharactreController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _stats = GetComponent<CharacterStatsHandler>();

    }

    private void Start() 
    {
        _controller.OnMoveEvent += Move;
        _controller.OnDashEvent += Dash;
        _controller.OnLookEvent += OnAim;
    }

    private void FixedUpdate() 
    {
        ApplyMovment(_movementDirection);
        if(knockBackDuration > 0f)
        {
            knockBackDuration -= Time.fixedDeltaTime;
        }
        DashTime += Time.fixedDeltaTime;
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockBackDuration = duration;
        _knockback = -(other.position - transform.position).normalized*power;
    }

    private void Move(Vector2 direction) 
    {
        _movementDirection = direction;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }
    private void Dash()
    {
        if(DashTime >= Dashreload)
        {
            StartCoroutine(DashCoroutine());
            DashTime = 0f;
        }
        
    }
    private void ApplyMovment(Vector2 direction)
    {

        if (_isDash) return;
        direction = direction * _stats.CurrentStats.speed;
        if(knockBackDuration > 0f)
        {
            direction += _knockback;
        }
        _rigidbody.velocity = direction;
    }
    IEnumerator DashCoroutine()
    {
        _isDash = true;
        _rigidbody.AddForce(_aimDirection * _stats.CurrentStats.dashSpeed, ForceMode2D.Impulse);
        yield return new WaitUntil(() => _rigidbody.velocity.magnitude < 4f);
        _isDash = false;
    }

}
