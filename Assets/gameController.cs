using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

	public GameObject squareTile;
    private GameObject[,] allTiles;
    public Material On;
    public Material Off;
    public Material Active;
    int numTilesInRow = 16;
    int numRowsofTiles = 9;
    public Airplane airplane;

    public void ProcessClickedTile(GameObject clickedTile, int x, int y)
    {
        //if player clicked unactive (red) airplane, it should activate
        if (x == airplane.x && y == airplane.y && airplane.active == false)
        {
            airplane.active = true;
            clickedTile.GetComponent<Renderer>().material = Active;
        }

        // If the player clicks an active (yellow) airplane, it should deactivate
        else if (x == airplane.x && y == airplane.y && airplane.active)
        {
            airplane.active = false;
            clickedTile.GetComponent<Renderer>().material = On;
        }

        // If the player clicks the sky and there isn’t an active airplane, 
        //   nothing happens.

        //player clicked on a new tile with an active airplane
        else if (airplane.active && (x != airplane.x || y != airplane.y))
        {// Set the old tile to white
            allTiles[airplane.x, airplane.y].GetComponent<Renderer>().material = Off;

            // Set the new cube to yellow (since the airplane is still active)
            allTiles[x, y].GetComponent<Renderer>().material = Active;

            // Update the airplane to be in the new location
            airplane.x = x;
            airplane.y = y;
        }
    }

    // Use this for initialization
    void Start () {
        airplane = new Airplane();
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
        airplane.x = 0;
        airplane.y = 8;
        allTiles[0, 8].GetComponent<Renderer>().material = On;
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
