using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

    private WallBuilder wall;

    void Start()
    {
        wall = GetComponent<WallBuilder>();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Comma))
        {
            wall.type = WallBuilder.BrickType.BRICK;
            wall.ResetWall();
        }
        else if (Input.GetKey(KeyCode.Period))
        {
            wall.type = WallBuilder.BrickType.STEEL;
            wall.ResetWall();
        }
	}
}
