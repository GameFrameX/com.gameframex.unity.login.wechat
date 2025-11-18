// ==========================================================================================
//  GameFrameX 组织及其衍生项目的版权、商标、专利及其他相关权利
//  GameFrameX organization and its derivative projects' copyrights, trademarks, patents, and related rights
//  均受中华人民共和国及相关国际法律法规保护。
//  are protected by the laws of the People's Republic of China and relevant international regulations.
// 
//  使用本项目须严格遵守相应法律法规及开源许可证之规定。
//  Usage of this project must strictly comply with applicable laws, regulations, and open-source licenses.
// 
//  本项目采用 MIT 许可证与 Apache License 2.0 双许可证分发，
//  This project is dual-licensed under the MIT License and Apache License 2.0,
//  完整许可证文本请参见源代码根目录下的 LICENSE 文件。
//  please refer to the LICENSE file in the root directory of the source code for the full license text.
// 
//  禁止利用本项目实施任何危害国家安全、破坏社会秩序、
//  It is prohibited to use this project to engage in any activities that endanger national security, disrupt social order,
//  侵犯他人合法权益等法律法规所禁止的行为！
//  or infringe upon the legitimate rights and interests of others, as prohibited by laws and regulations!
//  因基于本项目二次开发所产生的一切法律纠纷与责任，
//  Any legal disputes and liabilities arising from secondary development based on this project
//  本项目组织与贡献者概不承担。
//  shall be borne solely by the developer; the project organization and contributors assume no responsibility.
// 
//  GitHub 仓库：https://github.com/GameFrameX
//  GitHub Repository: https://github.com/GameFrameX
//  Gitee  仓库：https://gitee.com/GameFrameX
//  Gitee Repository:  https://gitee.com/GameFrameX
//  官方文档：https://gameframex.doc.alianblank.com/
//  Official Documentation: https://gameframex.doc.alianblank.com/
// ==========================================================================================

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
        private bool _isInit;

        [UnityEngine.Scripting.Preserve]
        public void Init(string appId, string appKey)
        {
            if (_isInit)
            {
                return;
            }

            _eventComponent = GameEntry.GetComponent<EventComponent>();
            _eventComponent.CheckSubscribe(AuthEventArgs.EventId, OnAuthEventArgs);
            _shareSDK = Object.FindObjectOfType<ShareSDK>();
#if UNITY_ANDROID
            _shareSDK.devInfo.wechat.AppId = appId;
            _shareSDK.devInfo.wechat.AppSecret = appKey;

            _shareSDK.devInfo.wechatFavorites.AppId = appId;
            _shareSDK.devInfo.wechatFavorites.AppSecret = appKey;

            _shareSDK.devInfo.wechatMoments.AppId = appId;
            _shareSDK.devInfo.wechatMoments.AppSecret = appKey;
#endif
#if UNITY_IOS || UNITY_IPHONE
            _shareSDK.devInfo.wechat.app_id = appId;
            _shareSDK.devInfo.wechat.app_secret = appKey;

            _shareSDK.devInfo.wechatFavorites.app_id = appId;
            _shareSDK.devInfo.wechatFavorites.app_secret = appKey;

            _shareSDK.devInfo.wechatMoments.app_id = appId;
            _shareSDK.devInfo.wechatMoments.app_secret = appKey;
#endif
            _isInit = true;
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
                    if (_loginSuccess == null)
                    {
                        return;
                    }

                    Success();
                }
                else
                {
                    _loginFail?.Invoke((int)eventArgs.State);
                }
            }
        }

        private void Success()
        {
            Hashtable authInfo = _shareSDK.GetAuthInfo(PlatformType.WeChat);
            Log.Debug(authInfo);
            var weChatLoginSuccess = new WeChatLoginSuccess();
            if (authInfo != null)
            {
                if (authInfo.ContainsKey("userName"))
                {
                    weChatLoginSuccess.NickName = authInfo["userName"].ToString();
                }

                if (authInfo.ContainsKey("openID"))
                {
                    weChatLoginSuccess.OpenId = authInfo["openID"].ToString();
                }

                if (authInfo.ContainsKey("unionID"))
                {
                    weChatLoginSuccess.UnionId = authInfo["unionID"].ToString();
                }

                if (authInfo.ContainsKey("userIcon"))
                {
                    weChatLoginSuccess.PhotoUrl = authInfo["userIcon"].ToString();
                }

                if (authInfo.ContainsKey("userID"))
                {
                    weChatLoginSuccess.UserId = authInfo["userID"].ToString();
                }

                if (authInfo.ContainsKey("token"))
                {
                    weChatLoginSuccess.Token = authInfo["token"].ToString();
                }
            }

            _loginSuccess?.Invoke(weChatLoginSuccess);
        }

        private Action<WeChatLoginSuccess> _loginSuccess;
        private Action<int> _loginFail;

        [UnityEngine.Scripting.Preserve]
        public void Login(Action<WeChatLoginSuccess> loginSuccess, Action<int> loginFail)
        {
            _loginSuccess = loginSuccess;
            _loginFail = loginFail;
#if UNITY_EDITOR
            _loginSuccess?.Invoke(new WeChatLoginSuccess() { NickName = "test", OpenId = SystemInfo.deviceUniqueIdentifier, UserId = SystemInfo.deviceUniqueIdentifier, Token = "test", PhotoUrl = "test", UnionId = SystemInfo.deviceUniqueIdentifier });
            return;
#endif
            if (_shareSDK.IsAuthorized(PlatformType.WeChat))
            {
                Success();
                return;
            }

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