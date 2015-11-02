using UnityEngine;
using System.Collections;

public class tileBehavior : MonoBehaviour {

    public bool clickedOn = false;
    public Material On;
    public Material Off;
    gameController aGameController;
    public int x, y;

    void OnMouseDown()
    {
        aGameController.ProcessClickedTile(this.gameObject, x, y);
    }

    //Use this for initialization
    void Start () {
        aGameController = GameObject.Find("GameControllerObject").GetComponent<gameController>();

    }

    // Update is called once per frame
    void Update () {

    }

    //original attempt w/o walkthrough; retain for contemplation later. 
    //    void OnMouseDown ()
    //    {
    // when player clicks on tile, it remembers whether it's the first or second time it's been clicked
    // causes multiple cubes to wind up red as each individual cube remembers its own bool
    //        if (clickedOn == false)
    //        {
    //            clickedOn = true;
    //            GetComponent<Renderer>().material = On;
    //        }
    //        else if (clickedOn == true)
    //        {
    //            clickedOn = false;
    //            GetComponent<Renderer>().material = Off;
    //        }
    //    }
}
