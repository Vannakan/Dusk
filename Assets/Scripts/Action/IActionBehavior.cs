using System;
using UnityEngine;

namespace Assets.Scripts
{
    //These should start themselves as disabled on startup
    public interface IActionBehavior
    {
        event EventHandler ActionCompleted;

        bool IsActive { set; }
    }
}
