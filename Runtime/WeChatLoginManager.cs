// GameFrameX 组织下的以及组织衍生的项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
// 
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE 文件。
// 
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;
using System.Collections;
using cn.sharesdk.unity3d;
using GameFrameX.Event.Runtime;
using GameFrameX.Runtime;
using GameFrameX.ShareSdk.Runtime;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameFrameX.Login.WeChat.Runtime
{
    [UnityEngine.Scripting.Preserve]
    public sealed class WeChatLoginManager : GameFrameworkModule, IWeChatLoginManager
    {
        [UnityEngine.Scripting.Preserve]
        public WeChatLoginManager()
        {
        }

        private EventComponent _eventComponent;
        private ShareSDK _shareSDK;

        [UnityEngine.Scripting.Preserve]
        public void Init(string appId, string appKey)
        {
            _eventComponent = GameEntry.GetComponent<EventComponent>();
            _eventComponent.CheckSubscribe(AuthEventArgs.EventId, OnAuthEventArgs);
            _shareSDK = Object.FindObjectOfType<ShareSDK>();
            _shareSDK.devInfo.wechat.AppId = appId;
            _shareSDK.devInfo.wechat.AppSecret = appKey;

            _shareSDK.devInfo.wechatFavorites.AppId = appId;
            _shareSDK.devInfo.wechatFavorites.AppSecret = appKey;

            _shareSDK.devInfo.wechatMoments.AppId = appId;
            _shareSDK.devInfo.wechatMoments.AppSecret = appKey;
        }

        private void OnAuthEventArgs(object sender, GameEventArgs e)
        {
            if (e is AuthEventArgs eventArgs)
            {
                if (eventArgs.Type != PlatformType.WeChat)
                {
                    return;
                }

                if (eventArgs.State == ResponseState.Success)
                {
                    var weChatLoginSuccess = new WeChatLoginSuccess();
                    if (eventArgs.Data.ContainsKey("nickname"))
                    {
                        weChatLoginSuccess.NickName = eventArgs.Data["nickname"].ToString();
                    }

                    if (eventArgs.Data.ContainsKey("unionid"))
                    {
                        weChatLoginSuccess.UnionId = eventArgs.Data["unionid"].ToString();
                    }

                    if (eventArgs.Data.ContainsKey("openid"))
                    {
                        weChatLoginSuccess.OpenId = eventArgs.Data["openid"].ToString();
                    }

                    if (eventArgs.Data.ContainsKey("headimgurl"))
                    {
                        weChatLoginSuccess.PhotoUrl = eventArgs.Data["headimgurl"].ToString();
                    }

                    _loginSuccess.Invoke(weChatLoginSuccess);
                }
                else
                {
                    _loginFail.Invoke((int)eventArgs.State);
                }
            }
        }

        private Action<WeChatLoginSuccess> _loginSuccess;
        private Action<int> _loginFail;

        [UnityEngine.Scripting.Preserve]
        public void Login(Action<WeChatLoginSuccess> loginSuccess, Action<int> loginFail)
        {
            _loginSuccess = loginSuccess;
            _loginFail = loginFail;
            _shareSDK.Authorize(PlatformType.WeChat);
        }

        [UnityEngine.Scripting.Preserve]
        public void LogOut()
        {
            _shareSDK.CancelAuthorize(PlatformType.WeChat);
        }

        protected override void Update(float elapseSeconds, float realElapseSeconds)
        {
        }

        protected override void Shutdown()
        {
        }
    }
}