using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laservelocity = 20f;
    float horizontal;
    float vertical;
    float xMax;
    float xMin;
    float yMax;
    float yMin;
    [SerializeField]float margin = 1f;
    [SerializeField] float moveSpeed= 5f;
    Coroutine firingCoroutine;
    

    // Start is called before the first frame update
    void Start()
    {
        horizontal = Input.GetAxis("Horizontal")*Time.deltaTime * moveSpeed;
        vertical = Input.GetAxis("Vertical")*Time.deltaTime* moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        SetUpBoundaries();
    }

    private void Fire()
    {
      
        if (Input.GetButtonDown("Fire1"))
        {


            firingCoroutine = StartCoroutine(FireAll());

        }
        if (Input.GetButtonUp("Fire1"))
        {
            
            StopCoroutine(firingCoroutine);
           
        }
        }
    IEnumerator FireAll()
    {
        
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, transform.rotation) as GameObject;
            Vector3 myForward = transform.TransformDirection(Vector3.forward);



            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laservelocity);
            laser.GetComponent<Rigidbody2D>().gravityScale = 0;
            yield return new WaitForSeconds(0.1f);

        }

    }

    private void SetUpBoundaries()
    {
        Camera camera = Camera.main;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y- margin;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+ margin;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-margin;
        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+ margin;
    }

    private void Move()
    {
        horizontal =  transform.position.x+ (Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed);
        vertical = transform.position.y + (Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
      
        transform.position = new Vector2(Mathf.Clamp(horizontal,xMin,xMax), Mathf.Clamp(vertical,yMin,yMax));
        

    }
}
