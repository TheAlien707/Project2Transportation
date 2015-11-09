using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

    public GameObject squareTile;
    private GameObject[,] allTiles;
    public Material AirplaneColor;
    public Material BoatColor;
    public Material TrainColor;
    public Material Off;
    public Material Active;
    public Material Depot;
    int numTilesInRow = 16;
    int numRowsofTiles = 9;
    public Airplane airplane;
    public int playerPoints = 0;
    public int pointsPerTonOfCargo = 1;
    public int pointsEarned = 0;
    public DeliveryDepot depot;
    float turnLength = 1.5f;
    float turnStart = 0f;
    public int turnNum = 1;
    public string scoreText;
    public string turnText = "It is turn";
    public Boat boat;
    public Train train;


    public void ProcessClickedTile(GameObject clickedTile, int x, int y)
    //depot turns white after airplane lands on it; fix. Martha suggested a check to see if airplane was on
    {
        //if player clicked unactive (red) airplane, it should activate
        if ((x == airplane.x && y == airplane.y) && airplane.active == false && train.active == false && boat.active == false)
        {
            airplane.active = true;
            clickedTile.GetComponent<Renderer>().material = Active;
        }

        // If the player clicks an active (yellow) airplane, it should deactivate
        else if (x == airplane.x && y == airplane.y && airplane.active)
        {
            airplane.active = false;
            clickedTile.GetComponent<Renderer>().material = AirplaneColor;
        }
        //if player clicked unactive (green) train, activate
        else if (x == train.x && y == train.y && airplane.active == false && train.active == false && boat.active == false)
        {
            train.active = true;
            clickedTile.GetComponent<Renderer>().material = Active;
        }
        //if player clicked active (yellow) train, deactivate
        else if (x == train.x && y == train.y && train.active == true)
        {
            train.active = false;
            clickedTile.GetComponent<Renderer>().material = TrainColor;
        }
        //if player clicked unactive (blue) boat, activate
        else if (x == boat.x && y == boat.y && airplane.active == false && train.active == false && boat.active == false)
        {
            boat.active = true;
            clickedTile.GetComponent<Renderer>().material = Active;
        }
        //if player clicked active (yellow) boat, deactivate
        else if (x == boat.x && y == boat.y && boat.active == true)
        {
            boat.active = false;
            clickedTile.GetComponent<Renderer>().material = BoatColor;
        }
        // If the player clicks the sky and there isn’t an active airplane, 
        //   nothing happens.

        //player clicked on a new tile with an active airplane
        else if (airplane.active && (x != airplane.x || y != airplane.y))
        {
            airplane.movingSomewhere = true;
            //endX&endY are to use to check when vehicle is done moving
            airplane.endX = x;
            airplane.endY = y;
            //find out if going left or right (if at all)
            if (x != airplane.x)
            {
                if (x > airplane.x)
                {
                    airplane.howFarHorizontal = x - airplane.x;
                    airplane.moveRight = true;
                }
                else if (x < airplane.x)
                {
                    airplane.howFarHorizontal = airplane.x - x;
                    airplane.moveRight = false;
                }
                //print(moveRight);
                //print("horizontal" + howFarHorizontal);
            }
            //find out if going up or down (if at all)
            if (y != airplane.y)
            {
                if (y > airplane.y)
                {
                    airplane.howFarVertical = y - airplane.y;
                    airplane.moveDown = false;
                }
                else if (y < airplane.y)
                {
                    airplane.howFarVertical = airplane.y - y;
                    airplane.moveDown = true;
                }
                //print(moveDown);
                //print("vertical" + howFarVertical);
            }
        }
        //player clicked on tile while train is active
        else if (train.active && (x != train.x || y != train.y))
        {
            train.movingSomewhere = true;
            //endX&endY are to use to check when vehicle is done moving
            train.endX = x;
            train.endY = y;
            //find out if going left or right (if at all)
            if (x != train.x)
            {
                if (x > train.x)
                {
                    train.howFarHorizontal = x - train.x;
                    train.moveRight = true;
                }
                else if (x < train.x)
                {
                    train.howFarHorizontal = train.x - x;
                    train.moveRight = false;
                }
                //print(moveRight);
                //print("horizontal" + howFarHorizontal);
            }
            //find out if going up or down (if at all)
            if (y != train.y)
            {
                if (y > train.y)
                {
                    train.howFarVertical = y - train.y;
                    train.moveDown = false;
                }
                else if (y < train.y)
                {
                    train.howFarVertical = train.y - y;
                    train.moveDown = true;
                }
                //print(moveDown);
                //print("vertical" + howFarVertical);
            }
        }
        else if (boat.active && (x != boat.x || y != boat.y))
        {
            boat.movingSomewhere = true;
            //endX&endY are to use to check when vehicle is done moving
            boat.endX = x;
            boat.endY = y;
            //find out if going left or right (if at all)
            if (x != boat.x)
            {
                if (x > boat.x)
                {
                    boat.howFarHorizontal = x - boat.x;
                    boat.moveRight = true;
                }
                else if (x < boat.x)
                {
                    boat.howFarHorizontal = boat.x - x;
                    boat.moveRight = false;
                }
                //print(moveRight);
                //print("horizontal" + howFarHorizontal);
            }
            //find out if going up or down (if at all)
            if (y != boat.y)
            {
                if (y > boat.y)
                {
                    boat.howFarVertical = y - boat.y;
                    boat.moveDown = false;
                }
                else if (y < boat.y)
                {
                    boat.howFarVertical = boat.y - y;
                    boat.moveDown = true;
                }
                //print(moveDown);
                //print("vertical" + howFarVertical);
            }
        }
        /*//This bit of code is for teleporting, no longer wanted in final
        else if (airplane.active && (x != airplane.x || y != airplane.y))
        {// Set the old tile to white
            allTiles[airplane.x, airplane.y].GetComponent<Renderer>().material = Off;

            // Set the new cube to yellow (since the airplane is still active)
            allTiles[x, y].GetComponent<Renderer>().material = Active;

            // Update the airplane to be in the new location
            airplane.x = x;
            airplane.y = y;
        */
    }

    public void addPoints()
    {
        if (airplane.x == depot.x && airplane.y == depot.y)
        {
            //add points according to how many tons of cargo delivered
            pointsEarned = airplane.currentCargo * pointsPerTonOfCargo;
            playerPoints += pointsEarned;
            //reset airplane cargo
            airplane.currentCargo = 0;
        }
        if (train.x == depot.x && train.y == depot.y)
        {
            //add points
            pointsEarned = train.currentCargo * pointsPerTonOfCargo;
            playerPoints += pointsEarned;
            //reset  cargo
            train.currentCargo = 0;
        }
        if (boat.x == depot.x && boat.y == depot.y)
        {
            //add points
            pointsEarned = boat.currentCargo * pointsPerTonOfCargo;
            playerPoints += pointsEarned;
            //reset  cargo
            boat.currentCargo = 0;
        }
        print("player score is" + playerPoints);
    }

    /*public void updateScoreText()
    {
        playerScoreText.text = "Score" + playerPoints;
    }
    */

    public void moveAirplane()
    {
        if (airplane.movingSomewhere == true)
        {
            //set old tile to white
            allTiles[airplane.x, airplane.y].GetComponent<Renderer>().material = Off;
            //move to the new position
            //moving diagonally
            if (airplane.howFarVertical > 0 && airplane.howFarHorizontal > 0)
            {
                if (airplane.moveRight == true && airplane.moveDown == true)
                {
                    airplane.x++;
                    airplane.y--;
                }
                else if (airplane.moveRight == true && airplane.moveDown == false)
                {
                    airplane.x++;
                    airplane.y++;
                }
                else if (airplane.moveRight == false && airplane.moveDown == true)
                {
                    airplane.x--;
                    airplane.y--;
                }
                else if (airplane.moveRight == false && airplane.moveDown == false)
                {
                    airplane.x--;
                    airplane.y++;
                }
                airplane.howFarVertical--;
                airplane.howFarHorizontal--;
            }
            //moving horizontally
            else if (airplane.howFarHorizontal > 0 && airplane.howFarVertical == 0)
            {
                if (airplane.moveRight == true)
                {
                    airplane.x++;
                }
                else if (airplane.moveRight == false)
                {
                    airplane.x--;
                }
                airplane.howFarHorizontal--;
            }
            //moving vertically
            else if (airplane.howFarVertical > 0 && airplane.howFarHorizontal == 0)
            {
                if (airplane.moveDown == true)
                {
                    airplane.y--;
                }
                if (airplane.moveDown == false)
                {
                    airplane.y++;
                }
                airplane.howFarVertical--;
            }
            //color the new tile
            if (airplane.active == true)
            {
                allTiles[airplane.x, airplane.y].GetComponent<Renderer>().material = Active;
            }
            else if (boat.active == false)
            {
                allTiles[airplane.x, airplane.y].GetComponent<Renderer>().material = AirplaneColor;
            }
        }
        else if (airplane.movingSomewhere == true && (airplane.x == airplane.endX && airplane.y == airplane.endY))
        {
            //just finished moving somewhere
            airplane.movingSomewhere = false;
        }
        else if (airplane.movingSomewhere == false)
        {
            //not moving anywhere, so just make sure everything's colored correctly
            if (airplane.active == true)
            {
                allTiles[airplane.x, airplane.y].GetComponent<Renderer>().material = Active;
            }
            else if (airplane.active == false)
            {
                allTiles[airplane.x, airplane.y].GetComponent<Renderer>().material = AirplaneColor;
            }
        }
    }
    /* this is moving through the mouse keys; not wanted in final version
    if (airplane.directionToTravel != 0)
    {
        //set old tile to white
        allTiles[airplane.x, airplane.y].GetComponent<Renderer>().material = Off;
        //move the airplane
        if (airplane.directionToTravel == 1 && airplane.x > 0) //left
        {
            airplane.x -= 1;
        }
        else if (airplane.directionToTravel == 2 && airplane.y < 8) //up
        {
            airplane.y += 1;
        }
        else if (airplane.directionToTravel == 3 && airplane.x < 15) //right
        {
            airplane.x += 1;
        }
        else if (airplane.directionToTravel == 4 && airplane.y > 0) //down
        {
            airplane.y -= 1;
        }
        //color the new tile to show that the airplane has moved
        allTiles[airplane.x, airplane.y].GetComponent<Renderer>().material = On;
    }
    */

    public void moveTrain()
    {
        if (train.movingSomewhere == true)
        {
            //set old tile to white
            allTiles[train.x, train.y].GetComponent<Renderer>().material = Off;
            //move to the new position
            //moving diagonally
            if (train.howFarVertical > 0 && train.howFarHorizontal > 0)
            {
                if (train.moveRight == true && train.moveDown == true)
                {
                    train.x++;
                    train.y--;
                }
                else if (train.moveRight == true && train.moveDown == false)
                {
                    train.x++;
                    train.y++;
                }
                else if (train.moveRight == false && train.moveDown == true)
                {
                    train.x--;
                    train.y--;
                }
                else if (train.moveRight == false && train.moveDown == false)
                {
                    train.x--;
                    train.y++;
                }
                train.howFarVertical--;
                train.howFarHorizontal--;
            }
            //moving horizontally
            else if (train.howFarHorizontal > 0 && train.howFarVertical == 0)
            {
                if (train.moveRight == true)
                {
                    train.x++;
                }
                else if (train.moveRight == false)
                {
                    train.x--;
                }
                train.howFarHorizontal--;
            }
            //moving vertically
            else if (train.howFarVertical > 0 && train.howFarHorizontal == 0)
            {
                if (train.moveDown == true)
                {
                    train.y--;
                }
                if (train.moveDown == false)
                {
                    train.y++;
                }
                train.howFarVertical--;
            }
            //color the new tile
            if (train.active == true)
            {
                allTiles[train.x, train.y].GetComponent<Renderer>().material = Active;
            }
            else if (train.active == false)
            {
                allTiles[train.x, train.y].GetComponent<Renderer>().material = TrainColor;
            }
        }
        else if (train.movingSomewhere == true && (train.x == train.endX && train.y == train.endY))
        {
            //just finished moving somewhere
            train.movingSomewhere = false;
        }
        else if (train.movingSomewhere == false)
        {
            //not moving anywhere, so just make sure everything's colored correctly
            if (train.active == true)
            {
                allTiles[train.x, train.y].GetComponent<Renderer>().material = Active;
            }
            else if (train.active == false)
            {
                allTiles[train.x, train.y].GetComponent<Renderer>().material = TrainColor;
            }
        }
    }

    public void moveBoat()
    {
        if (boat.movingSomewhere == true)
        {
            //set old tile to white
            allTiles[boat.x, boat.y].GetComponent<Renderer>().material = Off;
            //move to the new position
            //moving diagonally
            if (boat.howFarVertical > 0 && boat.howFarHorizontal > 0)
            {
                if (boat.moveRight == true && boat.moveDown == true)
                {
                    boat.x++;
                    boat.y--;
                }
                else if (boat.moveRight == true && boat.moveDown == false)
                {
                    boat.x++;
                    boat.y++;
                }
                else if (boat.moveRight == false && boat.moveDown == true)
                {
                    boat.x--;
                    boat.y--;
                }
                else if (boat.moveRight == false && boat.moveDown == false)
                {
                    boat.x--;
                    boat.y++;
                }
                boat.howFarVertical--;
                boat.howFarHorizontal--;
            }
            //moving horizontally
            else if (boat.howFarHorizontal > 0 && boat.howFarVertical == 0)
            {
                if (boat.moveRight == true)
                {
                    boat.x++;
                }
                else if (boat.moveRight == false)
                {
                    boat.x--;
                }
                boat.howFarHorizontal--;
            }
            //moving vertically
            else if (boat.howFarVertical > 0 && boat.howFarHorizontal == 0)
            {
                if (boat.moveDown == true)
                {
                    boat.y--;
                }
                if (boat.moveDown == false)
                {
                    boat.y++;
                }
                boat.howFarVertical--;
            }
            //color the new tile
            if (boat.active == true)
            {
                allTiles[boat.x, boat.y].GetComponent<Renderer>().material = Active;
            }
            else if (boat.active == false)
            {
                allTiles[boat.x, boat.y].GetComponent<Renderer>().material = BoatColor;
            }
            
        }
        else if (boat.movingSomewhere == true && (boat.x == boat.endX && boat.y == boat.endY))
        {
            //just finished moving somewhere
            boat.movingSomewhere = false;
        }
        else if (boat.movingSomewhere == false)
        {
            //not moving anywhere, so just make sure everything's colored correctly
            if (boat.active == true)
            {
                allTiles[boat.x, boat.y].GetComponent<Renderer>().material = Active;
            }
            else if (boat.active == false)
            {
                allTiles[boat.x, boat.y].GetComponent<Renderer>().material = BoatColor;
            }
        }

    }

    public void keepDepotColoredCorrectly()
    {
        //make sure delivery depot is black whenever a vehicle  is not there
        if ((airplane.x != depot.x || airplane.y != depot.y) && (boat.x != depot.x || boat.y != depot.y ) && (train.x != depot.x ||train.y != depot.y))
        {
           allTiles[depot.x, depot.y].GetComponent<Renderer>().material = Depot;
        }
    }

    public void keepVehiclesColoredCorrectly()
    {
        //airplane
        if (airplane.active == true)
        {
            allTiles[airplane.x, airplane.y].GetComponent<Renderer>().material = Active;
        }
        else if (airplane.active == false)
        {
            allTiles[airplane.x, airplane.y].GetComponent<Renderer>().material = AirplaneColor;
        }
        //train
        if (train.active == true)
        {
            allTiles[train.x, train.y].GetComponent<Renderer>().material = Active;
        }
        else if (train.active == false)
        {
            allTiles[train.x, train.y].GetComponent<Renderer>().material = TrainColor;
        }
        //boat
        if (boat.active == true)
        {
            allTiles[boat.x, boat.y].GetComponent<Renderer>().material = Active;
        }
        else if (boat.active == false)
        {
            allTiles[boat.x, boat.y].GetComponent<Renderer>().material = BoatColor;
        }
    }

    // Use this for initialization
    void Start () {
        //making the tiles
        airplane = new Airplane();
        depot = new DeliveryDepot();
        train = new Train();
        boat = new Boat();
        // numTilesInRow is how many tiles should be in each row
        // numRowsofTiles is how many rows of tiles should there be
        // rowOfTiles and tilesInRow are how many has Unity made so far
        //allTiles is the array holding everything
        allTiles = new GameObject [numTilesInRow,numRowsofTiles];
        for (int rowOfTiles=0; rowOfTiles < numRowsofTiles; rowOfTiles++)
        {
            for (int tilesInRow=0; tilesInRow < numTilesInRow; tilesInRow++)
            {
                allTiles[tilesInRow,rowOfTiles] = (GameObject)Instantiate(squareTile, new Vector3(tilesInRow * 2 - 14, rowOfTiles*2-8, 10), Quaternion.identity) as GameObject;
                allTiles[tilesInRow,rowOfTiles].GetComponent<tileBehavior>().x = tilesInRow;
                allTiles[tilesInRow, rowOfTiles].GetComponent<tileBehavior>().y = rowOfTiles;
            }
        }
        //airplane starts in topmost left corner of grid
        airplane.x = airplane.startCol;
        airplane.y = airplane.startRow;
        allTiles[airplane.x,airplane.y].GetComponent<Renderer>().material = AirplaneColor;
        //delivery depot is in bottommost right corner
        allTiles[depot.x, depot.y].GetComponent<Renderer>().material = Depot;
        //train starts in lower left
        train.x = train.startCol;
        train.y = train.startRow;
        allTiles[train.x, train.y].GetComponent<Renderer>().material = TrainColor;
        //boat starts in upper right
        boat.x = boat.startCol;
        boat.y = boat.startRow;
        allTiles[boat.x, boat.y].GetComponent<Renderer>().material = BoatColor; 
    }

	// Update is called once per frame
	void Update () {
        airplane.OnKeyDown();
        //game should be checking once per frame for directionToTravel
        //to make sure it has the most recent keypress
        keepDepotColoredCorrectly();
        //game should be continuously making sure the depot is correctly colored
        if (Time.time >= turnStart)
        {
            print("it is turn" + turnNum);
            //updateScoreText();
            addPoints();
            airplane.addCargo();
            train.addCargo();
            boat.addCargo();
            print("Airplane is holding" + airplane.currentCargo);
            print("Train is holding" + train.currentCargo);
            print("Boat is holding" + boat.currentCargo);
            if (turnNum % airplane.turnSpeed==0)
            {
                moveAirplane();
            }
            if (turnNum % train.turnSpeed == 0)
            {
                moveTrain();
            }
            if (turnNum % boat.turnSpeed == 0)
            {
                moveBoat();
            }
            keepVehiclesColoredCorrectly();
            turnStart += turnLength;
            turnNum++;
        }
        
	}
}