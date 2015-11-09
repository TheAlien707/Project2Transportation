using UnityEngine;
using System.Collections;

public class Airplane {
    public int startRow=8;
    public int startCol=0;
    public int x, y;
    // the startRow/startCol is wherever the inital airplane is and the x/y are the current position
    public bool active;
    public int currentCargo = 0;
    public int maxCargo = 90;
    public int cargoToAdd = 10;
    public int directionToTravel = 0;
    //direction to travel determines which way to go: 1 = left, 2 = up, 3 = right, 4 = down
    //airplanes are fast, they go every turn
    public int turnSpeed = 1;
    public bool movingSomewhere = false;
    public int endX;
    public int endY;
    //these variables are for moving the airplane to the new location
    public bool moveRight;
    public bool moveDown;
    public int howFarHorizontal = 0;
    public int howFarVertical = 0;

    public void OnKeyDown()
    {
        if (Input.GetKeyUp("left"))
        {
            directionToTravel = 1;
        }
        else if (Input.GetKeyUp("up"))
        {
            directionToTravel = 2;
        }
        else if (Input.GetKeyUp("right"))
        {
            directionToTravel = 3;
        }
        else if (Input.GetKeyUp("down"))
        {
            directionToTravel = 4;
        }
        
    }

    public void addCargo()
    {
        if (x == startCol && y == startRow && currentCargo<maxCargo) 
        //if the airplane is in its starting position, it will add cargo as long as it can still carry it
        {
            currentCargo += cargoToAdd;
        }
    }

}
