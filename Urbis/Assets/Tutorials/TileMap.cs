using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class TileMap : MonoBehaviour {
    public int width_x = 100;
    public int height_z = 50;
    int depth_y;
    public float tileSize = 1.0f;

	// Use this for initialization
	void Start () {
        BuildMesh();
	}

    void BuildMesh()
    {
        int numTiles = width_x * height_z;
        int vwidth_x = width_x + 1;
        int vheight_z = height_z + 1;
        int numVerts = vwidth_x * vheight_z;
        int numTris = numTiles * 2;

        // Generate the mesh data
        Vector3[] vertices = new Vector3[numVerts];
        int[] triangles = new int[numTris*3];
        Vector3[] normals = new Vector3[numVerts];
        Vector2[] uv = new Vector2[numVerts];

       int x, z;
       for(z=0; z<height_z; z++)
        {
            for(x=0; x<width_x; x++)
            {
                vertices[z * vwidth_x + x] = new Vector3(x*tileSize, 0, z*tileSize);
                normals[z * vwidth_x + x] = Vector3.up;
                uv[z * vwidth_x + x] = new Vector2((float)x / vwidth_x, (float)z / vheight_z);

            }
        }

        for(z=0; z < height_z; z++)
        {
            for(x=0; x < width_x; x++)
            {
                int squareIndex = z * width_x + x;
                int triOffset = squareIndex * 6;
                triangles[triOffset + 0] = z * vwidth_x + x +            0;
                triangles[triOffset + 1] = z * vwidth_x + x + vwidth_x + 0;
                triangles[triOffset + 2] = z * vwidth_x + x + vwidth_x + 1;

                triangles[triOffset + 3] = z * vwidth_x + x +            0;
                triangles[triOffset + 4] = z * vwidth_x + x + vwidth_x + 1;
                triangles[triOffset + 5] = z * vwidth_x + x +            1;
            }
        }
        
        // Create a new mesh and populate
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        // Assign mesh to filter/renderer/collider
        MeshFilter mesh_filter = GetComponent<MeshFilter>();
        MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
        MeshCollider mesh_collider = GetComponent<MeshCollider>();

        mesh_filter.mesh = mesh;
    }
}
