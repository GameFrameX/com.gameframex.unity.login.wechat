﻿// GameFrameX 组织下的以及组织衍生的项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
// 
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE 文件。
// 
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;

namespace GameFrameX.Login.WeChat.Runtime
{
    /// <summary>
    /// 登录管理接口
    /// </summary>
    [UnityEngine.Scripting.Preserve]
    public interface IWeChatLoginManager
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appId">这个ID 必须是Web 的才可以</param>
        /// <param name="appKey"></param>
        [UnityEngine.Scripting.Preserve]
        void Init(string appId, string appKey);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginSuccess">登录成功回调,返回登录信息</param>
        /// <param name="loginFail">登录失败回调,返回错误码</param>
        [UnityEngine.Scripting.Preserve]
        void Login(Action<WeChatLoginSuccess> loginSuccess, Action<int> loginFail);

        /// <summary>
        /// 退出账号登录
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        void LogOut();
    }
}