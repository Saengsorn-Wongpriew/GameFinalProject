using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class MeshParticleSystemZombie : MonoBehaviour
{
    [SerializeField] private PlayerAimShoot playerAimShoot;
    private const int MAX_QUAD_AMOUNT = 15000;
    private Mesh mesh;

    private int quadIndex;
    private Vector3[] vertices;
    private Vector2[] uv;
    private int[] triangles;

    private void Awake()
    {
        mesh = new Mesh();

        vertices = new Vector3[4 * MAX_QUAD_AMOUNT];
        uv = new Vector2[4 * MAX_QUAD_AMOUNT];
        triangles = new int[6 * MAX_QUAD_AMOUNT];

        AddQuad(new Vector3(0, 0));
        AddQuad(new Vector3(0, 5));

        playerAimShoot.OnShootRay += PlayerAimShoot_OnShootRay;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;

    }
    private void PlayerAimShoot_OnShootRay(object sender, PlayerAimShoot.OnShootEventArgs e)
    {
        int spawnedQuadIndex = AddQuad(e.gunEndPointPosition);
        
        Vector3 quadPosition = e.gunEndPointPosition;
        Vector3 quadSize = new Vector3(1f, 1f);
        float rotation = 0f;
        FunctionUpdater.Create(() => 
        {
            UpdateQuad(spawnedQuadIndex, quadPosition, rotation, quadSize, true);
        });
    }

    private int AddQuad(Vector3 position)
    {
        if (quadIndex >= MAX_QUAD_AMOUNT) return 0;// Mesh Full
        
        UpdateQuad(quadIndex, position, 0f, new Vector3(1f, 1f), true);

        int spawnedQuadIndex = quadIndex;
        quadIndex++;

        return spawnedQuadIndex;
    }

    public void UpdateQuad(int quadIndex, Vector3 position, float rotation, Vector3 quadSize, bool skewed)
    {
        //Relocate vertices
        int vIndex = quadIndex * 4;
        int vIndex0 = vIndex;
        int vIndex1 = vIndex + 1;
        int vIndex2 = vIndex + 2;
        int vIndex3 = vIndex + 3;

        vertices[vIndex0] = position + Quaternion.Euler(0, 0, rotation - 180) * quadSize;
        vertices[vIndex1] = position + Quaternion.Euler(0, 0, rotation - 270) * quadSize;
        vertices[vIndex2] = position + Quaternion.Euler(0, 0, rotation - 0) * quadSize;
        vertices[vIndex3] = position + Quaternion.Euler(0, 0, rotation - 90) * quadSize;

        uv[vIndex0] = new Vector2(0, 0);
        uv[vIndex0] = new Vector2(0, 1);
        uv[vIndex0] = new Vector2(1, 1);
        uv[vIndex0] = new Vector2(1, 0);


        //Create triangles
        int tIndex = quadIndex * 6;

        triangles[tIndex + 0] = vIndex0;
        triangles[tIndex + 1] = vIndex1;
        triangles[tIndex + 2] = vIndex2;

        triangles[tIndex + 3] = vIndex0;
        triangles[tIndex + 4] = vIndex2;
        triangles[tIndex + 5] = vIndex3;
        
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
}
