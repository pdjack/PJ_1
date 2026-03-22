# 🛠️ Unity Automation Scripts (Execution/)

이 폴더는 AI 에이전트와 사용자가 프로젝트를 효율적으로 관리하기 위해 사용하는 **자동화 툴(C# 유틸리티 및 스크립트)** 보관소입니다.

## 📦 실전 배포 도구 (Assets/Editor/Automation/)

현재 아래의 통합 툴이 실제 프로젝트에 배포되어 즉시 사용 가능합니다.
- **[PJ1_AutomationTools.cs](../../Assets/Editor/Automation/PJ1_AutomationTools.cs)**: 두 기능을 통합한 핵심 에디터 툴입니다.

### 🚀 사용 가능한 기능 및 메뉴 경로
1. **Initialize Scene** (`PJ1 > Automation > Setup Scene All`)
   - 씬 내 필수 매니저(Wave, UI, Upgrade, MonsterSpawn)와 기본 구조(Canvas, ES)를 일괄 확인하고 생성합니다.
2. **Register Card** (`PJ1 > Automation > Register New Card Template`)
   - 새 업그레이드 카드 에셋을 생성하고 `CardManager` SO의 리스트에 자동으로 등록합니다.

---

## 📂 템플릿 보관소 (Execution/ 소스)

이 폴더의 파일들은 새로운 환경에서 툴을 재구축하거나 로직을 수정할 때 사용하는 원본 템플릿입니다. AI는 기능 수정 시 아래 파일을 먼저 업데이트한 후 프로젝트에 반영합니다.

1. **SceneSetupUtility.cs**: 씬 구성 자동화 로직 원본
2. **CardCreatorUtility.cs**: 카드 등록 자동화 로직 원본
3. **README.md**: 본 문서 (도구 목록 및 명세 관리)

