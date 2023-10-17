using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Scripts.GridCellManager;
using Race_game_project.CellUnwalkableMaker;
using System.Collections.Generic;
using System.Linq;

namespace Racing_game_project.CellMarkerManager
{
    [ExecuteInEditMode]
    public class CellUnwalkableMarker : MonoBehaviour, ICellUnwalkableMarker
    {
        RaycastHit frontRightHit;
        RaycastHit frontLeftHit;
        RaycastHit backRightHit;
        RaycastHit backLeftHit;
        public void MarkCellAsUnwalkabe(ref List<List<IGridCell>> grid)
        {
            for (int y = 0; y < grid.Count; y++)
            {
                for (int x = 0; x < grid[y].Count; x++)
                {
                    Vector3 frontPositionVector = new Vector3
                    {
                        x = this.transform.position.x + grid[y][x].GetGameObject().transform.localScale.x / 2 + grid[y][x].GetGameObject().transform.localScale.x * x + this.transform.forward.x * grid[y][x].GetGameObject().transform.localScale.x / 2,
                        y = - grid[y][x].GetGameObject().transform.localScale.y - 0.001f,
                        z = this.transform.position.z + grid[y][x].GetGameObject().transform.localScale.x / 2 + grid[y][x].GetGameObject().transform.localScale.x * y + this.transform.forward.z * grid[y][x].GetGameObject().transform.localScale.x / 2,
                    };
                    Vector3 backPositionVector = new Vector3
                    {
                        x = this.transform.position.x + grid[y][x].GetGameObject().transform.localScale.x / 2 + grid[y][x].GetGameObject().transform.localScale.x * x - this.transform.forward.x * grid[y][x].GetGameObject().transform.localScale.x / 2,
                        y = - grid[y][x].GetGameObject().transform.localScale.y - 0.001f,
                        z = this.transform.position.z + grid[y][x].GetGameObject().transform.localScale.x / 2 + grid[y][x].GetGameObject().transform.localScale.x * y - this.transform.forward.z * grid[y][x].GetGameObject().transform.localScale.x / 2,
                    };
                    List<Collider[]> colliderList = new List<Collider[]>()
                    { 
                        Physics.OverlapBox(frontPositionVector + this.transform.right * grid[y][x].GetGameObject().transform.localScale.x / 2, new Vector3(0.001f, 0.3f, 0.001f))
                        .Where(c => c.gameObject.tag != "GridCell" && c.gameObject.tag != "Unwalkable" && c.gameObject.tag != "AlternativePathDirectioning").ToArray(),
                        Physics.OverlapBox(frontPositionVector - this.transform.right * grid[y][x].GetGameObject().transform.localScale.x / 2, new Vector3(0.001f, 0.3f, 0.001f))
                        .Where(c => c.gameObject.tag != "GridCell" && c.gameObject.tag != "Unwalkable" && c.gameObject.tag != "AlternativePathDirectioning").ToArray(),
                        Physics.OverlapBox(backPositionVector + this.transform.right * grid[y][x].GetGameObject().transform.localScale.x / 2, new Vector3(0.001f, 0.3f, 0.001f))
                        .Where(c => c.gameObject.tag != "GridCell" && c.gameObject.tag != "Unwalkable" && c.gameObject.tag != "AlternativePathDirectioning").ToArray(),
                        Physics.OverlapBox(backPositionVector - this.transform.right * grid[y][x].GetGameObject().transform.localScale.x / 2, new Vector3(0.001f, 0.3f, 0.001f))
                        .Where(c => c.gameObject.tag != "GridCell" && c.gameObject.tag != "Unwalkable" && c.gameObject.tag != "AlternativePathDirectioning").ToArray()
                    };  
                    foreach (Collider[] colliders in colliderList)
                    {
                        if(colliders.Length > 0)
                        {
                            foreach (Collider collider in colliders)
                            {
                                //implement obsticles, area of track with bigger increment value
                                if(collider.gameObject.tag == "Obsticle")
                                {
                                    grid[y][x].SetCost(60000);
                                    grid[y][x].GetGameObject().tag = "Unwalkable";
                                }
                            }
                        }
                        else
                        {
                            grid[y][x].SetCost(60000);
                            grid[y][x].GetGameObject().tag = "Unwalkable";
                        }
                    }
                }
            }
        }
    }
}