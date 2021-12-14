using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 13/12/2021
 * @last_update 13/12/2021
 * @description classe respons�vel por representar o objeto plataforma. Ela possui algumas fun��es �teis como obter a largura da plataforma.
 * 
 */

public class Platform : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer _sprite;

    // Retorna a largura da plataforma
    public float getWidth() {
        return _sprite.sprite.bounds.size.x;
    }

    // Retorna a altura da plataforma
    public float getHeight() {
        return _sprite.sprite.bounds.size.y;
    }

    // Retorna a �ltima posi��o X no lado direito da plataforma
    public float getLimitX() {
        return transform.position.x + _sprite.sprite.bounds.size.x / 2;
    }
}
