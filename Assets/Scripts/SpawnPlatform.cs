using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 13/12/2021
 * @last_update 14/12/2021
 * @description classe respons�vel por instanciar as plataformas e detectar se o usu�rio j� passou por elas a fim de reciclar
 * 
 */

public class SpawnPlatform : MonoBehaviour {

    [SerializeField]
    private List<Platform> platforms = new List<Platform>();    //prefab list 

    [SerializeField]
    private float _distanceX = 4f;

    private List<Platform> currentPlatforms = new List<Platform>();    //instantiated list
    private float _offset = 0f;
    private int _indexPlatformCurrent = 0;

    private Transform player;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < platforms.Count; i++) {
            currentPlatforms.Add(Instantiate(platforms[i], new Vector2(platforms[i].getWidth() * i + _distanceX * i , 0), transform.rotation));
            _offset += platforms[i].getWidth() * i + _distanceX * i;
        }
    }

    // Update is called once per frame
    void Update() {
        VerifyPositionPlayer();
    }

    // Verifica a posi��o do jogador em rela��o a plataforma que est� mais a esquerda, caso o jogador j� tenha ultrapassado a plataforma � reciclada
    private void VerifyPositionPlayer() {
        float distanceCurrent = player.position.x - currentPlatforms[_indexPlatformCurrent].getLimitX();
        if (distanceCurrent > 1) {
            Recycle(currentPlatforms[_indexPlatformCurrent]);
            _indexPlatformCurrent++;
            if (_indexPlatformCurrent >= currentPlatforms.Count) _indexPlatformCurrent = 0;
        }
    }

    // Realoca a plataforma para uma posi��o ap�s a �ltima plataforma no gameplay
    private void Recycle(Platform platform) {
        platform.transform.position = new Vector2(_offset + _distanceX, 0f);
        _offset += platform.getWidth() + _distanceX;
    }
}
