using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour {

    public Sprite[] sprites;

    public int type = 0;
    public int grow = 1;
    public int freq = 1;

    public enum Resources {
        Iron,
        Horses,
        Gold,
        Silver
    }

    public enum Improvements {
        Road,
        Mine,
        Pasture,
        City
    }

    public enum CivilianUnits {
        Settler,
        Worker
    }

    public enum MilitaryUnits {
        Warrior
    }

    public Resources currentResources;
    public Improvements currentImprovements;
    public CivilianUnits cUnits;
    public MilitaryUnits mUnits;

    Camera cam;

    public int width = 40;

    public GameObject highlight;
    public GameObject movementHighlight;
//   public GameObject txtPanel;
//    public TextMeshProUGUI txt;

    void OnMouseEnter() {
        highlight.SetActive(true);
   //     txtPanel.SetActive(true);
  //      if (type == 0) {
   //         txt.text = "Water";
    //    } else if (type == 2) {
     //       txt.text = "Grassland";
      //  }
    }

    void OnMouseUp() {
  //      cam.GetComponent<CameraController>().centerOnHex(transform.position);
    }

    void OnMouseDown() {

    }

    void OnMouseExit() {
        highlight.SetActive(false);
  //      txtPanel.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SwapType(int n) {
        type = n;
        GetComponent<SpriteRenderer>().sprite = sprites[n];
    }

    public void Grow() {
        List<Vector2> coords = new List<Vector2>();
        coords.Add(new Vector2(transform.position.x + 1, transform.position.y));
        coords.Add(new Vector2(transform.position.x - 1, transform.position.y));
        coords.Add(new Vector2(transform.position.x - 0.5f, transform.position.y + 0.86f));
        coords.Add(new Vector2(transform.position.x + 0.5f, transform.position.y + 0.86f));
        coords.Add(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.86f));
        coords.Add(new Vector2(transform.position.x + 0.5f, transform.position.y - 0.86f));

        for (int n = 0; n < freq; n++) {
            int m = Mathf.RoundToInt(Random.value * 5);

            if (coords[m].x < 0) {
                Vector2 newCoord = new Vector2(coords[m].x + width, coords[m].y);
                coords[m] = newCoord;
            } else if (coords[m].x >= width) {
                Vector2 newCoord = new Vector2(coords[m].x - width, coords[m].y);
                coords[m] = newCoord;
            }

            RaycastHit2D hit = Physics2D.Raycast(coords[m], coords[m], 0, LayerMask.GetMask("Default"));
            if (hit) {
                Tile newTile = hit.collider.gameObject.GetComponent<Tile>();

                if (newTile.type == 0) {
                    newTile.SwapType(2);

                    if (grow - 1 > 0) {
                        newTile.grow = grow - 1;
                        newTile.freq = freq;
                        newTile.width = width;

                        newTile.Grow();
                    }
                }
            }
        }
    }
}
