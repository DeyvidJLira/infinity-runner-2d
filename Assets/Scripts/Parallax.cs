using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 26/12/2021
 * @last_update 26/12/2021
 * @description classe responsável pelo efeito de parallax
 * 
 */

public class Parallax : MonoBehaviour {

    [Header("Reference Pos")]
    [SerializeField]
    private Transform _referencePos;

    [Header("Back Layers")]
    [SerializeField]
    private float _speedBackLayers;
    [SerializeField]
    private List<ParallaxElement> _listBackLayers;
    private int _indexBackLayer = 0;

    [Header("Front Layers")]
    [SerializeField]
    private List<ParallaxElement> _listFrontLayers;
    [SerializeField]
    private float _speedFrontLayers;
    private int _indexFrontLayer = 0;

    // Start is called before the first frame update
    void Start() {
        _listBackLayers.ForEach(it => {
            it.Configure(_speedBackLayers);
        });
        _listFrontLayers.ForEach(it => {
            it.Configure(_speedFrontLayers);
        });
    }

    // Update is called once per frame
    void Update() {
        VerifyBackLayers();
        VerifyFrontLayers();
        Recycle();
    }

    private void VerifyBackLayers() {
        float distance = _referencePos.position.x - _listBackLayers[_indexBackLayer].GetLimitX();
        if (distance > 1) {
            _listBackLayers[_indexBackLayer].SetAfterReference();
            _indexBackLayer++;
            if (_indexBackLayer >= _listBackLayers.Count) _indexBackLayer = 0;
        }
    }

    private void VerifyFrontLayers() {
        float distance = _referencePos.position.x - _listFrontLayers[_indexFrontLayer].GetLimitX();
        if (distance > 1) {
            _listFrontLayers[_indexFrontLayer].SetAfterReference();
            _indexFrontLayer++;
            if (_indexFrontLayer >= _listFrontLayers.Count) _indexFrontLayer = 0;
        }
    }

    private void Recycle() {
        _listBackLayers.ForEach(element => {
            if (element.CanRecycle()) {
                element.Recycled();
                element.transform.position = new Vector2(element.GetWidth() + _referencePos.position.x, 0f);
            }
        });

        _listFrontLayers.ForEach(element => {
            if (element.CanRecycle()) {
                element.Recycled();
                element.transform.position = new Vector2(element.GetWidth() + _referencePos.position.x, 0f);
            }
        });

    }
}
