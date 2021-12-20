using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 13/12/2021
 * @last_update 14/12/2021
 * @description classe responsável por instanciar as plataformas e detectar se o usuário já passou por elas a fim de reciclar
 * 
 */

public class SpawnPlatform : MonoBehaviour {

    [SerializeField]
    private List<Platform> platforms = new List<Platform>();    //prefab list 

    [SerializeField]
    private float _distanceX = 4f;
    [SerializeField]
    private Vector2 _offset = new Vector2(0f, -4.5f);

    private List<Platform> currentPlatforms = new List<Platform>();    //instantiated list
    private int _indexPlatformCurrent = 0;

    private Transform player;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < platforms.Count; i++) {
            currentPlatforms.Add(Instantiate(platforms[i], new Vector2(platforms[i].getWidth() * i + _distanceX * i , _offset.y + platforms[i].getModifierY()), transform.rotation));
            _offset.x += platforms[i].getWidth() * i + _distanceX * i;
        }
    }

    // Update is called once per frame
    void Update() {
        VerifyPositionPlayer();
    }

    // Verifica a posição do jogador em relação a plataforma que está mais a esquerda, caso o jogador já tenha ultrapassado a plataforma é reciclada
    private void VerifyPositionPlayer() {
        float distanceCurrent = player.position.x - currentPlatforms[_indexPlatformCurrent].getLimitX();
        if (distanceCurrent > 1) {
            Recycle(currentPlatforms[_indexPlatformCurrent]);
            _indexPlatformCurrent++;
            if (_indexPlatformCurrent >= currentPlatforms.Count) _indexPlatformCurrent = 0;
        }
    }

    // Realoca a plataforma para uma posição após a última plataforma no gameplay
    private void Recycle(Platform platform) {
        platform.transform.position = new Vector2(_offset.x + _distanceX, _offset.y + platform.getModifierY());
        _offset.x += platform.getWidth() + _distanceX;
    }
}
