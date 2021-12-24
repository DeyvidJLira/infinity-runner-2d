using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 24/12/2021
 * @last_update 24/12/2021
 * @description classe respons�vel por controlar o proj�til do tipo bomba
 * 
 */

public class Bomb : MonoBehaviour {

    private Rigidbody2D _rigidbody;

    [SerializeField]
    private Vector2 _direction = new Vector2(0f,0f);

    // Start is called before the first frame update
    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(_direction, ForceMode2D.Impulse);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
