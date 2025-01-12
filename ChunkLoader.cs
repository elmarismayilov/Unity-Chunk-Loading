using System.Collections;
using UnityEngine;

public class ChunkLoader : MonoBehaviour
{
    public GameObject player;
    public GameObject[] chunkParents;
    public float activationDistance = 50.0f;
    public float checkInterval = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CheckChunkDistance());
    }
    
    IEnumerator CheckChunkDistance()
    {
        while (true)
        {
            foreach (GameObject chunkParent in chunkParents)
            {
                float distanceToPlayer = Vector3.Distance(player.transform.position, chunkParent.transform.position);
                if (distanceToPlayer <= activationDistance)
                {
                    chunkParent.SetActive(true);
                }
                else
                {
                    chunkParent.SetActive(false);
                }
            }
            yield return new WaitForSeconds(checkInterval);
        }
    }
}
