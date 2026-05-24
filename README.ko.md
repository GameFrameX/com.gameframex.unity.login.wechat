<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X WeChat 로그인

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.wechat?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.wechat/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.wechat?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.wechat/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현**

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · [QQ 그룹](https://qm.qq.com/q/5s5e1e6e6e)

**언어**: [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

---

## 프로젝트 개요

Game Frame X WeChat 로그인은 GameFrameX 프레임워크의 WeChat 로그인 컴포넌트로, ShareSDK 인증을 기반으로 하며 GameFrameX 이벤트 시스템을 통해 로그인 결과를 반환합니다.

## 빠른 시작

### 설치

다음 방법 중 하나를 선택하세요:

1. 프로젝트의 `manifest.json` 파일의 `dependencies` 섹션에 다음을 추가:
   ```json
   {"com.gameframex.unity.login.wechat": "https://github.com/AlianBlank/com.gameframex.unity.login.wechat.git"}
   ```

2. Unity의 Package Manager에서 `Git URL` 사용:
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.wechat.git
   ```

3. 저장소를 다운로드하여 Unity 프로젝트의 `Packages` 디렉토리에 배치. 자동으로 로드됩니다.

## 사용 예시

1. `GameEntry` 오브젝트에 `WeChatLoginComponent`를 연결합니다.
2. `EventComponent`도 `GameEntry`에 연결되어 있는지 확인합니다 (인증 이벤트 수신용).
3. 씬에 `ShareSDK` 컴포넌트(`cn.sharesdk.unity3d`에서)를 추가하고 구성합니다.
4. `WeChatLoginComponent` Inspector에서 `AppId` 및 `AppKey`(WeChat AppSecret)를 설정합니다.
5. 메서드를 호출합니다:

```csharp
// WeChat 로그인 컴포넌트 가져오기
var weChatLoginComponent = GameEntry.GetComponent<WeChatLoginComponent>();

// 초기화 (AppId/AppKey를 ShareSDK의 WeChat 설정에 기록)
weChatLoginComponent.Init();

// 로그인
weChatLoginComponent.Login(
    (weChatLoginSuccess) =>
    {
        Debug.Log($"로그인 성공! {weChatLoginSuccess.ToString()}");
        // weChatLoginSuccess.NickName / UnionId / OpenId / PhotoUrl 사용 가능
    },
    (code) =>
    {
        Debug.LogError($"로그인 실패! 응답 코드: {code}");
    });

// 로그아웃 (인증 취소)
weChatLoginComponent.LogOut();
```

## 의존성

- `com.gameframex.unity`: GameFrameX 핵심 프레임워크
- `com.gameframex.unity.sharesdk`: ShareSDK 통합

## 문서 및 자료

- 문서: https://gameframex.doc.alianblank.com
- 저장소: https://github.com/GameFrameX/com.gameframex.unity.login.wechat
- Issues: https://github.com/GameFrameX/com.gameframex.unity.login.wechat/issues

## 라이선스

이 프로젝트는 MIT 라이선스에 따라 배포됩니다. 자세한 내용은 [LICENSE](LICENSE.md) 파일을 참조하세요.
