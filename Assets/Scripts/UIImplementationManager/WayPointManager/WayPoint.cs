using System.Collections;
using UnityEngine;

namespace Race_game_project.WayPointManager
{
    public class WayPoint : MonoBehaviour, IWayPoint
    {
        [SerializeField]
        GameObject _nextWayPoint;
        [SerializeField]
        int _waypointIndex;
        public GameObject GetNextWayPoint()
        {
            return _nextWayPoint;
        }
        public int GetWayPointIndex()
        {
            return _waypointIndex;
        }
    }
}