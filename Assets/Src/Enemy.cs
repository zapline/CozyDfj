using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public GameObject ExplosionObj;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "PlayerBullet")
        {
            var explosion = Instantiate(ExplosionObj, transform.position, transform.rotation);
            Destroy(explosion, 3);

            Destroy(gameObject);
        }
    }
}
