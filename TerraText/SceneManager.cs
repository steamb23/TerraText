using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TerraText
{
    /// <summary>
    /// 게임 장면의 관리자를 나타냅니다.
    /// </summary>
    public sealed class SceneManager
    {
        private readonly Stack<Scene> sceneStack = new Stack<Scene>();
        //private Scene? rootScene = null;
        private enum ReserveSceneMode
        {
            None,
            Child,
            Change
        }
        private Scene? reservedScene;
        private ReserveSceneMode reserveSceneMode;

        private bool isReservedExit;

        /// <summary>
        /// 게임 장면 관리의 실행 여부를 나타내는 값을 가져옵니다. 실행 중이면 true입니다.
        /// </summary>
        public bool IsRun
        {
            get => CurrentSceneDepth >= 0;
        }

        /// <summary>
        /// 현재 실행 중인 장면의 계층 깊이를 가져옵니다. 계층 깊이는 0부터 시작하며 실행 중이 아닌 경우 -1을 반환합니다.
        /// </summary>
        public int CurrentSceneDepth
        {
            get => sceneStack.Count - 1;
        }

        /// <summary>
        /// 게임 장면 관리를 실행합니다.
        /// </summary>
        /// <param name="rootScene"></param>
        public void Run(Scene rootScene)
        {
            // 최상위 장면 추가
            Log.Debug($"{nameof(SceneManager)} - 루트 장면 준비... {rootScene.GetType()}");
            sceneStack.Push(rootScene);
            Log.Debug($"{nameof(SceneManager)} - 장면 깊이: {CurrentSceneDepth}");

            while (true)
            {
                var currentScene = sceneStack.Peek();
                currentScene.SetSceneManager(this);
                Log.Info($"{nameof(SceneManager)} - 장면 실행... {currentScene.GetType()}");
                //Log.Info("");
                currentScene.Execute();
                Log.Debug($"{nameof(SceneManager)} - 장면 종료");
                if (isReservedExit)
                    break;
                if (reservedScene != null)
                {
                    switch (reserveSceneMode)
                    {
                        case ReserveSceneMode.Child:
                            Log.Debug($"{nameof(SceneManager)} - 자식 장면 준비... {reservedScene.GetType()}");
                            sceneStack.Push(reservedScene);
                            reservedScene = null;
                            Log.Debug($"{nameof(SceneManager)} - 장면 깊이: {CurrentSceneDepth}");
                            break;
                        case ReserveSceneMode.Change:
                            Log.Debug($"{nameof(SceneManager)} - 장면 변경 준비... {reservedScene.GetType()}");
                            currentScene = sceneStack.Pop();
                            currentScene.SetSceneManager(null);
                            sceneStack.Push(reservedScene);
                            reservedScene = null;
                            Log.Debug($"{nameof(SceneManager)} - 장면 깊이: {CurrentSceneDepth}");
                            break;
                    }
                }
                else if (CurrentSceneDepth > 0)
                {
                    // Root Scene이 아니면 Pop
                    Log.Debug($"{nameof(SceneManager)} - 부모 장면 준비...");
                    sceneStack.Pop();
                    Log.Debug($"{nameof(SceneManager)} - 장면 깊이: {CurrentSceneDepth}");
                }
            }
            Log.Debug($"{nameof(SceneManager)} - 종료");
            Log.Debug("");

            // 객체 재사용을 위한 종료 절차
            sceneStack.Clear();
            reservedScene = null;
            isReservedExit = false;
        }

        /// <summary>
        /// 게임 장면 관리 종료를 예약합니다.
        /// </summary>
        public void ReserveExit()
        {
            Log.Debug($"{nameof(SceneManager)} - 종료 예약...");
            isReservedExit = true;
        }

        /// <summary>
        /// 자식 장면을 예약합니다. 자식 장면이 종료되면 부모 장면을 다시 실행합니다.
        /// </summary>
        /// <param name="scene">예약할 장면입니다.</param>
        public void ReserveChildScene(Scene scene)
        {
            Log.Debug($"{nameof(SceneManager)} - 자식 장면 예약... {scene.GetType()}");
            reserveSceneMode = ReserveSceneMode.Child;
            reservedScene = scene;
        }

        /// <summary>
        /// 장면 변경을 예약합니다. 현재 장면이 종료되면 예약된 장면이 실행됩니다.
        /// </summary>
        /// <param name="scene">예약할 장면입니다.</param>
        public void ReserveSceneChange(Scene scene)
        {
            Log.Debug($"{nameof(SceneManager)} - 장면 변경 예약... {scene.GetType()}");
            reserveSceneMode = ReserveSceneMode.Change;
            reservedScene = scene;
        }
    }
}
