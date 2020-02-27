using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText
{
    /// <summary>
    /// 텍스트 게임의 장면을 나타냅니다.
    /// </summary>
    public abstract class Scene
    {
#nullable disable
        private readonly WeakReference<SceneManager> weakReferencedSceneManager = new WeakReference<SceneManager>(null);
#nullable enable
        /// <summary>
        /// 현재 이 장면을 관리하고 있는 장면 관리자를 가져옵니다.
        /// </summary>
        public SceneManager? SceneManager => weakReferencedSceneManager.TryGetTarget(out var sceneManager) ? sceneManager : null;

        internal void SetSceneManager(SceneManager? sceneManager) => weakReferencedSceneManager.SetTarget(sceneManager);

        /// <summary>
        /// 장면을 실행합니다.
        /// </summary>
        public abstract void Execute();
    }
}
