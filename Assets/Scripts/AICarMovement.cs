using Race_game_project.AIPathFinderManager;
using Racing_game_project.AIInputManager;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class AICarMovement : MonoBehaviour
    {
        [SerializeField]
        GameObject firstHalfGrid;
        [SerializeField]
        GameObject secondHalfGrid;
        public static bool isSecondHalf; 
        IAIShortestPathFinder _aiPathFinder;
        IAIInputManager _aiInputManager;
        void Awake()
        {
            _aiPathFinder = this.gameObject.GetComponent<AIShortestPathFinder>();
            _aiInputManager = this.gameObject.GetComponent<AIInputManager>();
            SetPathFromStart();
        }

        void Update()
        {
            _aiInputManager.ManageAIInputData();
        }
        public void SetPathFromStart()
        {
            isSecondHalf = false;
            _aiPathFinder.FindShortestPath(firstHalfGrid, 0f, true);
        }
        public void SetPathFromHalf()
        {
            isSecondHalf = true;
            _aiPathFinder.FindShortestPath(secondHalfGrid, 0f, true);
        }
    }
}