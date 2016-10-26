using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class Player : MonoBehaviour {
    public float speed = 5;
    public Boundary boundary;
    public GameObject shot1;
    public GameObject shot2;
    public float fireRate = 0.1f;
    private float nextFire = 0.0f;

    void Update ()
    {
        
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (Input.GetKey(KeyCode.Z))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    Instantiate(
                        shot1,
                        this.transform.position + new Vector3(0, 0.5f, 0),
                        new Quaternion(0, 0, 0, 0));
                else
                    Instantiate(
                        shot2,
                        this.transform.position + new Vector3(0, 0.5f, 0),
                        new Quaternion(0, 0, 0, 0));

            }
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        float s = speed;
        if (Input.GetKey(KeyCode.LeftShift))
            s /= 3;
        GetComponent<Rigidbody2D>().velocity = movement * s;
        GetComponent<Rigidbody2D>().position = new Vector2
            (
                Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
            );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            GameController gameController = GameObject.FindObjectOfType<GameController>();
            if (gameController != null)
                gameController.GameOver();

            Destroy(gameObject);
        }
        else if (other.tag == "Friend")
        {
            print("朋友");
        }
    }
}
