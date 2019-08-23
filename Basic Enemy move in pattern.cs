using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    
   
    

    int trackPointIndex = 0;
    [SerializeField] float moveSpeed= 1f;
    [SerializeField] List<Transform> tracks;
    [SerializeField]float enemyCount = 5;
    // Start is called before the first frame update
    void Start()
    {

       
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        

    }

    private void Move()
    {
        if (trackPointIndex < tracks.Count)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                tracks[trackPointIndex].transform.position, moveSpeed * Time.deltaTime);

        }
        if (transform.position == tracks[trackPointIndex].transform.position)
        {
            if (trackPointIndex < tracks.Count)
            {
                trackPointIndex++;
            }
            else
            {
                return;
            }
            
        }
       

    }
    public List<Transform> GetTrack()
    {
        return tracks;
    }

    
}
