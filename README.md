# StellarGK
some gacha game emu


## Status
"Urgent" to-dos

### Bugs

Getting kicked out of a guild while the game still thinks you are in one will make unable to continue playing (needs to restart the game) (client-sided issue)



### How-To-Use

[You need to download mongodb community database for the database](https://www.mongodb.com/try/download/community)
[Modified Client APK (it is the lastest Version GK had, if you have any trust issues with it, you can look at it via tools like dnSpy)](https://www.mediafire.com/file/gp6x6c2gweggndh/com.edited.GK.apk/file)
[Game OBB Data](https://www.mediafire.com/file/8cnyb7btjwk9qk0/com.flerogames.GK.rar/file)
[The ServerSides Files for the game to download via starting up](https://www.mediafire.com/file/v03gsv3tfevkg12/FileCDN.rar/file)
 

### Progress

TLDR 
0 - 50% means not started or not finished 


* Achievement:

    * AchievementReward
    * AllAchievementReward
    * CompleteAchievement

* Annihilation:

    * AnnihilationEnemyInformation
    * AnnihilationMapInformation
    * AnnihilationStageStart
    * GetAnnihilationMapInfo
    * ResetAnnihilationStage
    * StartAnnihilation

* Battle:

    * BattleOut

* Carnival:

    * CarnivalBuyPackage
    * CarnivalComplete
    * CarnivalSelectItem
    * CheckBadge
    * GetCarnivalList

* Chat:

    * AddChatIgnore
    * DelChatIgnore
    * GetChatIgnoreList

* Commander:

    * BuyCommanderCostume
    * ChangeCommanderCostume
    * CommanderClassUp
    * CommanderDelayCancle
    * CommanderLevelUp
    * CommanderRankUp
    * CommanderRankUpImmediate
    * CommanderSkillLevelUp
    * CompleteCommanderScenario
    * ComposeWeaponBox
    * DecompositionWeapon
    * EquipWeapon
    * GetCommanderScenario
    * GetRecruitCommanderList
    * GetWeaponProgressHistory
    * RecieveCommanderScenarioReward
    * RecruitCommander
    * RecruitCommanderDelay
    * ReleaseWeapon
    * TradeWeaponUpgradeTicket
    * TranscendenceSkillUp
    * UpgradeWeapon
    * UpgradeWeaponInventory

* Conquest:

    * BuyConquestTroopSlot
    * ConquestJoin
    * DeleteConquestTroop
    * GetConquestBattle
    * GetConquestCurrentStateInfo
    * GetConquestInfo
    * GetConquestMovePath
    * GetConquestNotice
    * GetConquestRadar
    * GetConquestReplay
    * GetConquestStageInfo
    * GetConquestStageUserInfo
    * GetConquestTroop
    * SetConquestMoveTroop
    * SetConquestNotice
    * SetConquestTroop
    * StartConquestRadar

* Cooperate:

    * CooperateBattleComplete
    * CooperateBattleInfo
    * CooperateBattlePointGuildRank
    * CooperateBattlePointRank
    * CooperateBattleStart

* Defender:

    * DefenderSetting
    * GetDefenderInfo

* Dispatch:

    * DispatchAdvancedParty
    * DispatchCommander
    * GetDispatchCommanderList
    * GetDispatchCommanderListFromLogin
    * RecallDispatch

* Dormitory:

    * AddDormitoryFavorUser
    * ArrangeDormitoryCommander
    * ArrangeDormitoryDecoration
    * BuyDormitoryHeadCostume
    * BuyDormitoryShopProduct
    * ChangeDormitoryCommanderBody
    * ChangeDormitoryCommanderHead
    * ChangeDormitoryFloorName
    * ChangeDormitoryWallpaper
    * ConstructDormitoryFloor
    * EditDormitoryDecoration
    * FinishConstructDormitoryFloor
    * GetDormitoryCommanderInfo
    * GetDormitoryFavorUser
    * GetDormitoryFloorDetailInfo
    * GetDormitoryFloorInfo
    * GetDormitoryGuildUser
    * GetDormitoryInfo
    * GetDormitoryPoint
    * GetDormitoryPointAll
    * GetDormitoryShopProductList
    * GetDormitoryUserFloorDetailInfo
    * GetDormitoryUserFloorInfo
    * GetRecommendUser
    * RemoveDormitoryCommander
    * RemoveDormitoryDecoration
    * RemoveDormitoryFavorUser
    * SearchDormitoryUser
    * SellDormitoryItem

* Duel:

    * ReceiveDuelPointReward

* Event:

    * EventBattleGachaReset
    * EventBattleStart
    * EventRaidBattleStart
    * EventRaidData
    * EventRaidList
    * EventRaidRankingData
    * EventRaidShare
    * EventRaidSummon
    * GetCommentEventReward
    * GetCommonNotice
    * GetEventBattleData
    * GetEventBattleGachaInfo
    * GetEventBattleList
    * GetEventNotice
    * GetEventRaidReward
    * GetEventRemaingTime
    * GetEventRemainingTime
    * GetPlugEventInfo
    * GetPostEventReward
    * GetRotationBannerInfo
    * GetShutDownNotice
    * GetWebEvent
    * StartWebEvent

* Exploration:

    * ExplorationCancel
    * ExplorationComplete
    * ExplorationCompleteAll
    * ExplorationStart
    * ExplorationStartAll
    * GetExplorationList

* Gacha:

    * BankInfo
    * BankRoulletStart
    * BuyVipGacha
    * GachaInformation
    * GachaOpenBox
    * GachaRatingInformationType
    * GachaRatingInformationTypeB
    * GetBankReward
    * GetRotationBannerInfo
    * GetVipBuyCount
    * GetVipGachaInfo

* Gift:

    * DateModeGetGift
    * GetFavorReward
    * GetMarried
    * GiftFood
    * StartDateMode

* Guild:

    * ApplyGuildJoin
    * AppointSubMaster
    * ApproveGuildJoin
    * CancelGuildJoin
    * CreateGuild
    * DelegatingGuild
    * DeportGuildMember
    * FireSubMaster
    * FreeJoinGuild
    * GetGuildBoard
    * GetGuildRanking
    * GuildBoardDelete
    * GuildBoardWrite
    * GuildCloseDown
    * GuildDispatchCommanderList
    * GuildInfo
    * GuildList
    * GuildMemberList
    * LeaveGuild
    * ManageGuildJoinMember
    * RefuseGuildJoin
    * SearchGuild
    * UpdateGuildInfo
    * UpgradeGuildLevel
    * UpgradeGuildSkill

* InfinityBattle:

    * GetInfinityBattleDeck
    * InfinityBattleGetReward
    * InfinityBattleInformation
    * InfinityBattleStart
    * SaveInfinityBattleDeck
    * StartInfinityBattleScenario

* Inventory:

    * DecompositionItemEquipment
    * ExchangeMedal
    * GetGroupReward
    * GetWeaponProgressList
    * OpenItem
    * ReleaseItemEquipment
    * SellItem
    * SetItemEquipment
    * StartWeaponProgress
    * UpgradeItemEquipment
    * WeaponProgressBuyImmediateTicket
    * WeaponProgressFinish
    * WeaponProgressSlotOpen
    * WeaponProgressUseImmediateTicket

* KeepAlives:

    * BulletCharge
    * ChangeLanguage
    * CheckAlarm
    * CouponList
    * DailyBonusCheck
    * DailyBonusReceive
    * InputCoupon
    * ResourceRecharge
    * SetPushOnOff
    * UseTimeMachine
    * UseTimeMachineSweep

* Login:

    * FBSignIn
    * GoogleSignIn
    * GuestSignIn
    * GuestSignUp
    * Login
    * Logout
    * SignIn
    * SignUp

* Mail:

    * GetMailList
    * GetReward
    * GetRewardAll
    * ReadMail

* Mission:

    * AllMissionReward
    * CompleteMissionGoal
    * Mission
    * MissionReward

* Nickname:

    * ChangeNickname
    * SetNickNameFromTutorial

* Payment:

    * CheckPayment
    * CheckPaymentAmazon
    * CheckPaymentIOS
    * CheckPaymentOneStore
    * CheckPaymentTotalResult
    * GetFirstPaymentReward
    * MakeOrderId
    * RequestPayment

* PreDeck:

    * BuyPredeckSlot
    * PreDeckSetting

* Profile:

    * ChangeMemberShip
    * ChangeMembershipOpenPlatform
    * ChangeThumbnail
    * CheckOpenPlatformExist
    * GetUserInformation
    * UpdateTutorialStep

* PvP:

    * GetRankingReward
    * PvPDuelInfo
    * PvPDuelList
    * PvPRankingList
    * PvPStartDuel
    * PvPStartWaveDuel
    * PvPStartWorldDuel
    * PvPWaveDuelList
    * PvPWaveDuelRankingList
    * ReceivePvPReward
    * RefreshPvPDuelList
    * RefreshPvPWaveDuelList

* Raid:

    * GetRaidInfo
    * GetRaidRankList
    * RaidStart
    * ReceiveRaidReward

* Replay:

    * GetRecordList
    * GetReplayInfo
    * GetReplayList

* Server:

    * GetRegion
    * ServerStatus

* Shop:

    * BuySecretShopItem
    * GetBuyVipShop
    * GetCashShopList
    * GetSecretShopList
    * RefreshSecretShopList
    * ShopBuyGold

* Situation:

    * SituationInformation
    * SituationSweepStart

* SocketChatting:

    * CheckChattingMsg
    * SendChMsgChatting
    * SendGuildMsgChatting
    * SendwaitChannelMsg
    * SendWaitChatMsg
    * SendwaitGuildMsg
    * SendWhisperMsgChatting

* Troop:

    * ChangeTroopNickname
    * GetTroopInformation
    * UpdateTroopRole

* Tutorial:

    * GetTutorialStep
    * LoginTutorialSkip

* Unit:

    * GetUnitResearchList
    * UnitLevelUp
    * UnitLevelUpImmediate
    * UnitUpgrade

* UserTerm:

    * ChangeDevice
    * ChangeDeviceDbros
    * CheckChangeDeviceCode
    * GetBadWordList
    * GetChangeDeviceCode
    * UserTerm

* VersionCheck:

    * DatabaseVersionCheck
    * GameVersionInfo

* WorldDuel:
    * WorldDuelBuffSetting
    * WorldDuelBuffUpgrade
    * WorldDuelDefenderSetting
    * WorldDuelEnemyInfo
    * WorldDuelInformation

* WorldMap:
    * WorldMapInformation
    * WorldMapReward
    * WorldMapStageStart

## Credit

[Inso](https://github.com/insomnyawolf) For essenitaly creating this entire Project Rework +  helping me with more stuff.
