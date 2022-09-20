using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    public List<Vector2> locations;
    public bool selected;
    private float blockSize;
    void Start()
    {
        transform.position = new Vector3 (Random.Range(8f,9.5f), Random.Range(-1.6f, 1.6f));
        locations = new List<Vector2>();

        if (SceneManager.GetActiveScene().buildIndex == 1)
            blockSize = 1.33333f;
        else
            blockSize = 2f;
    }

    public void snap()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) < 0.8f)
            transform.position = Vector3.zero;
        else if (Vector3.Distance(transform.position, new Vector3(blockSize, blockSize, 0)) < 0.8f)
            transform.position = new Vector3(blockSize, blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(2 * blockSize, 2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(2 * blockSize, 2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-2 * blockSize, -2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-2 * blockSize, -2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-blockSize, -blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-blockSize, -blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-2 * blockSize, -blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-2 * blockSize, -blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(0, -2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(0, -2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-blockSize, -2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-blockSize, -2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(2 * blockSize, 0, 0)) < 0.8f)
            transform.position = new Vector3(2 * blockSize, 0, 0);
        else if (Vector3.Distance(transform.position, new Vector3(0, blockSize, 0)) < 0.8f)
            transform.position = new Vector3(0, blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(2 * blockSize, blockSize, 0)) < 0.8f)
            transform.position = new Vector3(2 * blockSize, blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(blockSize, 2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(blockSize, 2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(0, -3 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(0, -3 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-2 * blockSize, blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-2 * blockSize, blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(blockSize, 0, 0)) < 0.8f)
            transform.position = new Vector3(blockSize, 0, 0);
        else if (Vector3.Distance(transform.position, new Vector3(3 * blockSize, 0, 0)) < 0.8f)
            transform.position = new Vector3(3 * blockSize, 0, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-blockSize, blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-blockSize, blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(blockSize, -blockSize, 0)) < 0.8f)
            transform.position = new Vector3(blockSize, -blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(2 * blockSize, -2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(2 * blockSize, -2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(blockSize, -2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(blockSize, -2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(0, 2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(0, 2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-blockSize, 0, 0)) < 0.8f)
            transform.position = new Vector3(-blockSize, 0, 0);
        else if (Vector3.Distance(transform.position, new Vector3(2 * blockSize, -blockSize, 0)) < 0.8f)
            transform.position = new Vector3(2 * blockSize, -blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(0, -blockSize, 0)) < 0.8f)
            transform.position = new Vector3(0, -blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-2 * blockSize, 0, 0)) < 0.8f)
            transform.position = new Vector3(-2 * blockSize, 0, 0);
        else if (Vector3.Distance(transform.position, new Vector3(3 * blockSize, -2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(3 * blockSize, -2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(3 * blockSize, -blockSize, 0)) < 0.8f)
            transform.position = new Vector3(3 * blockSize, -blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(blockSize, -3 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(blockSize, -3 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(2 * blockSize, -3 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(2 * blockSize, -3 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(3 * blockSize, -3 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(3 * blockSize, -3 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(3 * blockSize, blockSize, 0)) < 0.8f)
            transform.position = new Vector3(3 * blockSize, blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-3 * blockSize, blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-3 * blockSize, blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-3 * blockSize, -2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-3 * blockSize, -2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-3 * blockSize, -blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-3 * blockSize, -blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-3 * blockSize, 0, 0)) < 0.8f)
            transform.position = new Vector3(-3 * blockSize, 0, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-blockSize, -3 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-blockSize, -3 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-2 * blockSize, -3 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-2 * blockSize, -3 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-3 * blockSize, -3 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-3 * blockSize, -3 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-2 * blockSize, 3 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-2 * blockSize, 3 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-blockSize, 3 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-blockSize, 3 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(2 * blockSize, 4 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(2 * blockSize, 4 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-4 * blockSize, 0, 0)) < 0.8f)
            transform.position = new Vector3(-4 * blockSize, 0, 0);
        else if (Vector3.Distance(transform.position, new Vector3(4 * blockSize, 0, 0)) < 0.8f)
            transform.position = new Vector3(4 * blockSize, 0, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-4 * blockSize, -2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-4 * blockSize, -2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(2 * blockSize, -4 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(2 * blockSize, -4 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-2 * blockSize, 2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-2 * blockSize, 2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(blockSize, -4 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(blockSize, -4 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-2 * blockSize, 4 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-2 * blockSize, 4 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-4 * blockSize, 3 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-4 * blockSize, 3 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-4 * blockSize, 4 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-4 * blockSize, 4 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-2 * blockSize, -4 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-2 * blockSize, -4 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(0, 4 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(0, 4 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-4 * blockSize, 2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-4 * blockSize, 2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-4 * blockSize, -4 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-4 * blockSize, -4 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(4 * blockSize, 2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(4 * blockSize, 2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(4 * blockSize, -2 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(4 * blockSize, -2 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(4 * blockSize, 4 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(4 * blockSize, 4 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(0, -4 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(0, -4 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(4 * blockSize, -4 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(4 * blockSize, -4 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(-1 * blockSize, 5 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(-1 * blockSize, 5 * blockSize, 0);
        else if (Vector3.Distance(transform.position, new Vector3(1 * blockSize, 3 * blockSize, 0)) < 0.8f)
            transform.position = new Vector3(1 * blockSize, 3 * blockSize, 0);

        if (GetComponentsInChildren<Transform>().Length > 1)
        {
            List<Vector2> tempLoc = new List<Vector2>();
            int it = 0;
            foreach (Transform child in GetComponentsInChildren<Transform>())
            {
                if (it == 0)
                {
                    it++;
                    continue;
                }
                tempLoc.Add((Vector2)child.position);
            }
            locations = tempLoc;
        }
    }
}
