using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public GameObject settlerPrefab;
    
    public void SpawnSettler(Vector2 p) {
        Vector3 pos = new Vector3(p.x, p.y, -1);
        Instantiate(settlerPrefab, pos, Quaternion.identity);
        RaycastHit2D hit = Physics2D.Raycast(p, p, 0, LayerMask.GetMask("Default"));
        if(hit) {
            SettlerUnit newSettler = hit.collider.gameObject.GetComponent<SettlerUnit>();
     //       newSettler.pos = p;
        }
    }
}
