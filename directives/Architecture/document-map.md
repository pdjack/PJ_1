# 🗺️ PJ_1 프로젝트 문서 맵 및 업데이트 관리 (Document Map)

이 문서는 `PJ_1` 프로젝트 내의 모든 Markdown(.md) 문서의 역할과 업데이트 주기를 관리하는 **중앙 허브**입니다. AI 에이전트는 작업을 시작하거나 종료할 때 이 지도를 참조하여 어떤 문서를 최신 상태로 유지해야 하는지 파악해야 합니다.

---

## 1. 문서 업데이트 우선순위 및 주기 (Update Matrix)

작업의 성격에 따라 업데이트가 필요한 문서를 아래 표에서 확인하세요.

| 문서명 | 경로 | 중요도 | 업데이트 트리거 (Trigger) | 역할 |
| :--- | :--- | :---: | :--- | :--- |
| **세션 로그** | [SESSION_LOG.md](../../SESSION_LOG.md) | **최상** | 매 작업 세션 시작 및 종료 시 | AI 간 협업 맥락 및 작업 이력 유지 |
| **전체 설계도** | [architecture.md](./architecture.md) | **고** | 주요 클래스 구조, 매니저 Logic 변경 시 | 프로젝트 기술 설계 허브 및 시스템 연동 정의 |
| **콘텐츠 명세** | [content_spec.md](../Planning/content_spec.md) | **중** | 신규 무기/병과 추가, 구현 상태(✅) 변경 시 | 상세 기획 수치 및 콘텐츠 진척도 관리 |
| **데이터 구조** | [data-structures.md](./data-structures.md) | **중** | ScriptableObject 생성 및 필드 수정 시 | 코드와 기획 간의 데이터 매핑 및 계층 정의 |
| **상세 기획서** | [proposal.md](../Planning/proposal.md) | **저** | 마일스톤 단계 완료 및 핵심 컨셉 변경 시 | 프로젝트 비전, 핵심 루프 및 전체 마일스톤 |
| **플랜 작성 지침** | [plan.md](../Planning/plan.md) | **저** | 플랜 작성 방식이 변경될 때 | AI 에이전트가 플랜을 수립하는 표준 절차 정의 |

---

## 2. 문서 간 참조 관계 (Relationship)

문서들은 서로 촘촘하게 연결되어 아키텍처의 무결성을 보장합니다.

- **[architecture.md](./architecture.md)**: 모든 문서의 최상위 허브 역할을 수행합니다.
- **[content_spec.md](../Planning/content_spec.md)** ↔ **[data-structures.md](./data-structures.md)**: 기획 사양의 수치가 데이터 구조(SO)에 어떻게 반영되는지 실시간으로 동기화되어야 합니다.
- **[agent-rules.md](../Agent/agent-rules.md)**: 모든 문서를 관리하고 코드를 작성하는 AI 에이전트의 행동 지침을 정의합니다.
- **[plan.md](../Planning/plan.md)**: 작업 요청 수신 시 AI 에이전트가 플랜을 수립하는 절차와 형식을 정의합니다.

---

## 3. 업데이트 워크플로우 (Workflow Guide)

1. **시작 시**: `SESSION_LOG.md`에 현재 세션의 목표를 기록합니다.
2. **개발 중**: 코드의 구조적 변화가 생기면 즉시 `architecture.md`와 `data-structures.md`에 반영합니다.
3. **완료 시**: 구현된 기능을 `content_spec.md`에서 '구현됨(✅)'으로 표시하고, `SESSION_LOG.md`에 최종 결과와 특이사항을 남깁니다.
