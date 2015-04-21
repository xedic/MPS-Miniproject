using UnityEngine;
using System.Collections;

public class WallBuilder : MonoBehaviour {
    private const string _parentName = "Bricks";
    private GameObject _parent = null;
    public int Width = 10;
    public int Height = 10;
    public int Depth = 1;
    void Start () {
        PlaceBricks(Width, Height, Depth);
    }

    private void PlaceBricks(int width, int height, int depth){
        if((height % 2 != 0)){
             height++;
        }
        SpawnPlane(width * 2, depth);
        Object brickPrefabRef = Resources.Load("Prefabs/Brick");
        for(int x = 0; x < depth; x++){
            for(int y = 0; y < height; y++){
                for(int z = 0; z < width; z++){
                    if((y % 2) == 1 && z == width - 1){
                        break;
                    }
                    GameObject g = (GameObject)GameObject.Instantiate(brickPrefabRef);
                    g.transform.position = GetParent().transform.position;
                    Vector3 pos = g.transform.position;
                    pos.z += z * 2 + 1 * (y % 2);
                    pos.y += y + 0.5f;
                    pos.x += x;
                    g.transform.position = pos;
                    g.transform.parent = GetParent().transform;
                    g.name = "Brick";
                }
            }
        }
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
            _parent.name = _parentName;
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
        pos.z += length / 2.0f - 1;
        pos.x += depth / 2.0f - 0.5f;
        plane.transform.position = pos;
        plane.name = "BrickGround";
        plane.transform.parent = GetParent().transform;
    }
}
