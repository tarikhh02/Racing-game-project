using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.FinishedMenuFiller
{
    public interface IFinishMenuUIFiller
    {
        public void FillFinishMenuUI(List<KeyValuePair<System.Guid, string>> legendBoard);
    }
}