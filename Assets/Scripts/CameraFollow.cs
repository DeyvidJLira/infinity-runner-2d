using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 20/12/2021
 * @last_update 20/12/2021
 * @description classe responsável por colocar a camera para seguir o player
 * 
 */

public class CameraFollow : MonoBehaviour {

    private Transform target;

    [SerializeField]
    private float _smoothSpeed = 500f;
    [SerializeField]
    private Vector2 _offset = new Vector2(5f, 0f);

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate() {
        Vector3 newCameraPosition = new Vector3(target.position.x + _offset.x, _offset.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, _smoothSpeed * Time.deltaTime);        
    }
}
