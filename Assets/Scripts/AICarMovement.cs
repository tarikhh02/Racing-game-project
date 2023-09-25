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
        IAIShortestPathFinder _aiPathFinder;
        IAIInputManager _aiInputManager;
        void Awake()
        {
            _aiPathFinder = this.gameObject.GetComponent<AIShortestPathFinder>();
            _aiInputManager = this.gameObject.GetComponent<AIInputManager>();
            _aiPathFinder.FindShortestPath(firstHalfGrid, 0f);
        }

        void Update()
        {
            //_aiInputManager.ManageAIInputData();
        }
    }
}