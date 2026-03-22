# 📋 플랜 작성 지침 (Planning SOP)

이 문서는 유저가 작업을 요청했을 때 AI 에이전트가 **어떤 방식으로 플랜을 수립하고 제시**해야 하는지를 정의합니다.
코드 수정에만 국한되지 않으며, 문서 작성, 씬 구성, 데이터 설계 등 모든 종류의 작업에 적용됩니다.

---

## 1. 작업 전 분석 (Pre-Analysis)

플랜을 작성하기 전, 아래 문서들을 참고하여 현재 프로젝트 상태를 파악합니다.

| 상황 | 참고해야 할 문서 |
| :--- | :--- |
| 기술 구조 및 시스템 간 연관성 파악 | `Directives/Architecture/architecture.md` |
| 어떤 문서를 읽어야 할지 판단 | `Directives/Architecture/document-map.md` |
| 데이터 구조(SO) 관련 작업 | `Directives/Architecture/data-structures.md` |
| 기획 의도 및 게임 루프 확인 | `Directives/Planning/proposal.md` |
| 콘텐츠 수치 및 구현 현황 확인 | `Directives/Planning/content_spec.md` |
| 코드 작성 규칙이 필요한 경우 | `Directives/Guidelines/coding-conventions.md` |

> 위 문서 중 해당 작업과 관련된 것만 선택적으로 확인하면 됩니다.

---

## 2. 플랜 구성 방식 (Plan Structure)

플랜은 **영구 문서가 아닌 임시 Artifact**로 제시합니다. 해당 작업이 종료되면 역할을 다한 것입니다.

### 플랜에 포함할 내용:

1.  **목표 (Goal):** 이 작업을 통해 달성하고자 하는 것을 한 문장으로 정의.
2.  **단계 (Steps):** 작업 순서를 논리적으로 나열. 유저가 각 단계를 확인하면서 진행.
3.  **리스크 (Risks):** 기존 기능에 영향을 줄 수 있는 부분이 있다면 사전에 명시.
    - 품질 기준은 `Directives/Guidelines/` 하위 문서를 참고할 것.

---

## 3. 보고 및 승인 규칙 (Approval Flow)

1.  작업 요청을 받으면 **코드나 파일을 수정하기 전에**, 위 형식의 플랜을 먼저 제시합니다.
2.  유저의 **승인** 또는 **수정 요청** 후 실제 작업을 시작합니다.
3.  각 단계가 완료될 때마다 결과를 보고하고 다음 단계를 진행합니다.
