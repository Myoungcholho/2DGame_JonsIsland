# 📌프로젝트 개요
<p align="center">
  <img
    width="800"
    src="https://github.com/user-attachments/assets/c9d4e36b-e065-4732-8626-eded706918ba"
    alt="Unity 2D" />
</p>

직접 기획하고 만든 5인 팀 어드벤처 퍼즐 게임입니다.  

저는 팀장으로서 전 과정에 참여하며 퍼즐 상호작용, 스태미나, 아이템, UI 등 핵심 게임 시스템을 구현했습니다.  

동시에 팀원들의 강점을 고려해 역할을 분배하고, 작업 흐름과 일정을 조율했습니다.  

이 프로젝트는 교내 창의력 설계대회에서 장려상을 수상하며, “처음부터 끝까지 스스로 만든 게임”이라는 의미 있는 경험인 프로젝트입니다.


| 항목 | 내용 |
|------|------|
| 📹 소개 영상 | [📎포트폴리오 영상](https://www.youtube.com/watch?v=CVj2y5PXsnw) |
| 🕒 개발 기간 | 2023.04.11 ~ 2023.10.11 (184일) |
| 👤 개발 인원 | 5명 - (팀장) **스크립트 전반 구현** , 핵심 시스템 기획, 역할 분배 및 진행 관리 |
| 🧰 개발 환경 | C# |
| 🛠 실행 및 디버깅 툴 | Unity |

</br>

# 📘목차
- [구현 내용](#구현-내용-목차-이동)
- [핵심 주요 코드](#핵심-주요-코드-목차-이동)
- [문제 해결 경험(트러블 슈팅)](#문제-해결-경험트러블-슈팅-목차-이동)
- [프로젝트에서 얻은 것](#프로젝트에서-얻은-것-목차-이동)
- [개발 계기](#개발-계기-목차-이동)

</br>

# 📘구현 내용 [(목차 이동)](#목차)

| 상세 설명 링크 | 구현 요약 |
|----------------------|------------------|
| 플레이어 상호작용 | 대화, 상호작용 오브젝트, 박스 밀기, 트리거 이동, 덫/탈출 기믹 구현 |
| 게임 시스템| 스태미나, 아이템 획득/사용, 오브젝트 파괴, 시야 연출, 스테이지 전환 |
| UI / 사운드 / 저장 | UI 화면 구성, 인벤토리/미니맵, 키·사운드 설정, JSON 세이브/로드 |

</br>

# 📘핵심 주요 코드 [(목차 이동)](#목차)

| 코드 파일 | 코드 설명 |
|----------|-----------|
| SaveManager [.cs](https://github.com/Myoungcholho/2DGame_JonsIsland/blob/main/Assets/Script/Save/SaveManager.cs) | JSON 기반 세이브/로드 시스템과 저장 UI 제어, 인벤토리·플레이어 위치 복원을 담당하는 클래스 |
| Item [.cs](https://github.com/Myoungcholho/2DGame_JonsIsland/blob/main/Assets/Script/Item/Item.cs) | 아이템의 고유 정보를 담는 베이스 클래스이며, Use() 가상 함수를 통해 아이템마다 다른 동작을 수행할 수 있도록 설계함 |
| Player_Action [.cs](https://github.com/Myoungcholho/2DGame_JonsIsland/blob/main/Assets/Script/Player/Player_Action.cs) | 플레이어의 이동 입력과 속도 제어, 애니메이션·발소리까지 포함해 움직임 전반을 담당하는 클래스 |

</br>

# 📘문제 해결 경험(트러블 슈팅) [(목차 이동)](#목차)

<table style="border-collapse:collapse;">
  <tr>
    <th width="350" style="border:2px solid #ffb3b3; background:#ffe1e1;">
      📂 Delegate 해제 시점 문제로 인한 참조 오류
    </th>
    <th width="350" style="border:2px solid #ffd27f; background:#fff1d6;">
      📚 일부 UI 레이어가 페이드 레이어에 의해 가려지지 않는 문제
    </th>
    <th width="350" style="border:2px solid #c3c3ff; background:#e9e9ff;">
      🧾 UI 버튼 비활성화 시 사운드 끊김 문제
    </th>
  </tr>

  <tr>
    <td width="350" style="border:2px solid #ffb3b3; background:#ffe1e1; vertical-align:top;">
        델리게이트를 해제하지 않아 발생하던 오류를 라이프사이클에 맞게 수정하여 해결했습니다.
      <br><br>
      <a href="#t0">[상세설명]</a>
    </td>
    <td width="350" style="border:2px solid #ffd27f; background:#fff1d6; vertical-align:top;">
      페이드 연출 시 일부 UI가 가려지지 않던 문제를 Frame Debugger로 원인을 파악하고 렌더링 순서를 재설계해 해결했습니다.
      <br><br>
      <a href="#t1">[상세설명]</a>
    </td>
    <td width="350" style="border:2px solid #c3c3ff; background:#e9e9ff; vertical-align:top;">
        UI 버튼 클릭 시 사운드가 정상적으로 재생되지 않던 문제를 SoundManager 도입으로 해결했습니다.
      <br><br>
      <a href="#t2">[상세설명]</a>
    </td>
  </tr>
</table>

<br>

---

## 1. Delegate 해제 시점 문제로 인한 참조 오류 <a id="t0"></a> [(트러블 슈팅 목록 이동)](#문제-해결-경험트러블-슈팅-목차-이동)

<table>
  <tr>
    <td style="border:2px solid #4fa3ff; border-radius:8px; padding:12px 16px; background:#050812;">
      <strong>🧩 문제</strong>
      <ul>
        <li> 오브젝트 비활성화 후 재활성 시 남은 Delegate 연결로 MissingReference 예외가 발생 </li>
      </ul>
      <strong>🔍 원인 분석</strong>
      <ul>
        <li> OnDestroy()에서 이벤트 해제를 수행했지만, SetActive(false)로 비활성화될 때 OnDestroy가 호출되지 않았기 때문</li>
      </ul>
      <strong>🛠 해결</strong><br>
      <ul>
        <li> 이벤트 등록과 해제를 OnEnable/OnDisable에 배치해 라이프사이클에 맞게 재설계 </li>
      </ul>
      <strong>📚 배운 점</strong>
      <ul>
        <li> Unity 라이프사이클에 대한 정확한 이해가 안정적인 코드 작성과 콘텐츠 구현의 기반이 된다는 것을 체감 </li>
        <li> 활성/비활성 타이밍과 로직의 매칭이 중요하며, 이를 놓치면 예외 발생이나 예측 불가능한 동작으로 이어질 수 있다는 점을 배움</li>
      </ul>
    </td>
  </tr>
</table>

---

## 2. 일부 UI 레이어가 페이드 레이어에 의해 가려지지 않는 문제 <a id="t1"></a> [(트러블 슈팅 목록 이동)](#문제-해결-경험트러블-슈팅-목차-이동)

<table>
  <tr>
    <td style="border:2px solid #ffd27f; border-radius:8px; padding:12px 16px; background:#120d05;">
      <strong>🧩 문제</strong>
      <ul>
        <li> 화면 전체를 덮는 페이드 연출에서 일부 UI가 페이드 레이어에 가려지지 않는 문제가 발생 </li>
      </ul>
      <strong>🔍 원인 분석</strong>
      <ul>
        <li> Canvas의 Render Mode, Sorting Order, Canvas 그룹 구조를 고려하지 않고 모든 UI를 하나의 Canvas에 배치한 것이 원인 </li>
      </ul>
      <strong>🛠 해결</strong><br>
      <ul>
        <li> Frame Debugger를 활용해 Canvas 전체가 재렌더링되는 구조를 분석하고, UI 역할별로 Canvas를 분리하고 Sorting Order를 재설계해 문제를 해결 </li>
      </ul>
      <strong>📚 배운 점</strong>
      <ul>
        <li> 디버깅 도구를 활용해 실제 렌더링 순서를 확인하는 것이 중요하다는 점 </li>
        <li> 역할별 Canvas 분리와 정렬 우선순위 설계의 중요성을 깨달음 </li>
      </ul>
    </td>
  </tr>
</table>

---

## 3. UI 버튼 비활성화 시 사운드 끊김 문제 <a id="t2"></a> [(트러블 슈팅 목록 이동)](#문제-해결-경험트러블-슈팅-목차-이동)

<table>
  <tr>
    <td style="border:2px solid #a8ddff; border-radius:8px; padding:12px 16px; background:#050a12;">
      <strong>🧩 문제</strong><br>
      <ul>
        <li> 버튼 클릭 시 AudioSource로 재생한 사운드가 중간에 끊기는 문제가 발생 </li>
      </ul>
      <strong>🔍 원인 분석</strong><br>
      <ul>
        <li> 사운드를 재생하는 AudioSource가 버튼 오브젝트에 붙어 있었던 점  </li>
        <li> 버튼을 닫는 동작에서 그 오브젝트를 곧바로 비활성화(SetActive(false)) 하면서 오디오 재생도 같이 중단됨 </li>
      </ul>
      <strong>🛠 해결</strong>
      <ul>
        <li> 사운드를 개별 오브젝트에 두지 않고, 공용 SoundManager에서 일괄 관리하도록 구조 변경 </li>
        <li> 버튼 클릭 시 사운드매니저에 오디오 기능을 호출하도록 수정 </li>
      </ul>
      <strong>📚 배운 점</strong>
      <ul>
        <li> 오브젝트 라이프사이클(비활성/파괴)이 붙어 있는 컴포넌트에 직접 의존하면 예상치 못한 타이밍에 기능이 끊길 수 있다는 걸 체감 </li>
        <li> 재사용성과 확장성을 생각하면 Manager를 통해 공용 리소스를 한 곳에서 관리하는 구조가 유리하다는 걸 배움 </li>
      </ul>
    </td>
  </tr>
</table>

---

</br>

# 📘프로젝트에서 얻은 것 [(목차 이동)](#목차)

| 번호 | 얻은 경험 |
|------|-----------|
| 1 | [팀 단위 프로젝트 운영 역량](#gain-drawcall) |
| 2 | [전체적인 게임 프로세스와 라이프사이클 이해](#gain-ue-arch) |
| 3 | [언어 차원에서의 객체지향 이해와 실력 향상](#gain-cpp-resource) |
| 4 | [컴포넌트 기반 설계의 필요성을 체감](#gain-gt-rt) |
| 5 | [Update 의존 로직에서 이벤트 기반 구조로 전환](#gain-matrix) |

---

### 1. 팀 단위 프로젝트 운영 역량 <a id="gain-drawcall"></a> [(⬆표로 이동)](#프로젝트에서-얻은-것-목차-이동)

팀으로 개발을 진행하며 마감 기한, 역할 분배, 회의 정리, 코드 공유 방식 등 개발 외적인 여러 문제에도 자연스럽게 부딪히게 되었습니다.

이 과정에서 규칙을 정하고 회의록과 정리 문서를 남기며 협업 방식을 다듬었고, 팀 프로젝트를 더 효율적으로 운영하는 방법을 몸으로 배울 수 있었습니다.

---

### 2. 전체적인 게임 프로세스와 라이프사이클 이해 <a id="gain-ue-arch"></a> [(⬆표로 이동)](#프로젝트에서-얻은-것-목차-이동)

처음에는 단순히 "로직 → 렌더링" 흐름 정도만 이해하고 있었지만, 엔진을 활용해 개발하면서 Awake, Start, OnEnable, Update, FixedUpdate, Tick 등 여러 생명주기를 직접 다뤄 보게 되었습니다.

이를 통해 엔진이 프레임 단위로 게임을 어떻게 구동하는지 체감했고, 각 콜백이 왜 분리되어 있는지, 어떤 책임을 맡는 것이 적절한지 고민해 볼 수 있는 계기가 되었습니다.

---

### 3. 언어 차원에서의 객체지향 이해와 실력 향상 <a id="gain-cpp-resource"></a> [(⬆표로 이동)](#프로젝트에서-얻은-것-목차-이동)

프로젝트를 시작할 당시에는 객체지향에 대한 이해가 얕은 편이었습니다.

하지만 개발을 진행하면서 반복되는 코드를 공통화하거나 재사용 가능한 구조로 바꾸는 등, 객체지향적인 설계를 적용해 보려는 시도를 계속하게 되었습니다.

이 경험을 통해 언어와 문법을 단순히 "사용하는 수준"을 넘어, 구조를 설계하고 개선하는 방향으로 사고하는 연습을 할 수 있었습니다.

---

### 4. 컴포넌트 기반 설계의 필요성을 체감 <a id="gain-gt-rt"></a> [(⬆표로 이동)](#프로젝트에서-얻은-것-목차-이동)

초기에는 스크립트를 기능 단위로 잘게 나누는 데 집중했지만, 프로젝트가 커질수록 중복 코드와 재사용성 한계를 직접 경험했습니다.

이를 통해 인터페이스와 공통 컴포넌트 기반으로 구조를 잡아야 확장성과 유지보수성이 좋아진다는 점을 분명하게 깨달았습니다.

이 경험을 바탕으로 이후 진행한 Unity 3D Action 프로젝트에서는 초기 설계 단계부터 역할 분리와 컴포넌트화를 우선으로 구조를 설계했습니다.

---

### 5.  Update 의존 로직에서 이벤트 기반 구조로 전환 <a id="gain-matrix"></a> [(⬆표로 이동)](#프로젝트에서-얻은-것-목차-이동)

UI 갱신이나 아이템 획득처럼 특정 시점에만 필요한 로직도 처음에는 습관적으로 Update()에서 매 프레임 체크하도록 구현했습니다.

이를 이벤트 기반 호출로 전환해 불필요한 연산을 줄이고 구조도 더 명확해진다는 것을 경험했습니다.

이후에는 “정말 매 프레임 돌 필요가 있는 로직인가?”를 먼저 고민하게 되었고, 가능한 한 이벤트/콜백 기반으로 설계하는 개발 습관을 갖게 되었습니다.

</br>

# 📘개발 계기 [(목차 이동)](#목차)
### 1. 플레이어에서 개발자로

특히 인상 깊게 즐겼던 「OMORI」의 영향을 받아 플레이어가 아니라 직접 만드는 입장에서 쯔꾸르 스타일 게임을 만들어 보고자 프로젝트를 시작했습니다.
