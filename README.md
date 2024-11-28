# CommanderCS
some gacha game emu


## Status
"Urgent" to-dos

### Bugs

Getting kicked out of a guild while the game still thinks you are in one will make unable to continue playing (needs to restart the game) (client-sided issue)


### IMPORTANT

This is just a POC and its in WIP while it works somewhat it does has very limited usage and not everything works to 100% like its intend.



### How-To-Use

[Mongodb community database](https://www.mongodb.com/try/download/community)

Its for the database you pratically install it via all the pre selected settings iirc.

[Modified Client APK](https://www.mediafire.com/file/gp6x6c2gweggndh/com.edited.GK.apk/file)

it is the lastest Version GK had just modified so i can easier create this POC, if you have any trust issues with it, you can look at it via tools like dnSpy.

[Game OBB Data](https://www.mediafire.com/file/8cnyb7btjwk9qk0/com.flerogames.GK.rar/file)

This is just the games obb data works with any obb data for the lastest version.

[The ServerSides Files](https://www.mediafire.com/file/v03gsv3tfevkg12/FileCDN.rar/file)

These are just all server sides files you have to download so the game can be used.
 

### Setup

Download all these files above (may change in the future), install the mongodb community database, install the apk to your device or emulator (whatever you prefer), put the OBB file after unpacking it to its path, should be straightforward.

When you run the game for the first time it will not directly connect your server since it doesnt know the ip of it, however thats very easy to change as it should create a file called config.json in your Pictures folder on your device, locate the pre-input ip and replace it with your ip wherever your server is running.

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
