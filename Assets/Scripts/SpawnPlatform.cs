using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 13/12/2021
 * @last_update 24/12/2021
 * @description classe respons?vel por instanciar as plataformas e detectar se o usu?rio j? passou por elas a fim de reciclar
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
            currentPlatforms.Add(Instantiate(platforms[i], new Vector2(platforms[i].GetWidth() * i + _distanceX * i , _offset.y + platforms[i].GetModifierY()), transform.rotation));
            _offset.x += platforms[i].GetWidth() * i + _distanceX * i;
        }
    }

    // Update is called once per frame
    void Update() {
        VerifyPositionPlayer();
        Recycle();
    }

    // Verifica a posi??o do jogador em rela??o a plataforma que est? mais a esquerda, caso o jogador j? tenha ultrapassado a plataforma ? avisada
    private void VerifyPositionPlayer() {
        float distanceCurrent = player.position.x - currentPlatforms[_indexPlatformCurrent].GetLimitX();
        if (distanceCurrent > 1) {
            currentPlatforms[_indexPlatformCurrent].SetAfterPlayer();
            _indexPlatformCurrent++;
            if (_indexPlatformCurrent >= currentPlatforms.Count) _indexPlatformCurrent = 0;
        }
    }

    // Realoca a plataforma para uma posi??o ap?s a ?ltima plataforma no gameplay
    private void Recycle() {
        currentPlatforms.ForEach(item => {
            if(item.CanRecyle()) {
                item.Recycled();
                item.transform.position = new Vector2(_offset.x + _distanceX, _offset.y + item.GetModifierY());
                _offset.x += item.GetWidth() + _distanceX;
            }
        });
        
    }
}
