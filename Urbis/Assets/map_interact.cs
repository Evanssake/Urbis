using UnityEngine;
using System.Collections;

public class map_interact : MonoBehaviour {

    private bool controller1Selectable = false;
    private bool controller2Selectable = false;

    public bool controller1Gripped = false;
    public bool controller2Gripped = false;


    // Use this for initialization
    void Start () {
        
	
	}

    // Update is called once per frame
	void Update () {
        
        if (checkControllerClose(GameObject.Find("Controller (left)").transform))
        {
            controller1Selectable = true;
        }

        if (checkControllerClose(GameObject.Find("Controller (right)").transform))
        {
            controller2Selectable = true;
        }

        if (controller1Gripped && controller2Gripped)
        {
            //Can zoom if controllers moved.
        }

        if (controller1Gripped || controller2Gripped)
        {
            if (controller1Gripped)
            {
                //follow controller movement on controller1
            } else
            {
                //follow controller movement on controller2
            }
        }
        

    }

    bool checkControllerClose(Transform controller){

        return (controller.position.z % this.transform.position.z < 2);
    }

    public bool GetLeftControllerSelectable()
    {
        return this.controller1Selectable;
    }

    public bool GetRightControllerSelectable()
    {
        return this.controller2Selectable;
    }
}
