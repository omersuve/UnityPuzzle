using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    public Vector3 RightPos;
    public bool isInRightPos = false;
    public List<Vector3> locations;
    public bool selected;
    private float blockSize;
    void Start()
    {
        RightPos = transform.position;
        transform.position = new Vector3 (Random.Range(7f,8f), Random.Range(-2f, 2f));
        if (SceneManager.GetActiveScene().buildIndex == 1)
            blockSize = 1.33333f;
        else
            blockSize = 2f;
    }

    void Update()
    {
        if (!selected)
        {
            if(Vector3.Distance(transform.position, RightPos) < 1f)
            {
                transform.position = RightPos;
                isInRightPos = true;
            }
            else
                isInRightPos = false;    
            if (Vector3.Distance(transform.position, Vector3.zero) < 1f)
                transform.position = Vector3.zero;
            else if (Vector3.Distance(transform.position,new Vector3(blockSize, blockSize, 0)) < 1f)
                transform.position =new Vector3(blockSize, blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(2*blockSize, 2*blockSize, 0)) < 1f)
                transform.position =new Vector3(2*blockSize, 2*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-2*blockSize, -2*blockSize, 0)) < 1f)
                transform.position =new Vector3(-2*blockSize, -2*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-blockSize, -blockSize, 0)) < 1f)
                transform.position =new Vector3(-blockSize, -blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-2*blockSize, -blockSize, 0)) < 1f)
                transform.position =new Vector3(-2*blockSize, -blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(0, -2*blockSize, 0)) < 1f)
                transform.position =new Vector3(0, -2*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-blockSize, -2*blockSize, 0)) < 1f)
                transform.position =new Vector3(-blockSize, -2*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(2*blockSize, 0, 0)) < 1f)
                transform.position =new Vector3(2*blockSize, 0, 0);
            else if (Vector3.Distance(transform.position,new Vector3(0, blockSize, 0)) < 1f)
                transform.position =new Vector3(0, blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(2*blockSize, blockSize, 0)) < 1f)
                transform.position =new Vector3(2*blockSize, blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(blockSize, 2*blockSize, 0)) < 1f)
                transform.position =new Vector3(blockSize, 2*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(0, -3*blockSize, 0)) < 1f)
                transform.position =new Vector3(0, -3*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-2*blockSize, blockSize, 0)) < 1f)
                transform.position =new Vector3(-2*blockSize, blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(blockSize, 0, 0)) < 1f)
                transform.position =new Vector3(blockSize, 0, 0);
            else if (Vector3.Distance(transform.position,new Vector3(3*blockSize, 0, 0)) < 1f)
                transform.position =new Vector3(3*blockSize, 0, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-blockSize, blockSize, 0)) < 1f)
                transform.position =new Vector3(-blockSize, blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(blockSize, -blockSize, 0)) < 1f)
                transform.position =new Vector3(blockSize, -blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(2*blockSize, -2*blockSize, 0)) < 1f)
                transform.position =new Vector3(2*blockSize, -2*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(blockSize, -2*blockSize, 0)) < 1f)
                transform.position =new Vector3(blockSize, -2*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(0, 2*blockSize, 0)) < 1f)
                transform.position =new Vector3(0, 2*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-blockSize, 0, 0)) < 1f)
                transform.position =new Vector3(-blockSize, 0, 0);
            else if (Vector3.Distance(transform.position,new Vector3(2*blockSize, -blockSize, 0)) < 1f)
                transform.position =new Vector3(2*blockSize, -blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(0, -blockSize, 0)) < 1f)
                transform.position =new Vector3(0, -blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-2*blockSize, 0, 0)) < 1f)
                transform.position =new Vector3(-2*blockSize, 0, 0);
            else if (Vector3.Distance(transform.position,new Vector3(3*blockSize, -2*blockSize, 0)) < 1f)
                transform.position =new Vector3(3*blockSize, -2*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(3*blockSize, -blockSize, 0)) < 1f)
                transform.position =new Vector3(3*blockSize, -blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(blockSize, -3*blockSize, 0)) < 1f)
                transform.position =new Vector3(blockSize, -3*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(2*blockSize, -3*blockSize, 0)) < 1f)
                transform.position =new Vector3(2*blockSize, -3*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(3*blockSize, -3*blockSize, 0)) < 1f)
                transform.position =new Vector3(3*blockSize, -3*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(3*blockSize, blockSize, 0)) < 1f)
                transform.position =new Vector3(3*blockSize, blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-3*blockSize, blockSize, 0)) < 1f)
                transform.position =new Vector3(-3*blockSize, blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-3*blockSize, -2*blockSize, 0)) < 1f)
                transform.position =new Vector3(-3*blockSize, -2*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-3*blockSize, -blockSize, 0)) < 1f)
                transform.position =new Vector3(-3*blockSize, -blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-3*blockSize, 0, 0)) < 1f)
                transform.position =new Vector3(-3*blockSize, 0, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-blockSize, -3*blockSize, 0)) < 1f)
                transform.position =new Vector3(-blockSize, -3*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-2*blockSize, -3*blockSize, 0)) < 1f)
                transform.position =new Vector3(-2*blockSize, -3*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-3*blockSize, -3*blockSize, 0)) < 1f)
                transform.position =new Vector3(-3*blockSize, -3*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-2*blockSize, 3*blockSize, 0)) < 1f)
                transform.position =new Vector3(-2*blockSize, 3*blockSize, 0);
            else if (Vector3.Distance(transform.position,new Vector3(-blockSize, 3*blockSize, 0)) < 1f)
                transform.position =new Vector3(-blockSize, 3*blockSize, 0);
            else if (Vector3.Distance(transform.position, new Vector3(2*blockSize, 4*blockSize, 0)) < 1f)
                transform.position = new Vector3(2*blockSize, 4 * blockSize, 0);
            else if (Vector3.Distance(transform.position, new Vector3(-4 * blockSize, 0, 0)) < 1f)
                transform.position = new Vector3(-4*blockSize, 0, 0);
            else if (Vector3.Distance(transform.position, new Vector3(4 * blockSize, 0, 0)) < 1f)
                transform.position = new Vector3(4 * blockSize, 0, 0);
            else if (Vector3.Distance(transform.position, new Vector3(-4 * blockSize, -2 * blockSize, 0)) < 1f)
                transform.position = new Vector3(-4 * blockSize, -2*blockSize, 0);
            else if (Vector3.Distance(transform.position, new Vector3(2 * blockSize, -4 * blockSize, 0)) < 1f)
                transform.position = new Vector3(2 * blockSize, -4 * blockSize, 0);
            else if (Vector3.Distance(transform.position, new Vector3(-2 * blockSize, 2 * blockSize, 0)) < 1f)
                transform.position = new Vector3(-2 * blockSize, 2 * blockSize, 0);
            else if (Vector3.Distance(transform.position, new Vector3(blockSize, -4 * blockSize, 0)) < 1f)
                transform.position = new Vector3(blockSize, -4 * blockSize, 0);
            else
            {
            }
        }
            //isInRightPos = false;
        //if (Vector3.Distance(transform.position, loc) < 0.5f)
        //{
        //    transform.position = loc;
        //}
    }
}
