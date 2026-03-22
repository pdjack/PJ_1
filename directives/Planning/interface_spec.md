# 🖥️ PJ_1 인터페이스 상세 명세 (Interface Specification)

이 문서는 게임 내의 모든 **UI/UX 요소의 디자인 구성과 동작 로직**을 상세히 정의합니다.
핵심 게임 기획은 [proposal.md](./proposal.md)를, 기술 설계는 [architecture.md](../Architecture/architecture.md)를 참고하세요.

---

## 1. 개요 (Overview)
- **UI 플랫폼**: 모바일 터치 최적화 HUD.
- **주요 기술**: UGUI (Legacy/Active) 및 UI Toolkit (Future/High-Performance).

---

## 2. 게임플레이 인터페이스 (Gameplay HUD)

### 2.1 상태 정보 패널 (Stat Overlay Panel)
플레이어가 현재 자신의 전투력을 실시간으로 확인할 수 있는 오버레이 패널입니다.

| 항목 | 데이터 출처 (Source) | 설명 |
| :--- | :--- | :--- |
| **장착 무기** | `PlayerStat.GetCurrentEquip().name` | 현재 장착된 `EquipmentData`의 고유 명칭 표시 |
| **기본 공격력** | `PlayerStat.BaseDamage` | 무기 고유의 기본 데미지 수치 |
| **보너스 공격력** | `PlayerStat.BonusDamage` | 보너스(카드 등)로 인하여 증가된 데미지 수치 |

- **호출 방식**: 캔버스 우측 상단의 `?` 버튼 클릭 (`PlayerStatUI.Open()`)
- **종료 방식**: 패널 우측 상단 `X` 버튼 클릭 (`PlayerStatUI.Close()`)
- **시점**: 패널이 활성화될 때 `UpdateStats()`를 호출하여 최신 데이터를 반영.

### 2.2 실시간 전투 정보 (Combat Info)
| UI 이름 | 역할 | 데이터 연동 |
| :--- | :--- | :--- |
| **WaveText (TMP)** | 현재 진행 중인 웨이브 표시 | `WaveManager`에서 관리하는 현재 웨이브 번호 |
| **HpSlider** | 플레이어의 현재 체량(HP) 표시 | `PlayerStat.Hp / MaxHp` 비율 적용 |

---

## 3. 기능성 인터페이스 (Functional Interfaces)

### 3.1 카드 업그레이드 패널 (Card Selection Panel)
웨이브 종료 후 또는 경험치 획득 시 나타나는 캐릭터 강화 인터페이스입니다.
- **구성 요소**: `CardPanelUp`, `CardPanelDown` (임시로 상/하단 개별 관리)
- **로직**: `UpgradeManager`에서 랜덤 선택된 3개 혹은 2개의 카드를 리스트업.

---

## 4. 라이프사이클 및 갱신 규정 (UI Lifecycle)
1. **정적 요소**: 씬 로드 시 싱글톤(UIManager)에 의해 한 번만 바인딩됩니다.
2. **동적 요소**: 패널이 `SetActive(true)` 되는 시점에 `OnEnable` 혹은 수동 호출을 통해 데이터를 갱신합니다.
3. **이벤트 드리븐**: 체력 등 급격한 변화가 필요한 값은 옵저버 패턴을 고려하여 수치 변경 즉시 갱신합니다.

