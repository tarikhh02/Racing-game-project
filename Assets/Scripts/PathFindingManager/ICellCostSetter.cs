using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PathFindingManager
{
    public interface ICellCostSetter
    {
        public void SetCellCosts();
    }
}