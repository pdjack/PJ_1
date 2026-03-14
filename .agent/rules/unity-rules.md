---
trigger: always_on
---

---
description: Unity C# 코딩 컨벤션 및 에셋 관리 최적화 규칙
---

# 🎮 Unity 프로젝트 개발 가이드라인

이 문서는 우리 프로젝트의 일관성과 성능을 위해 AI 에이전트가 반드시 준수해야 하는 규칙입니다.

## 1. 코드 네이밍 및 스타일
* **PascalCase:** 클래스(Class), 메서드(Method), public 변수 및 프로퍼티에 사용합니다.
* **_camelCase:** private 및 protected 필드에는 접두어 `_`를 붙여 사용합니다.
* **SerializeField:** private 필드를 인스펙터에 노출할 때 반드시 사용하며, `[Header("그룹명")]`를 활용해 가독성을 높입니다.

## 2. Unity 성능 최적화 (Critical)
* **Update() 내 로직 최소화:** 매 프레임 실행되는 `Update()` 함수 안에서 `GetComponent`, `Find`, `SendMessage` 등 비용이 큰 함수 호출을 절대 금지합니다.
* **CompareTag 사용:** `if (other.tag == "Player")` 대신 메모리 할당이 없는 `if (other.CompareTag("Player"))`를 사용합니다.
* **Null 체크:** Unity 오브젝트의 생애주기 특성상 `?.` 연산자보다는 `if (obj == null)`과 같은 명시적 비교를 권장합니다.

## 3. 컴포넌트 및 구조
* **의존성 명시:** 특정 컴포넌트가 필수인 스크립트 상단에는 `[RequireComponent(typeof(T))]` 속성을 추가합니다.
* **싱글톤(Singleton):** 매니저급 클래스 구현 시 프로젝트 표준 싱글톤 패턴을 준수합니다.

## 4. 파일 위치
* 모든 스크립트는 `Assets/Scripts/` 하위의 기능별 폴더에 저장합니다.

## 5. AI 에이전트 출력 규정 (Language & Workflow)
* **언어 통일:모든 작업 계획 및 단계별 설명 작성 시 반드시 **한글**을 사용합니다.** AI 에이전트는 **플랜(Plan), 태스크(Task) 는 작성하지 않는다.
* **명확한 단계 분리:** 복잡한 구현 시 `구현 방향 설정 -> 단계별 태스크 생성 -> 코드 작성 -> 검증` 순서의 논리적 흐름을 한글로 상세히 기술합니다.