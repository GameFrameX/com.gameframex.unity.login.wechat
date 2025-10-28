# GameFrameX.Login.WeChat 微信登录

> GameFrameX.Login.WeChat 是 GameFrameX 框架的微信登录组件，基于 ShareSDK 授权，并通过 GameFrameX 事件系统返回登录结果。

## 功能

- `初始化`
- `登录`
- `登出`

## 安装与依赖

- 包名：`com.gameframex.unity.login.wechat`（UPM Git：`https://github.com/gameframex/com.gameframex.unity.login.wechat.git`）
- 依赖：`com.gameframex.unity >= 1.1.1`
- 插件：需要集成 `cn.sharesdk.unity3d`（ShareSDK）并在场景中存在 `ShareSDK` 组件。

## 使用方法

1.  挂载组件
    - 在 `GameEntry` 上挂载 `WeChatLoginComponent` 组件。
    - 确保 `GameEntry` 上已挂载 `EventComponent`（用于接收授权事件）。
    - 在场景中添加并配置 `ShareSDK` 组件（来自 `cn.sharesdk.unity3d`）。

2.  设置参数
    - 在 `WeChatLoginComponent` 的检视器中设置：
      - `AppId`：微信开放平台应用的 `AppID`
      - `AppKey`：微信开放平台应用的 `AppSecret`

3.  调用方法
    ```csharp
    using GameFrameX.Login.WeChat.Runtime;

    // 获取微信登录组件
    var weChatLoginComponent = GameEntry.GetComponent<WeChatLoginComponent>();

    // 初始化（会将 AppId/AppKey 写入 ShareSDK 的 WeChat 配置）
    weChatLoginComponent.Init();

    // 登录
    weChatLoginComponent.Login(
        (weChatLoginSuccess) =>
        {
            Debug.Log($"登录成功! {weChatLoginSuccess.ToString()}");
            // weChatLoginSuccess.NickName / UnionId / OpenId / PhotoUrl 可用
        },
        (code) =>
        {
            Debug.LogError($"登录失败! 响应码: {code}");
        });

    // 登出（取消授权）
    weChatLoginComponent.LogOut();
    ```

## 返回数据结构

- 类型：`WeChatLoginSuccess`
  - `NickName`：微信昵称
  - `OpenId`：用户 `OpenID`
  - `UnionId`：用户 `UnionID`
  - `PhotoUrl`：头像地址

登录失败时的 `code` 为 ShareSDK 的 `ResponseState` 枚举对应值（`cn.sharesdk.unity3d.ResponseState`），用于判断失败原因。

## 平台配置提示

- 请按 ShareSDK 官方文档完成微信登录的 Android/iOS 平台配置（注册应用、签名/包名、URL Scheme/通用链接等）。
- 组件在运行时会将 `AppId` 与 `AppSecret` 填充到 ShareSDK 的 `wechat / wechatFavorites / wechatMoments` 配置，无需在 ShareSDK Inspector 手动重复填写。
- 场景中必须存在 `ShareSDK` 组件，否则无法授权。

## 组件与模块

- `WeChatLoginComponent`：对外组件，提供 `Init / Login / LogOut`。
- `IWeChatLoginManager`：登录管理接口。
- `WeChatLoginManager`：具体实现，订阅授权事件并回调结果。
- `WeChatLoginSuccess`：登录成功数据结构。
- `GameFrameXWeChatLoginCroppingHelper`：辅助保留类，供链接裁剪，用户无需配置。

## 参考与文档

- GameFrameX 文档：https://gameframex.doc.alianblank.com
- 本包仓库：https://github.com/gameframex/com.gameframex.unity.login.wechat.git
