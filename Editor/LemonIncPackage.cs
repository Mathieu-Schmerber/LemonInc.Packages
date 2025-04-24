using System;

namespace LemonInc.Tools.Packager.Editor
{
    public class LemonIncPackage
    {
        public string BranchName { get; set; }
        public string Scope { get; set; }
        public string Feature { get; set; }
        public string FullName => BranchName.ToLemonIncPackageName();
        public bool Installed { get; set; }

        private bool _selected;
        public bool Selected
        {
            get => _selected;
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    OnSelectionChanged?.Invoke();
                }
            }
        }

        public event Action OnSelectionChanged;
    }
}