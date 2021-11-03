using System.Collections;
using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Contexts.UI.View
{
    public class LoadingPanelView : UIPanelView<LoadingPanelData>
    {
        [SerializeField] private Image _progressBar;

        public override UIPanelType Type => UIPanelType.LoadingPanel;

        protected override void UpdateView(LoadingPanelData data)
        {
            _progressBar.fillAmount = data.LoadingProgress;
        }
    }

    public class LoadingPanelData : UIPanelData
    {
        public float LoadingProgress { get; }

        public LoadingPanelData(float loadingProgress)
        {
            LoadingProgress = loadingProgress;
        }
    }
}