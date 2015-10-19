using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

	public GameObject squareTile;
    public GameObject[] allTiles;
    public Material On;
    public Material Off;
    int numTiles = 16;

    public void ProcessClickedTile(GameObject clickedTile)
    {
        foreach (GameObject oneTile in allTiles)
        {
            oneTile.GetComponent<Renderer>().material = Off;
        }

        clickedTile.GetComponent<Renderer>().material = On;
        print("you clicked something");

    }

    // Use this for initialization
    void Start () {
        allTiles = new GameObject[numTiles];
        for (int i = 0; i < numTiles; i++)
        {
            allTiles[i] = (GameObject)Instantiate(squareTile, new Vector3(i * 2 - 14, 0, 10), Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
