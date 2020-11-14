using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PathPlotter : MonoBehaviour
{
    public string mapName;
    public List<Vector3Int> gridPath;

    private Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        GameObject map = GameObject.Find(mapName);

        grid = map.GetComponentInChildren<Grid>();

        LineRenderer lr = GetComponent<LineRenderer>();

        Vector3[] path = new Vector3[lr.positionCount];

        lr.GetPositions(path);

        gridPath = new List<Vector3Int>();

        for (int i = 0; i < lr.positionCount; i++) {
            gridPath.Add(grid.WorldToCell(path[i]));
        }

        path = new Vector3[lr.positionCount];

        for (int i = 0; i < lr.positionCount; i++) {
            path[i] = grid.CellToWorld(gridPath[i]);
        }

        lr.SetPositions(path);
    }
}
