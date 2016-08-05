using UnityEngine;
using System.Collections;

public class ControllerInteraction : MonoBehaviour {

    bool planeSelectable;
    bool planeGripped;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        GameObject plane = GameObject.Find("Plane");
        

        
        if(this.name.Equals("Controller (left)"))
        {
            planeSelectable = plane.GetComponentInChildren<map_interact>().GetLeftControllerSelectable();
        } else
        {
            planeSelectable = plane.GetComponentInChildren<map_interact>().GetRightControllerSelectable();
        }

        if (this.GetComponentInChildren<SteamVR_TrackedController>().gripped && planeSelectable)
        {
            planeGripped = true;

            if (this.name.Equals("Controller (left)"))
            {
                plane.GetComponentInChildren<map_interact>().controller1Gripped = true;
            }
            else
            {
                plane.GetComponentInChildren<map_interact>().controller1Gripped = false;
            }
        }

        
       
    }
}
