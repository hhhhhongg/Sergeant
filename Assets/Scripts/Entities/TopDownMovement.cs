using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharactreController _controller;
    private CharacterStatsHandler _stats;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private Vector2 _knockback = Vector2.zero;
    private float knockBackDuration = 0f;

    private void Awake() 
    {
        _controller = GetComponent<TopDownCharactreController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _stats = GetComponent<CharacterStatsHandler>();
    }

    private void Start() 
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate() 
    {
        ApplyMovment(_movementDirection);
        if(knockBackDuration > 0f)
        {
            knockBackDuration -= Time.fixedDeltaTime;
        }
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

    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * _stats.CurrentStats.speed;
        if(knockBackDuration > 0f)
        {
            direction += _knockback;
        }
        _rigidbody.velocity = direction;
    }
}
