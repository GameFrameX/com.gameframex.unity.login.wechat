<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X 微信登錄

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.wechat?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.wechat/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.wechat?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.wechat/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使**

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · [QQ群](https://qm.qq.com/q/5s5e1e6e6e)

**語言**: [English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## 項目簡介

Game Frame X 微信登錄是 GameFrameX 框架的微信登錄組件，基於 ShareSDK 授權，並透過 GameFrameX 事件系統返回登錄結果。

## 快速開始

### 安裝

任選以下方式之一：

1. 直接在 `manifest.json` 的文件中的 `dependencies` 節點下添加以下內容：
   ```json
   {"com.gameframex.unity.login.wechat": "https://github.com/AlianBlank/com.gameframex.unity.login.wechat.git"}
   ```

2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式添加庫，地址為：
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.wechat.git
   ```

3. 直接下載倉庫放置到 Unity 項目的 `Packages` 目錄下，會自動加載識別。

## 使用範例

1. 在 `GameEntry` 上掛載 `WeChatLoginComponent` 組件。
2. 確保 `GameEntry` 上已掛載 `EventComponent`（用於接收授權事件）。
3. 在場景中添加並配置 `ShareSDK` 組件（來自 `cn.sharesdk.unity3d`）。
4. 在 `WeChatLoginComponent` 的檢視器中設置 `AppId` 和 `AppKey`（微信 AppSecret）。
5. 調用方法：

```csharp
// 獲取微信登錄組件
var weChatLoginComponent = GameEntry.GetComponent<WeChatLoginComponent>();

// 初始化（會將 AppId/AppKey 寫入 ShareSDK 的微信配置）
weChatLoginComponent.Init();

// 登錄
weChatLoginComponent.Login(
    (weChatLoginSuccess) =>
    {
        Debug.Log($"登錄成功! {weChatLoginSuccess.ToString()}");
        // weChatLoginSuccess.NickName / UnionId / OpenId / PhotoUrl 可用
    },
    (code) =>
    {
        Debug.LogError($"登錄失敗! 響應碼: {code}");
    });

// 登出（取消授權）
weChatLoginComponent.LogOut();
```

## 依賴項

- `com.gameframex.unity`: GameFrameX 核心框架
- `com.gameframex.unity.sharesdk`: ShareSDK 集成

## 文檔與資源

- 文檔地址: https://gameframex.doc.alianblank.com
- 倉庫地址: https://github.com/GameFrameX/com.gameframex.unity.login.wechat
- 問題反饋: https://github.com/GameFrameX/com.gameframex.unity.login.wechat/issues

## 開源協議

本項目遵循 MIT 許可證。詳細信息請查看 [LICENSE](LICENSE.md) 文件。
