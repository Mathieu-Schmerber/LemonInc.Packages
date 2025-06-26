using System;
using LemonInc.Core.Utilities.Ui.Menu;

namespace LemonInc.Test.MenuDemo
{
    public class SimpleMenu : MenuUi
    {
        public override bool IsBlocking => true;

        private void Start()
        {
            Invoke(nameof(HideMenu), 2);
            Invoke(nameof(ShowMenu), 5);
            Invoke(nameof(HideMenu), 8);
        }
    }
}
