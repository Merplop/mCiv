using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
 //   public GameObject grid;
    public GameObject cam;
    public Vector2 playerStart;
    public Button button;
    public GameObject UnitController;

    public void genStart() {
        Vector2 mapSize = cam.GetComponent<MapGenerator>().mapSize;
        bool cont = true;
        while(cont) {
            Vector2 pos = new Vector2(Mathf.Round(Random.value * mapSize.x - 1), Mathf.Round(Random.value * mapSize.y - 1));

            if (pos.y%2 == 0) {
                pos.x += 0.5f;
            }

            pos.y *= 0.86f;

            RaycastHit2D hit = Physics2D.Raycast(pos, pos, 0, LayerMask.GetMask("Default"));
            if (hit) {
                Tile newTile = hit.collider.gameObject.GetComponent<Tile>();
                
                if (newTile.type == 2) {
        //            newTile.SwapType(3);
                    playerStart = pos;
                    cont = false;
                    newTile.cUnits = Tile.CivilianUnits.Settler;
                    UnitController.GetComponent<UnitController>().SpawnSettler(pos);
                }
            }
        }           
    }

    void Start() {
        button.onClick.AddListener(genStart);
    }
}
