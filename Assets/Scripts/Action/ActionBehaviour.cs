using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts
{
    public abstract class ActionBehaviour : MonoBehaviour, IActionBehavior
    {
        public event EventHandler ActionCompleted;
        public event EventHandler OnDestroyCalled;

        public Tilemap Map;

        public bool IsActive
        {
            set
            {
                enabled = value;
            }
        }

        public void OnActionCompleted()
        {
            ActionCompleted?.Invoke(this, new EventArgs());
        }

        private void OnDestroy()
        {
            OnDestroyCalled?.Invoke(this, new EventArgs());
        }

    }
}
