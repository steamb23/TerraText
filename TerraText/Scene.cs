using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText
{
    public abstract class Scene
    {
#nullable disable
        private readonly WeakReference<SceneManager> weakReferencedSceneManager = new WeakReference<SceneManager>(null);
#nullable enable
        public SceneManager? SceneManager => weakReferencedSceneManager.TryGetTarget(out var sceneManager) ? sceneManager : null;
        internal void SetSceneManager(SceneManager? sceneManager) => weakReferencedSceneManager.SetTarget(sceneManager);
        public abstract void Execute();
    }
}
