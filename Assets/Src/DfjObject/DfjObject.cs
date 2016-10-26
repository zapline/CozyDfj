using UnityEngine;
using System.Collections;

public class DfjObject : Singleton<DfjObject>
{
    GameObject enemyObj;
    GameObject explosionObj;

    DfjObject()
    {
        enemyObj = new GameObject("enemyObj");
        var r2d = enemyObj.AddComponent<Rigidbody2D>();
        r2d.gravityScale = 0;
        var cc2d = enemyObj.AddComponent<CircleCollider2D>();
        cc2d.radius = 0.5f;
        cc2d.isTrigger = true;

        explosionObj = new GameObject("explosionObj");
        var a = explosionObj.AddComponent<AudioSource>();
        a.clip = Resources.Load<AudioClip>("Audios/explosion_enemy");
    }

    public GameObject EnemyObj { get { return enemyObj; } }
    public GameObject ExplosionObj { get { return explosionObj; } }
}
