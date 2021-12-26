using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 26/12/2021
 * @last_update 26/12/2021
 * @description classe responsável pelo elemento do parallax
 * 
 */

public class ParallaxElement : MonoBehaviour {

    private SpriteRenderer _sprite;
    private float _speed = 0f;
    private bool _isAfterReference = false;
    private bool _canRecycle = false;

    // Start is called before the first frame update
    void Start() {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate() {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    public void Configure(float newSpeed) {
        _speed = newSpeed;
    }

    public float GetWidth() {
        return _sprite.bounds.size.x;
    }

    public float GetHeight() {
        return _sprite.sprite.bounds.size.y;
    }

    public float GetLimitX() {
        return transform.position.x + _sprite.sprite.bounds.size.x / 2;
    }

    public void SetAfterReference() {
        _isAfterReference = true;
    }

    public bool CanRecycle() {
        return _canRecycle && _isAfterReference;
    }

    public void Recycled() {
        _isAfterReference = false;
        _canRecycle = false;
    }

    private void OnBecameInvisible() {
        if (!_canRecycle && _isAfterReference) _canRecycle = true;
    }

}
