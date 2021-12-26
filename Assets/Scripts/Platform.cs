using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 13/12/2021
 * @last_update 24/12/2021
 * @description classe responsável por representar o objeto plataforma. Ela possui algumas funções úteis como obter a largura da plataforma.
 * 
 */

public class Platform : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer _sprite;
    [SerializeField]
    private float _modifierY = 0f;
    [SerializeField]
    private List<Transform> _listSpawnPoints;
    [SerializeField]
    private bool _enableSpawnEnemy = false;
    [SerializeField]
    private GameObject _enemyPrefab;

    private bool _isAfterPlayer = false;
    private bool _canRecycle = false;

    // Retorna a largura da plataforma
    public float GetWidth() {
        return _sprite.sprite.bounds.size.x;
    }

    // Retorna a altura da plataforma
    public float GetHeight() {
        return _sprite.sprite.bounds.size.y;
    }

    // Retorna a última posição X no lado direito da plataforma
    public float GetLimitX() {
        return transform.position.x + _sprite.sprite.bounds.size.x / 2;
    }

    // Retorna um valor para modificar a posição no eixo Y
    public float GetModifierY() {
        return _modifierY;
    }

    public bool CanRecyle() {
        return _canRecycle;
    }

    public void SetAfterPlayer() {
        _isAfterPlayer = true;
    }

    public void Recycled() {
        _canRecycle = false;
        _isAfterPlayer = false;
        SpawnEnemy();
    }

    private void OnBecameInvisible() {
        if (!_canRecycle && _isAfterPlayer) _canRecycle = true;
    }

    private void SpawnEnemy() {
        Debug.Log(_listSpawnPoints.Count);
        int pos = Random.Range(0, _listSpawnPoints.Count);
        Debug.Log("Pos: " + _listSpawnPoints.Count);
        if (pos == _listSpawnPoints.Count) return;
        Instantiate(_enemyPrefab, _listSpawnPoints[pos].position, Quaternion.identity, transform);
    }
}
