# 📜 ScriptableObject (SO) 데이터 구조 정의 (Data Structures)

이 문서는 `PJ_1` 프로젝트의 **데이터 중심 설계(Data-Driven Design)**의 핵심인 모든 `ScriptableObject`의 기능과 구조를 정의합니다.

---

## 1. 개요 (Overview)
`PJ_1`의 모든 밸런싱 데이터 및 게임 규칙은 `ScriptableObject`를 통해 관리됩니다. 이를 통해 개발자는 코드 수정 없이 인스톨러(Inspector)에서 수치를 조정하고 새로운 콘텐츠(무기, 몬스터, 카드)를 추가할 수 있습니다.

---

## 2. 아이템 시스템 (Item System)
모든 획득 가능한 아이템의 기본 데이터 구조입니다.

| 클래스명 | 경로 | 설명 | 주요 필드 |
| :--- | :--- | :--- | :--- |
| **ItemData** (abstract) | `Item/Scripts/ItemData.cs` | 모든 아이템의 공통 속성 | `icon`, `type`, `description` |
| **EquipmentData** | `Item/Scripts/EquipmentData.cs` | 플레이어가 장착하는 무기/방어구 | `equipmentPrefab`, `damage`, `defense` |

> [!NOTE]
> `ItemData`를 상속받아 소모품(`ConsumableData`) 등으로 확장이 가능합니다.

---

## 3. 몬스터 및 웨이브 시스템 (Monster & Wave System)
적의 능력치와 스폰 규칙을 정의하는 계층 구조입니다.

### 3.1 몬스터 데이터 (Monster Hierarchy)
몬스터는 단일 파일이 아닌, 용도별 데이터(공격/방어)를 조합하여 구성합니다.

| 클래스명 | 경로 | 설명 | 주요 필드 |
| :--- | :--- | :--- | :--- |
| **MonsterData** | `Monster/Scripts/MonsterData.cs` | 몬스터의 최종 정의 파일 | `monsterPrefab`, `attack (MonAttackData)`, `stats (MonStatData)` |
| **MonAttackData** | `Monster/Scripts/MonAttackData.cs` | 몬스터의 공격 관련 수치 | `damage`, `attackSpeed`, `range` |
| **MonStatData** | `Monster/Scripts/MonStatData.cs` | 몬스터의 기본 스탯 | `maxHp`, `defense`, `moveSpeed` |

### 3.2 웨이브 정의 (Wave Configuration)
| 클래스명 | 경로 | 설명 | 주요 필드 |
| :--- | :--- | :--- | :--- |
| **WaveData** | `Wave/Scripts/WaveData.cs` | 전체 웨이브의 리스트 | `List<WaveDetail> waves` |
| **WaveDetail** (struct) | — | 개별 웨이브의 설정 | `spawnInterval`, `monsterList`, `damageMultiplier`, `hpMultiplier` |

---

## 4. 카드 및 업그레이드 시스템 (Card & Upgrade System)
게임 내 성장을 관리하는 런타임 데이터 구조입니다.

| 클래스명 | 경로 | 설명 | 주요 필드 |
| :--- | :--- | :--- | :--- |
| **UpgradeCardData** (abstract) | `Card/Scripts/UpgradeCardData.cs` | 모든 강화 카드의 기본 클래스 | `cardName`, `grade`, `ApplyEffect()` |
| **StatUpgradeCardData** | `Card/Scripts/StatUpgradeCardData.cs` | HP, 공격력 등 단순 수치 강화 | `statType`, `value` |
| **MultiShotCardData** | `Card/Scripts/MultiShotCardData.cs` | 멀티샷 등 특수 로직 강화 | `extraProjectiles`, `damageMultiplier` |
| **CardManager** | `Card/Scripts/CardManager.cs` | 전체 카드 풀 및 획득 확률 제어 | `allCards`, `probabilities (GradeWeights)` |

---

## 🚀 향후 개선 및 확장 방안 (Future Improvements)

### 1. 계층형 데이터 구조의 일관성 (Uniformity)
*   현재 `MonsterData`는 하위 SO(`MonAttackData`, `MonStatData`)를 참조하는 방식이지만, `EquipmentData`는 모든 필드가 한 클래스에 있습니다.
*   **제안**: `BaseStats`와 같은 공통 데이터 구조(Struct)를 만들어 모든 유닛(플레이어, 몬스터, 용병)이 동일한 방식으로 스탯을 관리하도록 통일하는 것을 권장합니다.

### 2. 효과 시스템의 모듈화 (Modular Effects)
*   현재 특수 효과가 필요할 때마다 `MultiShotCardData`처럼 새로운 클래스를 상속받아야 합니다.
*   **제안**: `ApplyEffect()` 내부 로직을 수행하는 `EffectSO`들을 리스트로 관리하면, 코드 수정 없이 데이터 조합만으로 새로운 카드를 생성할 수 있습니다.

### 3. 검증 로직 강화 (Data Validation)
*   `CardManager`에서 확률 총합이 100을 넘지 않도록 하는 `OnValidate` 검증이나, `damageMultiplier`가 음수가 되지 않도록 `[Min(0)]` 어트리뷰트를 추가하여 데이터 수동 입력을 방지할 것을 권장합니다.

### 4. 사양 문서 기반 필드 확장
*   `EquipmentData`에 아직 구현되지 않은 `swingRadius`, `swingArc` 필드를 추가하여 [content_spec.md](../Planning/content_spec.md)의 기획 사양과 코드를 동기화해야 합니다.
