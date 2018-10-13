using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class Game_Master : MonoBehaviour
    {

        public delegate void GameManagerEventHandler();
        public event GameManagerEventHandler MenuToggleEvent;
        public event GameManagerEventHandler InventoryUIToggleEvent;
        public event GameManagerEventHandler RestartLevelEvent;
        public event GameManagerEventHandler GotoMenuSceneEvent;
        public event GameManagerEventHandler GameOverEvent;

        public bool isGmaeOver;
        public bool isInventoryUIOn;
        public bool isMenuOn;

        public void CallEventMenuToggle()
        {
            if (MenuToggleEvent != null)
            {
                MenuToggleEvent();
            }
        }

        public void CallEventInventoryUIToggle()
        {
            if (InventoryUIToggleEvent != null)
            {
                InventoryUIToggleEvent();
            }
        }

        public void CallEventRestartLevel()
        {
            if (RestartLevelEvent != null) 
            {
                RestartLevelEvent();
            }

        }

        public void CallEventMenuScene()
        {
            if (GotoMenuSceneEvent != null)
            {
                GotoMenuSceneEvent();
            }
        }

        public void CallEventGameOver()
        {
            if (GameOverEvent != null)
            {
                isGmaeOver = true;
                GameOverEvent();
            }
        }
    }
}