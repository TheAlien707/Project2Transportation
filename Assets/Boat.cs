using UnityEngine;
using System.Collections;

public class Boat {
    public int maxCargo = 550;
    //boats should be slow, so they go every 3 turns
    public int turnSpeed = 3;
    public int startRow = 8;
    public int startCol = 15;
    public int x, y;
    public int cargoToAdd = 10;
    public int currentCargo = 0;
    public bool active;
    public bool movingSomewhere = false;
    public int endX;
    public int endY;
    //these variables are for moving the boat to the new location
    public bool moveRight;
    public bool moveDown;
    public int howFarHorizontal = 0;
    public int howFarVertical = 0;

    public void addCargo()
    {
        if (x == startCol && y == startRow && currentCargo < maxCargo)
        //if the airplane is in its starting position, it will add cargo as long as it can still carry it
        {
            currentCargo += cargoToAdd;
        }
    }
}
