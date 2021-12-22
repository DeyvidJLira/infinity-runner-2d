using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyBase : MonoBehaviour {

    protected Rigidbody2D _rigidbody;
    
    [Header("Attributes")]
    [SerializeField]
    protected int _life = 3;
    [SerializeField]
    protected float _speed = 2f;

    // Start is called before the first frame update
    protected void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected void FixedUpdate() {
        Movement();
    }

    abstract public void Movement();

}