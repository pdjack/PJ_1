# 🛡️ PJ_1 중세 콘텐츠 상세 명세 (Content Specification)

이 문서는 게임 내 핵심 전투 요소인 **중세 무기**와 **보조 병사**의 데이터 구조 및 종류를 상세히 정의합니다.
게임 전체 기획은 [proposal.md](./proposal.md)를, 기술 설계 및 코드 매핑은 [architecture.md](../Architecture/architecture.md)를 참고하세요.

---

## 1. 메인 무기 시스템 (Main Weapons)
플레이어가 터치 드래그로 직접 조작하는 휘두르기 무기입니다.
유니티 `EquipmentData` ScriptableObject를 통해 관리합니다. (`Assets/ScriptableObjects/Item/Scripts/EquipmentData.cs`)
> 상위 클래스: `ItemData` (`icon`, `type`, `description`)

### 📋 공통 데이터 구조 (Base Attributes)
| 필드 | 타입 | 설명 | 구현 상태 |
| :--- | :--- | :--- | :--- |
| `equipmentPrefab` | `GameObject` | 무기 외형 프리팹 | ✅ 구현됨 |
| `damage` | `int` | 기본 공격력 | ✅ 구현됨 |
| `defense` | `int` | 기본 방어력 | ✅ 구현됨 |
| `swingRadius` | `float` | 휘두르는 반경 (길이) | ⬜ 미구현 |
| `swingArc` | `float` | 타격 가능한 각도 (예: 120도 부채꼴) | ⬜ 미구현 |
| `swingSpeed` | `float` | 회전 추적 및 휘두르기 속도 | ⬜ 미구현 |
| `knockback` | `float` | 타격 시 적을 밀어내는 힘 | ⬜ 미구현 |
| `dizzyPenalty` | `float` | 과도한 회전 시 어지러움 디버프 수치 | ⬜ 미구현 (현재 `PlayerAttack.cs`에 하드코딩) |

> **참고**: `PlayerAttack.cs`의 `ROTATION_THRESHOLD(3600f)`, `DIZZY_DURATION(5f)`는 향후 `EquipmentData`의 SO 필드로 이전하여 무기별 차별화가 가능하도록 리팩토링 예정.

### ⚔️ 초기 무기 라이브러리 (Weapon Library)
| 무기 이름 | 특징 | 주요 능력치 강점 |
| :--- | :--- | :--- |
| **강철 대검 (Greatsword)** | 밸런스 잡힌 표준 무기 | 속도, 범위 모두 평이 |
| **파괴의 도끼 (BattleAxe)** | 휘두르기는 느리지만 파괴적 | 매우 높은 공격력 및 넉백 |
| **은빛 철퇴 (Morningstar)** | 타격 시 적을 잠시 기절시킴 | 특수 효과 (Stun) 특화 |
| **심판의 장검 (Longsword)** | 가볍고 매우 빠르게 회전 가능 | 휘두르기 속도 최첨단 |

---

## 2. 보조 병사 시스템 (Auxiliary Sentinels)
플레이어 주변에서 자동으로 공격하여 사각지대를 방어하는 보조 유닛입니다. 유니티 `SentinelData` ScriptableObject를 통해 관리합니다.

> ⬜ **SentinelData SO 클래스는 아직 미구현 상태입니다.**

### 📋 공통 데이터 구조 (Base Attributes)
- `string soldierName`: 병사 이름/직함
- `float attackRange`: 적 감지 및 공격 사거리
- `float attackInterval`: 공격 간의 딜레이 (초 단위)
- `float projectileSpeed`: 투사체(화살 등)의 비행 속도
- `int maxDeployment`: 최대 배치 가능 인원수
- `string specialSkill`: 고유 특수 능력 (Slow, Bleed 등)

### 🏹 초기 병사 라이브러리 (Soldier Library)
| 병과 이름 | 역할 | 공격 방식 |
| :--- | :--- | :--- |
| **성벽 궁수 (Archer)** | 원거리 점사 및 엄호 | 먼 거리의 단일 적 조준 사격 |
| **견습 마법사 (Mage)** | 광역 감속 및 제어 | 타격 지점에 작은 얼음 폭발 생성 (Slow) |
| **정예 창병 (Spearman)** | 근접 진입 방어 | 근거리 접근 적을 찔러서 강한 넉백 부여 |
| **성스러운 사제 (Priest)** | 성문 및 기사 기력 회복 | 주기적으로 기사(플레이어)의 체력 소폭 회복 |

---

## 3. 상태 이상 효과 (Status Effects)
무기와 병사의 공격에 부가되는 특수 효과들입니다.

- **기절 (Stun)**: 일정 시간 동안 몬스터의 이동 및 공격 중단.
- **슬로우 (Slow)**: 몬스터의 이동 속도 저하.
- **출혈 (Bleed)**: 일정 시간 동안 지속 피해 입힘.
*   **넉백 (Knockback)**: 몬스터를 뒤로 강하게 밀쳐냄.

---

## 4. 경제 및 업그레이드 연동 (Economy Integration)
- **카드 구매**: 인게임에서 얻은 **경험치(EXP)**를 사용해 특정 무기를 강화하거나 보조 병사를 영입할 수 있습니다.
- **강화 방식**: 기존 무기/병사의 SO 데이터를 참조하여 런타임에서 `modifier` 수치를 적용합니다. (예: `currentDamage * 1.5`)
