using UnityEngine;

namespace Race_game_project.IdHandlingManager
{
    public class IdHandler : MonoBehaviour, IIdHandler
    {
        System.Guid _id;
        private void Awake()
        {
            SetId();
        }
        public void SetId()
        {
            _id = System.Guid.NewGuid();
        }
        public System.Guid GetId()
        {
            return _id;
        }
    }
}