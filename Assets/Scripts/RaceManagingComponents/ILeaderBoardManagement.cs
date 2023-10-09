using Race_game_project.UIImplementationManager;
using System.Collections.Generic;

namespace Race_game_project.LeaderBoardManager
{
    public interface ILeaderBoardManagement
    {
        void ManageLeaderBoard(List<ManageUI> listOfAllCars);
    }
}