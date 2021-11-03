using System.Threading.Tasks;
using Common;
using Contexts.UI.View;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ResourceManagement
{
    public class LoadSceneCommand : ICommand
    {
        private readonly string _sceneName;

        public LoadSceneCommand(string sceneName)
        {
            _sceneName = sceneName;
        }
        
        public async void Execute()
        {
            UIPanelsContainerView.Instance.ShowPanel(UIPanelType.LoadingPanel);
            var asyncOperation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
            while (!asyncOperation.isDone)
            {
                var loadingPanelData = new LoadingPanelData(asyncOperation.progress);
                UIPanelsContainerView.Instance.UpdatePanel(UIPanelType.LoadingPanel, loadingPanelData);   
                await Task.Yield();
            }
            UIPanelsContainerView.Instance.HidePanel(UIPanelType.LoadingPanel);
        }
    }
}