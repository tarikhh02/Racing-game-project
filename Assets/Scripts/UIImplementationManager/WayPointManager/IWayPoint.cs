using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Race_game_project.WayPointManager
{
    public interface IWayPoint
    {
        public GameObject GetNextWayPoint();
        public int GetWayPointIndex();
    }
}
