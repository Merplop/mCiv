using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public Vector2 pos;
    public int health = 10;
    public bool selected = false;
    public GameObject highlight;
    public int movesLeft = 2;

    public Unit(Vector2 p) {
        pos = p;
    }

    void OnMouseDown() {
        selected = !selected;
        highlight.SetActive(!highlight.activeSelf);
    }

    void Update() {
       // if (selected && Input.GetMouseButtonDown(1)) {
        //    determinePossibleMoves();
       //     if (Input.GetMouseButtonUp(1)) {
      //          
    //        }
  //      }
    }

    void determinePossibleMoves() {
        double xMin = -1, xMax = 1, yMin = -0.86, yMax = 0.86;
        if (pos.y == 0) {
            yMin = 0;
        }
    }
}
