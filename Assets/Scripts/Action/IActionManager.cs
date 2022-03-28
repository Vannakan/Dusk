using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface IActionManager
    {
        void Update();
        void AddActionBehaviour(IActionBehavior actionBehavior);
        //void RemoveActionBehaviour(int Id);
    }
}
