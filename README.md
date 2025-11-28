# 프로젝트 소개
- **프로젝트명 :** MyInventory
- **프로젝트 기간 :** 2025.11.24 - 2025.11.26 (3일)
- **프로젝트 설명 :** 내일배움캠프 Unity 과정 12기 8주차 (Unity 심화) 개인 과제 인벤토리 구현 레포지토리입니다:)

---
# 구현 기능
### 필수 기능
  - **UI 구성**
    - **`UIMainMenu`**<br><br><img width="550" height="310" alt="image" src="https://github.com/user-attachments/assets/62baf197-4429-4a1c-b7ae-3bf6234bf823" />
    <br>
    
    - **`UIStatus`**<br><br><img width="550" height="310" alt="image" src="https://github.com/user-attachments/assets/b6572bc7-f89f-42cb-bb70-1af96d4f7bc5" />
    <br>
    
    - **`UIInventory`**<br><br><img width="550" height="310" alt="image" src="https://github.com/user-attachments/assets/1cc53b5d-76da-4a2c-bb02-30e63b6aeb46" />



  - 관련 스크립트 작성 (`UIManager` 연결 및 `Character` 클래스 포함)
  - **UI 간 전환 기능**
    - 버튼을 통해 각각의 UI on/off 가능<br><br><img width="550" height="310" src="https://github.com/user-attachments/assets/0e1a5927-4f72-4809-a357-b7703838985a" />
  - `UIStatus` 에 캐릭터 정보 세팅
  - **`UISlot` (인벤토리 아이템 슬롯) 동적 생성**
    | `UIInventory` 의 `Inspector` 뷰에서 `Slot Count` 설정 | 설정된 `Slot Count` 만큼 아이템 슬롯 생성됨 |
    |:---:|---|
    | <img width="210" height="240" alt="image" src="https://github.com/user-attachments/assets/b83161f2-97bd-4cfc-951e-d4b66d40d8d3" /> | <img width="549" height="311" alt="image" src="https://github.com/user-attachments/assets/32e3b5b4-f1db-439a-b332-127e4ee24558" /> |
    - `Scroll View` 를 통해, 생성 아이템 슬롯 개수가 많아도 대응 가능<br><br>![](https://github.com/user-attachments/assets/ce390518-b7ce-44e2-bbe4-25eb825db4ef)

  - `Item` 데이터 구현

<br>
    
### 도전 기능
  - **아이템 장착 기능 구현**
    - 장착한 아이템의 경우, 해당 아이템 슬롯 우측 하단에 `E` 텍스트가 표시되도록 구현<br><br>![](https://github.com/user-attachments/assets/d688050d-6b9e-4dce-a772-23b855b96ea9)

  - **장착 아이템 능력치 캐릭터 능력치에 반영**<br><br>![녹음 2025-11-28 132511](https://github.com/user-attachments/assets/7b1b63ab-a82b-4e94-8eb0-2be482b46fcc)

<br>
  
### 그 외
- **Sprite Atlas 를 활용한 UI 최적화**
  | `StatusAtlas` 적용 전 / `Draw Call=11` | `StatusAtlas` 적용 후 / `Draw Call=8` (-3) |
  |---|---|
  | <img width="550" height="310" alt="image" src="https://github.com/user-attachments/assets/21e0c9d2-86fa-4d30-bc94-595bdf69cd0b" /> | <img width="550" height="310" alt="image" src="https://github.com/user-attachments/assets/f2dd3dc7-57fd-4f1c-83e9-1b6406e47f28" /> |

  | `ItemAtlas` 적용 전 / `Draw Call=18` | `ItemAtlas` 적용 후 / `Draw Call=14` (-4) |
  |---|---|
  | <img width="550" height="310" alt="image" src="https://github.com/user-attachments/assets/3e5ffe6e-ab13-4aeb-b3b6-a5df11f0b21c" /> | <img width="550" height="310" alt="image" src="https://github.com/user-attachments/assets/0ff6de11-8fbd-4c5b-b3e0-8a705409f402" /> |

- `ScriptableObject` 를 활용한 `ItemData` 및 `ItemDatabase` 구현
  > **<참고 스크립트**<br>
  > [ItemData.cs](https://github.com/arara0250/nbc-w8-individual-inventory/blob/main/Assets/Data/ItemData.cs)<br>
  > [ItemDatabase.cs](https://github.com/arara0250/nbc-w8-individual-inventory/blob/main/Assets/Data/ItemDatabase.cs)

---
