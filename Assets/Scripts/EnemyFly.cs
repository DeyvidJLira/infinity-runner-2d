using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : EnemyBase {

    public override void Movement() {
        _rigidbody.velocity = new Vector2(-_speed, _rigidbody.velocity.y);
    }

}
