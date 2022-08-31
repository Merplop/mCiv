using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlerUnit : Unit
{
    public SettlerUnit(Vector2 p) : base(p) {
    }
    
    void Update() {
        if (selected && Input.GetKeyDown("b")) {
            buildCity();
        }
    }

    void buildCity() {
        Destroy(this);
        RaycastHit2D hit = Physics2D.Raycast(pos, pos, 0, LayerMask.GetMask("Default"));
        if(hit) {
            Tile t = hit.collider.gameObject.GetComponent<Tile>();
        }
    }
}
