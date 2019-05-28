using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float maxTime = 1f;
    private float timer = 0;
    public float height = 2f;
    public GameObject pipe;
    GameObject newpipe;
    float setTime;

    // Start is called before the first frame update
    void Start()
    {
        newpipe = Instantiate(pipe);
        newpipe.transform.position = transform.position + new Vector3 (0, Random.Range(-height, height),0);
    }

    // Update is called once per frame
    void Update()
    {  
        if(timer > maxTime)
        {
            newpipe = Instantiate(pipe);
            newpipe.transform.position = transform.position + new Vector3 (0, Random.Range(-height, height), 0);
            Destroy(newpipe, 5);
            timer = 0;
        }



           
        timer += Time.deltaTime;
    }
}
