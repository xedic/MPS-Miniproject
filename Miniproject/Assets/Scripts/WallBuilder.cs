using UnityEngine;
using System.Collections;

public class WallBuilder : MonoBehaviour {
    public string ParentName = "Bricks";
    private GameObject _parent = null;
    public int Width = 10;
    public int Height = 10;
    public int Depth = 1;
    public void OnDrawGizmos(){
        Gizmos.color = new Color(1, 0, 0, 1);
        Gizmos.matrix = gameObject.transform.localToWorldMatrix;
        Gizmos.DrawCube(Vector3.zero, new Vector3(Width * 2, Height * 2, Depth));
    }
    void Start () {
        ResetWall();
    }
    public void ResetWall(){
        DestroyParent();
        PlaceBricks(Width, Height, Depth);
        PlaceStabilizers(Width, Height, Depth);
        GetParent().transform.rotation = gameObject.transform.rotation;
        GetParent().transform.Rotate(Vector3.up, 90);
    }
    public void Update(){
        if(Input.GetKey(KeyCode.A)){
            ResetWall();
        }
    }
    private void PlaceStabilizers(int width, int height, int depth){
        if((height % 2 != 0)){
             height++;
        }
        for(int y = 1; y < height; y += 2){
            PlaceStabilizerAt(-0.5f - depth / 2.0f, y, (width - 0.5f) * 1);
            PlaceStabilizerAt(-0.5f - depth / 2.0f, y, (width - 0.5f) * -1);
            PlaceStabilizerAt(depth / 2.0f + 0.5f, y, (width - 0.5f) * 1);
            PlaceStabilizerAt(depth / 2.0f + 0.5f, y, (width - 0.5f) * -1);
        }
    }
    private void PlaceBricks(int width, int height, int depth){
        if((height % 2 != 0)){
             height++;
        }
        Object brickPrefabRef = Resources.Load("Prefabs/Brick");
        for(int x = 0; x < depth; x++){
            for(int y = 0; y < height; y++){
                for(int z = 0; z < width; z++){
                    if((y % 2) == 1 && z == width - 1){
                        break;
                    }
                    GameObject g = (GameObject)GameObject.Instantiate(brickPrefabRef);
                    g.transform.parent = GetParent().transform;
                    g.transform.position = GetParent().transform.position;
                    Vector3 pos = g.transform.position;
                    pos.z += z * 2 + 1 * (y % 2) - width + 1;
                    pos.y += y + 0.5f;
                    pos.x += -depth / 2.0f + x + 0.5f;
                    g.transform.position = pos;
                    g.name = "Brick";
                }
            }
        }
    }
    private void PlaceStabilizerAt(float x, float y, float z){
        GameObject stabilizer = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Stabilizer"));
        stabilizer.transform.parent = GetParent().transform;
        stabilizer.transform.position = GetParent().transform.position;
        stabilizer.name = "Stabilizer";
        Vector3 pos = stabilizer.transform.position;
        pos.z += z;
        pos.x += x;
        pos.y += y;
        stabilizer.transform.position = pos;
    }

    private void DestroyParent(){
        if(_parent != null){
            GameObject.Destroy(_parent);
        }
        _parent = null;
    }
    private GameObject GetParent(){
        if(_parent == null){
            _parent = new GameObject();
            _parent.name = gameObject.name + "_bricks";
            Vector3 pos = _parent.transform.position;
            pos.x = 0;
            pos.y = 0;
            pos.z = 0;
            _parent.transform.position = gameObject.transform.position;
        }
        return _parent;
    }

    private void SpawnPlane(int length, int depth){
        GameObject plane = (GameObject)GameObject.CreatePrimitive(PrimitiveType.Quad);
        plane.transform.Rotate(Vector3.right, 90);
        Vector3 scale = plane.transform.localScale;
        scale.y *= length;
        scale.x *= depth;
        plane.transform.localScale = scale;
        plane.transform.parent = GetParent().transform;
        plane.transform.position = GetParent().transform.position;
        Vector3 pos = plane.transform.position;
        //pos.z += length / 2.0f;
        pos.x += depth / 2.0f - 0.5f;
        plane.transform.position = pos;
        plane.name = "BrickGround";
        plane.transform.parent = GetParent().transform;
    }
}
