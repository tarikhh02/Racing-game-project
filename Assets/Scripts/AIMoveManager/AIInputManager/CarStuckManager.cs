using Assets.Scripts.GridCellManager;
using Race_game_project.AIBackwardsGoingManagement;
using Race_game_project.AICarMovement;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.ManagerIfCarIsStuck
{
    public class CarStuckManager : MonoBehaviour, ICarStuckManager
    {
        Vector3 _lastCarPosition = Vector3.zero;
        IAIGoingBackwardsManager _backwardsGoingManager;
        private void Awake()
        {
            _backwardsGoingManager = this.gameObject.GetComponent<AIGoingBackwardsManager>();
        }
        public void ManageCarIfStuck(ref List<IGridCell> listOfVisibleToCell, ref float timer, ref bool canInitializePath, ref bool isStuck, ref float forwardDirection, ref int sideDirection, IAICarMovement aiCarMovement)
        {
            Vector3 frontPosition = this.transform.position + Vector3.up * 0.2f;
            listOfVisibleToCell.Add(GetCellsWithCarSignature(frontPosition));
            listOfVisibleToCell.Add(GetCellsWithCarSignature(frontPosition + this.transform.right * 0.25f));
            listOfVisibleToCell.Add(GetCellsWithCarSignature(frontPosition - this.transform.right * 0.25f));
            if (timer == 5 || isStuck)
            {
                timer = 0;
                if (Vector3.Distance(this.transform.position, _lastCarPosition) <= 2f)
                {
                    isStuck = true;
                    _backwardsGoingManager.GoBackwards(ref canInitializePath, ref forwardDirection, ref sideDirection, aiCarMovement);
                }
                else
                {
                    isStuck = false;
                    _lastCarPosition = this.transform.position;
                }
            }
        }
        private IGridCell GetCellsWithCarSignature(Vector3 position)
        {
            RaycastHit hit;
            if (Physics.Raycast(position, -this.transform.up, out hit, 0.5f))
            {
                if (hit.collider.CompareTag("GridCell"))
                {
                    return hit.collider.GetComponent<GridCell>();
                }
            }
            return null;
        }
    }
}