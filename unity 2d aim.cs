using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField]Camera main;
    [SerializeField] GameObject ball;
    [SerializeField] float bulletSpeed = 5f;
    Vector3 target;
     // Start is called before the first frame update
    void Start()
    {
    }

   

    // Update is called once per frame
    void Update()
    {
        target = main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, transform.position.z));

        Vector3 difference = target - transform.position;
        float rotation = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        if (Input.GetMouseButton(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            FireBullet(direction, rotation);
        }

    }
    private void FireBullet(Vector2 direction, float rotation)
    {

        GameObject balls = Instantiate(ball,transform.position,Quaternion.Euler(0f,0f,rotation)) as GameObject;
        balls.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
       Debug.Log(direction);

    }
}
