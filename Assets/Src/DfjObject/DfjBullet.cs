using UnityEngine;
using System.Collections;

public class DfjBullet : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * 10;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
