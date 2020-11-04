using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Vector3 SpawnerSize;
    public Color GizmosColor;
    public GameObject TargetObject;
    public GameObject Object;
    public int ObjectCount;
    void Start()
    {
        
    }
    void Update() {
        while (CheckSpawn(ObjectCount))
        {
            StartCoroutine(spawnObject());
        }
    }
    public void addSpawnCoubt(int i){
        ObjectCount = i;
    }
    bool CheckSpawn(int count)
    {
        if (count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator spawnObject()
    {
        Vector3 gizmosPos = new Vector3(TargetObject.transform.position.x, TargetObject.transform.position.y, 0);
        Vector3 SpawnPos = gizmosPos + new Vector3(Random.Range(-SpawnerSize.x / 2, SpawnerSize.x / 2),
                                       Random.Range(-SpawnerSize.y / 2, SpawnerSize.y / 2), 0);
        Instantiate(Object, SpawnPos, Quaternion.identity);
        ObjectCount -= 1;
        yield return new WaitForSeconds(1f);
    }
    private void OnDrawGizmos()
    {
        if (TargetObject != null)
        {
            Gizmos.color = GizmosColor;
            Gizmos.DrawWireCube(TargetObject.transform.position, SpawnerSize);
        }
    }
}
