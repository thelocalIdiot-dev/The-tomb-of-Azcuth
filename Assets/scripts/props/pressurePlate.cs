using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pressurePlate : MonoBehaviour
{
    private Vector3 _originalPos;
    public bool _isPressed;
    [SerializeField] private float _maxDownDistance = 0.3f;

    public UnityEvent OnPress;
    public UnityEvent OnRelease;
    public UnityEvent OnHeldDown;
    GameObject player;

    void Start()
    {
        _originalPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }



    void FixedUpdate()
    {
        if (_isPressed && transform.position.y > _originalPos.y - _maxDownDistance)
        {
            transform.Translate(0f, -0.03f, 0f);
        }
        else if (!_isPressed && transform.position.y < _originalPos.y)
        {
            transform.Translate(0f, 0.03f, 0f);
        }

        if (_isPressed)
        {
            OnHeldDown.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isPressed = true;
        collision.transform.parent = transform;
        OnPress.Invoke();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isPressed = false;
        collision.transform.parent = null;
        OnRelease.Invoke();
    }
}
