using UnityEngine;
using System.Collections;

public class DfjEnemy : MonoBehaviour {
    GameObject ExplosionObj;
    public GameObject ShotObj;

    void Start()
    {
        ExplosionObj = DfjObject.Instance.ExplosionObj;
        GetComponent<Rigidbody2D>().velocity = transform.up * -3;
    }

    void OnDestroy()
    {
        var explosion = Instantiate(ExplosionObj, transform.position, transform.rotation);
        Destroy(explosion, 3);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }
    }
}
