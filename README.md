<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X WeChat Login

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.wechat?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.wechat/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.wechat?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.wechat/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams**

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · [QQ Group](https://qm.qq.com/q/5s5e1e6e6e)

**Language**: **English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## Project Overview

Game Frame X WeChat Login is a WeChat login component for the GameFrameX framework, based on ShareSDK authorization, returning login results through the GameFrameX event system.

## Quick Start

### Installation

Choose one of the following methods:

1. Add the following to the `dependencies` section in your project's `manifest.json`:
   ```json
   {"com.gameframex.unity.login.wechat": "https://github.com/AlianBlank/com.gameframex.unity.login.wechat.git"}
   ```

2. Use `Git URL` in Unity's Package Manager:
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.wechat.git
   ```

3. Download the repository and place it in your Unity project's `Packages` directory. It will be loaded automatically.

## Usage Examples

1. Attach the `WeChatLoginComponent` to the `GameEntry` object.
2. Ensure `EventComponent` is also attached to `GameEntry` (for receiving authorization events).
3. Add and configure a `ShareSDK` component in the scene (from `cn.sharesdk.unity3d`).
4. Set `AppId` and `AppKey` (WeChat AppSecret) in the `WeChatLoginComponent` Inspector.
5. Call the methods:

```csharp
// Get WeChat login component
var weChatLoginComponent = GameEntry.GetComponent<WeChatLoginComponent>();

// Initialize (writes AppId/AppKey to ShareSDK's WeChat config)
weChatLoginComponent.Init();

// Login
weChatLoginComponent.Login(
    (weChatLoginSuccess) =>
    {
        Debug.Log($"Login successful! {weChatLoginSuccess.ToString()}");
        // weChatLoginSuccess.NickName / UnionId / OpenId / PhotoUrl available
    },
    (code) =>
    {
        Debug.LogError($"Login failed! Response code: {code}");
    });

// Logout (cancel authorization)
weChatLoginComponent.LogOut();
```

## Dependencies

- `com.gameframex.unity`: GameFrameX core framework
- `com.gameframex.unity.sharesdk`: ShareSDK integration

## Documentation & Resources

- Documentation: https://gameframex.doc.alianblank.com
- Repository: https://github.com/GameFrameX/com.gameframex.unity.login.wechat
- Issues: https://github.com/GameFrameX/com.gameframex.unity.login.wechat/issues

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE.md) for details.
