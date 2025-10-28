// GameFrameX 组织下的以及组织衍生的项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
// 
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE 文件。
// 
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.Login.WeChat.Runtime
{
    /// <summary>
    /// WeChat 登录组件。
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(GameFrameXWeChatLoginCroppingHelper))]
    [AddComponentMenu("Game Framework/WeChat Login")]
    [UnityEngine.Scripting.Preserve]
    public class WeChatLoginComponent : GameFrameworkComponent
    {
        private IWeChatLoginManager _weChatLoginManager = null;

        /// <summary>
        ///   App Id
        /// </summary>
        [SerializeField] private string m_AppId = string.Empty;

        [SerializeField] private string m_AppKey = string.Empty;

        /// <summary>
        /// 游戏框架组件初始化。
        /// </summary>
        protected override void Awake()
        {
            ImplementationComponentType = Utility.Assembly.GetType(componentType);
            InterfaceComponentType = typeof(IWeChatLoginManager);
            base.Awake();

            _weChatLoginManager = GameFrameworkEntry.GetModule<IWeChatLoginManager>();
            if (_weChatLoginManager == null)
            {
                Log.Fatal("we chat manager is invalid.");
                return;
            }
        }

        [UnityEngine.Scripting.Preserve]
        public void Init()
        {
            _weChatLoginManager.Init(m_AppId, m_AppKey);
        }

        [UnityEngine.Scripting.Preserve]
        public void Login(Action<WeChatLoginSuccess> loginSuccess, Action<int> loginFail)
        {
            _weChatLoginManager.Login(loginSuccess, loginFail);
        }

        [UnityEngine.Scripting.Preserve]
        public void LogOut()
        {
            _weChatLoginManager.LogOut();
        }
    }
}