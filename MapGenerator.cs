using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    public Vector2 mapSize = new Vector2(35,20);

    public GameObject hex;
    public GameObject hexes;
    Camera cam;

    public int masses = 8;

    public Vector2 grow = new Vector2(7,4);
    public int freq = 3;

    public Button genButton;

    void Start() {
        Generate();

        genButton.onClick.AddListener(Generate);
    }

    void Generate() {
        foreach(Transform child in hexes.transform) {
            Destroy(child.gameObject);
        }

        for (int x = 0; x < mapSize.x; x++) {
            for (int y = 0; y < mapSize.y; y++) {
                Vector2 pos = new Vector2(x, y * 0.86f);

                if (y%2 == 0) {
                    pos.x += 0.5f;
                }

                Instantiate(hex, pos, Quaternion.identity, hexes.transform);
            }
        }

        int massTemp = masses;
        int attempts = 0;

        while (massTemp > 0 && attempts < masses*2) {
            attempts++;

            Vector2 pos = new Vector2(Mathf.Round(Random.value * mapSize.x - 1), Mathf.Round(Random.value * mapSize.y - 1));

            if (pos.y%2 == 0) {
                pos.x += 0.5f;
            }

            pos.y *= 0.86f;

            RaycastHit2D hit = Physics2D.Raycast(pos, pos, 0, LayerMask.GetMask("Default"));
            if (hit) {
                Tile newTile = hit.collider.gameObject.GetComponent<Tile>();

                if (newTile.type == 0) {
                    newTile.SwapType(2);

                    newTile.grow = Mathf.RoundToInt(grow.x + Random.value * (grow.y - grow.x));
                    newTile.freq = freq;
                    newTile.width = (int)mapSize.x;

                    newTile.Grow();

                    massTemp--; 
                }
            }

        } 

    }
}
