using UnityEngine;
using System.Collections;

public class Train {
    public int maxCargo = 200;
    //trains are "normal" speed and should go every other turn
    public int turnSpeed = 2;
    public int startRow = 0;
    public int startCol = 0;
    public int x, y;
    public int cargoToAdd = 10;
    public int currentCargo = 0;
    public bool active;
    public bool movingSomewhere = false;
    public int endX;
    public int endY;
    //these variables are for moving the train to the new location
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
