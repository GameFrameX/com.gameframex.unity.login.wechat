<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X 微信登录

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.wechat?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.wechat/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.wechat?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.wechat/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使**

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · [QQ群](https://qm.qq.com/q/5s5e1e6e6e)

**语言**: [English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## 项目简介

Game Frame X 微信登录是 GameFrameX 框架的微信登录组件，基于 ShareSDK 授权，并通过 GameFrameX 事件系统返回登录结果。

## 快速开始

### 安装

任选以下方式之一：

1. 直接在 `manifest.json` 的文件中的 `dependencies` 节点下添加以下内容：
   ```json
   {"com.gameframex.unity.login.wechat": "https://github.com/AlianBlank/com.gameframex.unity.login.wechat.git"}
   ```

2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式添加库，地址为：
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.wechat.git
   ```

3. 直接下载仓库放置到 Unity 项目的 `Packages` 目录下，会自动加载识别。

## 使用示例

1. 在 `GameEntry` 上挂载 `WeChatLoginComponent` 组件。
2. 确保 `GameEntry` 上已挂载 `EventComponent`（用于接收授权事件）。
3. 在场景中添加并配置 `ShareSDK` 组件（来自 `cn.sharesdk.unity3d`）。
4. 在 `WeChatLoginComponent` 的检视器中设置 `AppId` 和 `AppKey`（微信 AppSecret）。
5. 调用方法：

```csharp
// 获取微信登录组件
var weChatLoginComponent = GameEntry.GetComponent<WeChatLoginComponent>();

// 初始化（会将 AppId/AppKey 写入 ShareSDK 的微信配置）
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

## 依赖项

- `com.gameframex.unity`: GameFrameX 核心框架
- `com.gameframex.unity.sharesdk`: ShareSDK 集成

## 文档与资源

- 文档地址: https://gameframex.doc.alianblank.com
- 仓库地址: https://github.com/GameFrameX/com.gameframex.unity.login.wechat
- 问题反馈: https://github.com/GameFrameX/com.gameframex.unity.login.wechat/issues

## 开源协议

本项目遵循 MIT 许可证。详细信息请查看 [LICENSE](LICENSE.md) 文件。
