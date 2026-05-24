<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X WeChat ログイン

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.wechat?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.wechat/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.wechat?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.wechat/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援**

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · [QQグループ](https://qm.qq.com/q/5s5e1e6e6e)

**言語**: [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

---

## プロジェクト概要

Game Frame X WeChat ログインは、GameFrameX フレームワークの WeChat ログインコンポーネントで、ShareSDK 認証に基づき、GameFrameX イベントシステムを通じてログイン結果を返します。

## クイックスタート

### インストール

以下のいずれかの方法をお選びください：

1. プロジェクトの `manifest.json` の `dependencies` セクションに以下を追加：
   ```json
   {"com.gameframex.unity.login.wechat": "https://github.com/AlianBlank/com.gameframex.unity.login.wechat.git"}
   ```

2. Unity の Package Manager で `Git URL` を使用：
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.wechat.git
   ```

3. リポジトリをダウンロードして Unity プロジェクトの `Packages` ディレクトリに配置。自動的にロードされます。

## 使用例

1. `GameEntry` オブジェクトに `WeChatLoginComponent` をアタッチ。
2. `EventComponent` も `GameEntry` にアタッチ済みであることを確認（認証イベントの受信用）。
3. シーンに `ShareSDK` コンポーネント（`cn.sharesdk.unity3d` から）を追加して設定。
4. `WeChatLoginComponent` の Inspector で `AppId` と `AppKey`（WeChat AppSecret）を設定。
5. メソッドを呼び出し：

```csharp
// WeChat ログインコンポーネントの取得
var weChatLoginComponent = GameEntry.GetComponent<WeChatLoginComponent>();

// 初期化（AppId/AppKey を ShareSDK の WeChat 設定に書き込み）
weChatLoginComponent.Init();

// ログイン
weChatLoginComponent.Login(
    (weChatLoginSuccess) =>
    {
        Debug.Log($"ログイン成功! {weChatLoginSuccess.ToString()}");
        // weChatLoginSuccess.NickName / UnionId / OpenId / PhotoUrl が利用可能
    },
    (code) =>
    {
        Debug.LogError($"ログイン失敗! レスポンスコード: {code}");
    });

// ログアウト（認証のキャンセル）
weChatLoginComponent.LogOut();
```

## 依存関係

- `com.gameframex.unity`: GameFrameX コアフレームワーク
- `com.gameframex.unity.sharesdk`: ShareSDK 統合

## ドキュメントとリソース

- ドキュメント: https://gameframex.doc.alianblank.com
- リポジトリ: https://github.com/GameFrameX/com.gameframex.unity.login.wechat
- Issues: https://github.com/GameFrameX/com.gameframex.unity.login.wechat/issues

## ライセンス

このプロジェクトは MIT ライセンスの下で公開されています。詳細は [LICENSE](LICENSE.md) ファイルを参照してください。
