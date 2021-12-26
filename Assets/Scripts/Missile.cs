using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private float _speedX;

    // Start is called before the first frame update
    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        _rigidbody.velocity = Vector2.right * _speedX;
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

}