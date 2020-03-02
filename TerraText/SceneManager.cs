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
            sceneStack.Push(rootScene);

            while (true)
            {
                var currentScene = sceneStack.Peek();
                currentScene.SetSceneManager(this);
                currentScene.Execute();
                if (isReservedExit)
                    break;
                if (reservedScene != null)
                {
                    switch (reserveSceneMode)
                    {
                        case ReserveSceneMode.Child:
                            sceneStack.Push(reservedScene);
                            reservedScene = null;
                            break;
                        case ReserveSceneMode.Change:
                            currentScene = sceneStack.Pop();
                            currentScene.SetSceneManager(null);
                            sceneStack.Push(reservedScene);
                            reservedScene = null;
                            break;
                    }
                }
                else
                {
                    // Root Scene이 아니면 Pop
                    sceneStack.Pop();
                }
            }
            Debug.WriteLine("종료 명령이 수신되어 SceneManager.Run 종료됨.");

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
            isReservedExit = true;
        }

        /// <summary>
        /// 자식 장면을 예약합니다. 자식 장면이 종료되면 부모 장면을 다시 실행합니다.
        /// </summary>
        /// <param name="scene">예약할 장면입니다.</param>
        public void ReserveChildScene(Scene scene)
        {
            reserveSceneMode = ReserveSceneMode.Child;
            reservedScene = scene;
        }

        /// <summary>
        /// 장면 변경을 예약합니다. 현재 장면이 종료되면 예약된 장면이 실행됩니다.
        /// </summary>
        /// <param name="scene">예약할 장면입니다.</param>
        public void ReserveSceneChange(Scene scene)
        {
            reserveSceneMode = ReserveSceneMode.Change;
            reservedScene = scene;
        }
    }
}
