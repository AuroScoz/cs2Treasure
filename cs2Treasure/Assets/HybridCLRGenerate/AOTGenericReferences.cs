using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"Cinemachine.dll",
		"DOTween.dll",
		"FlutterUnityIntegration.dll",
		"LitJson.dll",
		"Loxodon.Framework.dll",
		"Realm.dll",
		"SerializableDictionary.dll",
		"System.Core.dll",
		"System.dll",
		"UniRx.dll",
		"UniTask.dll",
		"Unity.Addressables.dll",
		"Unity.Burst.dll",
		"Unity.Collections.dll",
		"Unity.Entities.Hybrid.dll",
		"Unity.Entities.dll",
		"Unity.RenderPipelines.Core.Runtime.dll",
		"Unity.ResourceManager.dll",
		"Unity.VisualScripting.Core.dll",
		"UnityEngine.AndroidJNIModule.dll",
		"UnityEngine.CoreModule.dll",
		"mscorlib.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<DBPlayer.<SetInMatchgameID>d__45>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<HeroFishing.Main.StartSceneUI.<InitPlayerData>d__27>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<HeroFishing.Socket.GameConnector.<ConnToMatchmaker>d__22>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<HeroFishing.Socket.GameConnector.<JoinMatchgame>d__29>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<HeroFishing.Socket.GameConnector.<OnLoginToMatchmakerError>d__24>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<HeroFishing.Socket.GameConnector.<SendRestfulAPI>d__10,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Scoz.Func.AddressablesLoader.<GetResourceByFullPath_Async>d__8<object>,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Scoz.Func.Poster.<Post>d__0,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Scoz.Func.UniTaskManager.<OneTimesTask>d__11>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Scoz.Func.UniTaskManager.<RepeatTask>d__9>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Service.Realms.RealmManager.<AnonymousSignup>d__17>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Service.Realms.RealmManager.<CallAtlasFunc_InitPlayerData>d__16,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Service.Realms.RealmManager.<GetProvider>d__20,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Service.Realms.RealmManager.<GetServerTime>d__22>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Service.Realms.RealmManager.<GetValidAccessToken>d__19,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Service.Realms.RealmManager.<OnSignin>d__21>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Service.Realms.RealmManager.<Signout>d__24>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Service.Realms.RealmManager.<Subscribe_Matchgame>d__35>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<DBPlayer.<SetInMatchgameID>d__45>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<HeroFishing.Main.StartSceneUI.<InitPlayerData>d__27>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<HeroFishing.Socket.GameConnector.<ConnToMatchmaker>d__22>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<HeroFishing.Socket.GameConnector.<JoinMatchgame>d__29>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<HeroFishing.Socket.GameConnector.<OnLoginToMatchmakerError>d__24>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<HeroFishing.Socket.GameConnector.<SendRestfulAPI>d__10,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Scoz.Func.AddressablesLoader.<GetResourceByFullPath_Async>d__8<object>,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Scoz.Func.Poster.<Post>d__0,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Scoz.Func.UniTaskManager.<OneTimesTask>d__11>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Scoz.Func.UniTaskManager.<RepeatTask>d__9>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Service.Realms.RealmManager.<AnonymousSignup>d__17>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Service.Realms.RealmManager.<CallAtlasFunc_InitPlayerData>d__16,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Service.Realms.RealmManager.<GetProvider>d__20,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Service.Realms.RealmManager.<GetServerTime>d__22>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Service.Realms.RealmManager.<GetValidAccessToken>d__19,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Service.Realms.RealmManager.<OnSignin>d__21>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Service.Realms.RealmManager.<Signout>d__24>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Service.Realms.RealmManager.<Subscribe_Matchgame>d__35>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid.<>c<HeroFishing.Main.LobbySceneUI.<>c__DisplayClass19_0.<<RealmLoginCheck>b__0>d>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid.<>c<HeroFishing.Main.StartSceneUI.<<AuthChek>b__21_0>d>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid.<>c<HeroFishing.Main.StartSceneUI.<>c__DisplayClass26_0.<<OnSignupClick>b__0>d>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid.<>c<Service.Realms.RealmManager.<>c__DisplayClass15_0.<<CallAtlasFuncNoneAsync>b__0>d>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid<HeroFishing.Main.LobbySceneUI.<>c__DisplayClass19_0.<<RealmLoginCheck>b__0>d>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid<HeroFishing.Main.StartSceneUI.<<AuthChek>b__21_0>d>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid<HeroFishing.Main.StartSceneUI.<>c__DisplayClass26_0.<<OnSignupClick>b__0>d>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid<Service.Realms.RealmManager.<>c__DisplayClass15_0.<<CallAtlasFuncNoneAsync>b__0>d>
	// Cysharp.Threading.Tasks.CompilerServices.IStateMachineRunnerPromise<object>
	// Cysharp.Threading.Tasks.ITaskPoolNode<object>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.IUniTaskSource<object>
	// Cysharp.Threading.Tasks.TaskPool<object>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<object>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<object>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<object>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.UniTask<object>
	// Cysharp.Threading.Tasks.UniTaskCompletionSource<object>
	// Cysharp.Threading.Tasks.UniTaskCompletionSourceCore<Cysharp.Threading.Tasks.AsyncUnit>
	// Cysharp.Threading.Tasks.UniTaskCompletionSourceCore<object>
	// Cysharp.Threading.Tasks.UniTaskExtensions.<>c__0<object>
	// DG.Tweening.Core.DOGetter<float>
	// DG.Tweening.Core.DOSetter<float>
	// DelegateList<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<long>>
	// DelegateList<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>>
	// DelegateList<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// DelegateList<float>
	// FlutterUnityIntegration.SingletonMonoBehaviour<object>
	// Loxodon.Framework.Observables.ObservableProperty<byte>
	// Loxodon.Framework.Observables.ObservablePropertyBase<byte>
	// Realms.CollectionExtensions.<>c__19<object>
	// Realms.IRealmCollection<object>
	// Realms.MarshaledVector.<ToEnumerable>d__7<Realms.NotifiableObjectHandleBase.CollectionChangeSet.Move>
	// Realms.MarshaledVector.<ToEnumerable>d__7<System.IntPtr>
	// Realms.MarshaledVector.Enumerator<Realms.NotifiableObjectHandleBase.CollectionChangeSet.Move>
	// Realms.MarshaledVector.Enumerator<System.IntPtr>
	// Realms.MarshaledVector<Realms.NotifiableObjectHandleBase.CollectionChangeSet.Move>
	// Realms.MarshaledVector<System.IntPtr>
	// Realms.Native.Arena.Buffer<Realms.NotifiableObjectHandleBase.CollectionChangeSet.Move>
	// Realms.Native.Arena.Buffer<System.IntPtr>
	// Realms.NotificationCallbackDelegate<object>
	// Realms.NotificationCallbacks.<>c<object>
	// Realms.NotificationCallbacks.<>c__DisplayClass3_0<object>
	// Realms.NotificationCallbacks<object>
	// Realms.RealmCollectionBase.<>c<object>
	// Realms.RealmCollectionBase.<>c__DisplayClass43_0<object>
	// Realms.RealmCollectionBase.<>c__DisplayClass48_0<object>
	// Realms.RealmCollectionBase.Enumerator<object>
	// Realms.RealmCollectionBase<object>
	// Realms.RealmList<object>
	// Realms.RealmResults<object>
	// SerializableDictionary<int,Scoz.Func.BloomSetting>
	// SerializableDictionary<int,object>
	// SerializableDictionary<object,object>
	// SerializableDictionaryBase<int,Scoz.Func.BloomSetting,Scoz.Func.BloomSetting>
	// SerializableDictionaryBase<int,object,object>
	// SerializableDictionaryBase<object,object,object>
	// System.Action<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Action<System.ValueTuple<object,object>>
	// System.Action<UniRx.TimeInterval<long>>
	// System.Action<UniRx.Unit>
	// System.Action<UniWebViewMessage>
	// System.Action<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,object>
	// System.Action<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<long>>
	// System.Action<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>>
	// System.Action<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Action<UnityEngine.UIVertex>
	// System.Action<UnityEngine.Vector3>
	// System.Action<byte>
	// System.Action<float>
	// System.Action<int,int>
	// System.Action<int>
	// System.Action<long>
	// System.Action<object,UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,int>
	// System.Action<object,UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Action<object,object>
	// System.Action<object>
	// System.Action<ushort>
	// System.ArraySegment.Enumerator<AutoDestroyTag>
	// System.ArraySegment.Enumerator<ChainHitData>
	// System.ArraySegment.Enumerator<HeroFishing.Battle.MapGridData>
	// System.ArraySegment.Enumerator<HeroFishing.Battle.RemoveMonsterBoundaryData>
	// System.ArraySegment.Enumerator<HitInfoBuffer>
	// System.ArraySegment.Enumerator<KillMonsterData>
	// System.ArraySegment.Enumerator<MonsterBuffer>
	// System.ArraySegment.Enumerator<MonsterData>
	// System.ArraySegment.Enumerator<MonsterFreezeTag>
	// System.ArraySegment.Enumerator<MonsterHitNetworkData>
	// System.ArraySegment.Enumerator<MonsterValue>
	// System.ArraySegment.Enumerator<MoveData>
	// System.ArraySegment.Enumerator<System.IntPtr>
	// System.ArraySegment.Enumerator<Unity.Entities.BakerDebugState.DebugState>
	// System.ArraySegment.Enumerator<Unity.Entities.BakerDebugState.EntityComponentPair>
	// System.ArraySegment.Enumerator<Unity.Entities.ComponentType>
	// System.ArraySegment.Enumerator<Unity.Entities.Entity>
	// System.ArraySegment.Enumerator<Unity.Entities.EntityQuery>
	// System.ArraySegment.Enumerator<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// System.ArraySegment.Enumerator<Unity.Entities.TypeIndex>
	// System.ArraySegment.Enumerator<Unity.Mathematics.int2>
	// System.ArraySegment.Enumerator<UnityEngine.jvalue>
	// System.ArraySegment.Enumerator<int>
	// System.ArraySegment.Enumerator<uint>
	// System.ArraySegment.Enumerator<ushort>
	// System.ArraySegment<AutoDestroyTag>
	// System.ArraySegment<ChainHitData>
	// System.ArraySegment<HeroFishing.Battle.MapGridData>
	// System.ArraySegment<HeroFishing.Battle.RemoveMonsterBoundaryData>
	// System.ArraySegment<HitInfoBuffer>
	// System.ArraySegment<KillMonsterData>
	// System.ArraySegment<MonsterBuffer>
	// System.ArraySegment<MonsterData>
	// System.ArraySegment<MonsterFreezeTag>
	// System.ArraySegment<MonsterHitNetworkData>
	// System.ArraySegment<MonsterValue>
	// System.ArraySegment<MoveData>
	// System.ArraySegment<System.IntPtr>
	// System.ArraySegment<Unity.Entities.BakerDebugState.DebugState>
	// System.ArraySegment<Unity.Entities.BakerDebugState.EntityComponentPair>
	// System.ArraySegment<Unity.Entities.ComponentType>
	// System.ArraySegment<Unity.Entities.Entity>
	// System.ArraySegment<Unity.Entities.EntityQuery>
	// System.ArraySegment<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// System.ArraySegment<Unity.Entities.TypeIndex>
	// System.ArraySegment<Unity.Mathematics.int2>
	// System.ArraySegment<UnityEngine.jvalue>
	// System.ArraySegment<int>
	// System.ArraySegment<uint>
	// System.ArraySegment<ushort>
	// System.ByReference<AutoDestroyTag>
	// System.ByReference<ChainHitData>
	// System.ByReference<HeroFishing.Battle.MapGridData>
	// System.ByReference<HeroFishing.Battle.RemoveMonsterBoundaryData>
	// System.ByReference<HitInfoBuffer>
	// System.ByReference<KillMonsterData>
	// System.ByReference<MonsterBuffer>
	// System.ByReference<MonsterData>
	// System.ByReference<MonsterFreezeTag>
	// System.ByReference<MonsterHitNetworkData>
	// System.ByReference<MonsterValue>
	// System.ByReference<MoveData>
	// System.ByReference<System.IntPtr>
	// System.ByReference<Unity.Entities.BakerDebugState.DebugState>
	// System.ByReference<Unity.Entities.BakerDebugState.EntityComponentPair>
	// System.ByReference<Unity.Entities.ComponentType>
	// System.ByReference<Unity.Entities.Entity>
	// System.ByReference<Unity.Entities.EntityQuery>
	// System.ByReference<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// System.ByReference<Unity.Entities.TypeIndex>
	// System.ByReference<Unity.Mathematics.int2>
	// System.ByReference<UnityEngine.jvalue>
	// System.ByReference<int>
	// System.ByReference<uint>
	// System.ByReference<ushort>
	// System.Collections.Concurrent.ConcurrentQueue.<Enumerate>d__28<object>
	// System.Collections.Concurrent.ConcurrentQueue.Segment<object>
	// System.Collections.Concurrent.ConcurrentQueue<object>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ArraySortHelper<System.ValueTuple<object,object>>
	// System.Collections.Generic.ArraySortHelper<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.ArraySortHelper<UnityEngine.UIVertex>
	// System.Collections.Generic.ArraySortHelper<UnityEngine.Vector3>
	// System.Collections.Generic.ArraySortHelper<byte>
	// System.Collections.Generic.ArraySortHelper<float>
	// System.Collections.Generic.ArraySortHelper<int>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.ArraySortHelper<ushort>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.Comparer<System.Nullable<int>>
	// System.Collections.Generic.Comparer<System.Numerics.BigInteger>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,object>>
	// System.Collections.Generic.Comparer<System.ValueTuple<object,object>>
	// System.Collections.Generic.Comparer<Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRW<MoveData>>
	// System.Collections.Generic.Comparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.Comparer<UnityEngine.UIVertex>
	// System.Collections.Generic.Comparer<UnityEngine.Vector3>
	// System.Collections.Generic.Comparer<byte>
	// System.Collections.Generic.Comparer<float>
	// System.Collections.Generic.Comparer<int>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Comparer<ushort>
	// System.Collections.Generic.Dictionary.Enumerator<int,Scoz.Func.BloomSetting>
	// System.Collections.Generic.Dictionary.Enumerator<int,System.ValueTuple<object,byte,object>>
	// System.Collections.Generic.Dictionary.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.Enumerator<object,System.DateTimeOffset>
	// System.Collections.Generic.Dictionary.Enumerator<object,byte>
	// System.Collections.Generic.Dictionary.Enumerator<object,float>
	// System.Collections.Generic.Dictionary.Enumerator<object,int>
	// System.Collections.Generic.Dictionary.Enumerator<object,long>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,Scoz.Func.BloomSetting>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,System.ValueTuple<object,byte,object>>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,System.DateTimeOffset>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,byte>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,float>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,int>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,long>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<int,Scoz.Func.BloomSetting>
	// System.Collections.Generic.Dictionary.KeyCollection<int,System.ValueTuple<object,byte,object>>
	// System.Collections.Generic.Dictionary.KeyCollection<int,int>
	// System.Collections.Generic.Dictionary.KeyCollection<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,System.DateTimeOffset>
	// System.Collections.Generic.Dictionary.KeyCollection<object,byte>
	// System.Collections.Generic.Dictionary.KeyCollection<object,float>
	// System.Collections.Generic.Dictionary.KeyCollection<object,int>
	// System.Collections.Generic.Dictionary.KeyCollection<object,long>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,Scoz.Func.BloomSetting>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,System.ValueTuple<object,byte,object>>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,System.DateTimeOffset>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,byte>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,float>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,int>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,long>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<int,Scoz.Func.BloomSetting>
	// System.Collections.Generic.Dictionary.ValueCollection<int,System.ValueTuple<object,byte,object>>
	// System.Collections.Generic.Dictionary.ValueCollection<int,int>
	// System.Collections.Generic.Dictionary.ValueCollection<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,System.DateTimeOffset>
	// System.Collections.Generic.Dictionary.ValueCollection<object,byte>
	// System.Collections.Generic.Dictionary.ValueCollection<object,float>
	// System.Collections.Generic.Dictionary.ValueCollection<object,int>
	// System.Collections.Generic.Dictionary.ValueCollection<object,long>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary<int,Scoz.Func.BloomSetting>
	// System.Collections.Generic.Dictionary<int,System.ValueTuple<object,byte,object>>
	// System.Collections.Generic.Dictionary<int,int>
	// System.Collections.Generic.Dictionary<int,object>
	// System.Collections.Generic.Dictionary<object,System.DateTimeOffset>
	// System.Collections.Generic.Dictionary<object,byte>
	// System.Collections.Generic.Dictionary<object,float>
	// System.Collections.Generic.Dictionary<object,int>
	// System.Collections.Generic.Dictionary<object,long>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.EqualityComparer<Scoz.Func.BloomSetting>
	// System.Collections.Generic.EqualityComparer<System.DateTimeOffset>
	// System.Collections.Generic.EqualityComparer<System.Numerics.BigInteger>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,object>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<object,byte,object>>
	// System.Collections.Generic.EqualityComparer<Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRW<MoveData>>
	// System.Collections.Generic.EqualityComparer<UnityEngine.Color>
	// System.Collections.Generic.EqualityComparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.EqualityComparer<byte>
	// System.Collections.Generic.EqualityComparer<float>
	// System.Collections.Generic.EqualityComparer<int>
	// System.Collections.Generic.EqualityComparer<long>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.HashSet.Enumerator<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.HashSet.Enumerator<int>
	// System.Collections.Generic.HashSet.Enumerator<object>
	// System.Collections.Generic.HashSet<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.HashSet<int>
	// System.Collections.Generic.HashSet<object>
	// System.Collections.Generic.HashSetEqualityComparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.HashSetEqualityComparer<int>
	// System.Collections.Generic.HashSetEqualityComparer<object>
	// System.Collections.Generic.ICollection<Realms.Schema.Property>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,Scoz.Func.BloomSetting>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,System.ValueTuple<object,byte,object>>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,Realms.Schema.Property>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,System.DateTimeOffset>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,byte>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,float>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,long>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<System.ValueTuple<object,object>>
	// System.Collections.Generic.ICollection<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.ICollection<UnityEngine.UIVertex>
	// System.Collections.Generic.ICollection<UnityEngine.Vector3>
	// System.Collections.Generic.ICollection<byte>
	// System.Collections.Generic.ICollection<float>
	// System.Collections.Generic.ICollection<int>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.ICollection<ushort>
	// System.Collections.Generic.IComparer<MonsterBuffer>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IComparer<System.Nullable<int>>
	// System.Collections.Generic.IComparer<System.ValueTuple<object,object>>
	// System.Collections.Generic.IComparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.IComparer<UnityEngine.UIVertex>
	// System.Collections.Generic.IComparer<UnityEngine.Vector3>
	// System.Collections.Generic.IComparer<byte>
	// System.Collections.Generic.IComparer<float>
	// System.Collections.Generic.IComparer<int>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IComparer<ushort>
	// System.Collections.Generic.IDictionary<object,LitJson.ArrayMetadata>
	// System.Collections.Generic.IDictionary<object,LitJson.ObjectMetadata>
	// System.Collections.Generic.IDictionary<object,LitJson.PropertyMetadata>
	// System.Collections.Generic.IDictionary<object,Realms.Schema.Property>
	// System.Collections.Generic.IDictionary<object,object>
	// System.Collections.Generic.IEnumerable<Realms.ChangeSet.Move>
	// System.Collections.Generic.IEnumerable<Realms.NotifiableObjectHandleBase.CollectionChangeSet.Move>
	// System.Collections.Generic.IEnumerable<Realms.Schema.Property>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,Scoz.Func.BloomSetting>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,System.ValueTuple<object,byte,object>>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,Realms.Schema.Property>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,System.DateTimeOffset>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,byte>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,float>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,long>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<System.IntPtr>
	// System.Collections.Generic.IEnumerable<System.ValueTuple<object,object>>
	// System.Collections.Generic.IEnumerable<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.IEnumerable<UnityEngine.UIVertex>
	// System.Collections.Generic.IEnumerable<UnityEngine.Vector3>
	// System.Collections.Generic.IEnumerable<byte>
	// System.Collections.Generic.IEnumerable<float>
	// System.Collections.Generic.IEnumerable<int>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerable<ushort>
	// System.Collections.Generic.IEnumerator<MonsterValue>
	// System.Collections.Generic.IEnumerator<Realms.ChangeSet.Move>
	// System.Collections.Generic.IEnumerator<Realms.NotifiableObjectHandleBase.CollectionChangeSet.Move>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,Scoz.Func.BloomSetting>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,System.ValueTuple<object,byte,object>>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,Realms.Schema.Property>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,System.DateTimeOffset>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,byte>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,float>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,long>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<System.IntPtr>
	// System.Collections.Generic.IEnumerator<System.ValueTuple<Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRW<MoveData>,object>>
	// System.Collections.Generic.IEnumerator<System.ValueTuple<object,object>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRO<MonsterValue>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<ChainHitData>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<HitParticleSpawnTag>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<LockMonsterData>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<MonsterDieNetworkData>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<MonsterValue>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<ParticleSpawnTag>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<SpawnData>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<SpellAreaData>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<SpellBulletData>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<SpellHitNetworkData>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<SpellHitTag>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRO<ChainHitData>>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRW<MonsterValue>,object>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<object,MonsterDieTag>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<object,MonsterHitTag>>
	// System.Collections.Generic.IEnumerator<Unity.Entities.QueryEnumerableWithEntity<object>>
	// System.Collections.Generic.IEnumerator<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.IEnumerator<UnityEngine.UIVertex>
	// System.Collections.Generic.IEnumerator<UnityEngine.Vector3>
	// System.Collections.Generic.IEnumerator<byte>
	// System.Collections.Generic.IEnumerator<float>
	// System.Collections.Generic.IEnumerator<int>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEnumerator<ushort>
	// System.Collections.Generic.IEqualityComparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.IEqualityComparer<int>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IList<System.ValueTuple<object,object>>
	// System.Collections.Generic.IList<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.IList<UnityEngine.UIVertex>
	// System.Collections.Generic.IList<UnityEngine.Vector3>
	// System.Collections.Generic.IList<byte>
	// System.Collections.Generic.IList<float>
	// System.Collections.Generic.IList<int>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.IList<ushort>
	// System.Collections.Generic.IReadOnlyCollection<Realms.NotifiableObjectHandleBase.CollectionChangeSet.Move>
	// System.Collections.Generic.IReadOnlyCollection<System.IntPtr>
	// System.Collections.Generic.IReadOnlyCollection<object>
	// System.Collections.Generic.IReadOnlyDictionary<object,System.IntPtr>
	// System.Collections.Generic.IReadOnlyList<object>
	// System.Collections.Generic.KeyValuePair<int,Scoz.Func.BloomSetting>
	// System.Collections.Generic.KeyValuePair<int,System.ValueTuple<object,byte,object>>
	// System.Collections.Generic.KeyValuePair<int,int>
	// System.Collections.Generic.KeyValuePair<int,object>
	// System.Collections.Generic.KeyValuePair<object,Realms.Schema.Property>
	// System.Collections.Generic.KeyValuePair<object,System.DateTimeOffset>
	// System.Collections.Generic.KeyValuePair<object,byte>
	// System.Collections.Generic.KeyValuePair<object,float>
	// System.Collections.Generic.KeyValuePair<object,int>
	// System.Collections.Generic.KeyValuePair<object,long>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.LinkedList.Enumerator<object>
	// System.Collections.Generic.LinkedList<object>
	// System.Collections.Generic.LinkedListNode<object>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.List.Enumerator<System.ValueTuple<object,object>>
	// System.Collections.Generic.List.Enumerator<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.List.Enumerator<UnityEngine.UIVertex>
	// System.Collections.Generic.List.Enumerator<UnityEngine.Vector3>
	// System.Collections.Generic.List.Enumerator<byte>
	// System.Collections.Generic.List.Enumerator<float>
	// System.Collections.Generic.List.Enumerator<int>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List.Enumerator<ushort>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.List<System.ValueTuple<object,object>>
	// System.Collections.Generic.List<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.List<UnityEngine.UIVertex>
	// System.Collections.Generic.List<UnityEngine.Vector3>
	// System.Collections.Generic.List<byte>
	// System.Collections.Generic.List<float>
	// System.Collections.Generic.List<int>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.List<ushort>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ObjectComparer<System.Nullable<int>>
	// System.Collections.Generic.ObjectComparer<System.Numerics.BigInteger>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,object>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<object,object>>
	// System.Collections.Generic.ObjectComparer<Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRW<MoveData>>
	// System.Collections.Generic.ObjectComparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.ObjectComparer<UnityEngine.UIVertex>
	// System.Collections.Generic.ObjectComparer<UnityEngine.Vector3>
	// System.Collections.Generic.ObjectComparer<byte>
	// System.Collections.Generic.ObjectComparer<float>
	// System.Collections.Generic.ObjectComparer<int>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectComparer<ushort>
	// System.Collections.Generic.ObjectEqualityComparer<Scoz.Func.BloomSetting>
	// System.Collections.Generic.ObjectEqualityComparer<System.DateTimeOffset>
	// System.Collections.Generic.ObjectEqualityComparer<System.Numerics.BigInteger>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,object>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<object,byte,object>>
	// System.Collections.Generic.ObjectEqualityComparer<Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRW<MoveData>>
	// System.Collections.Generic.ObjectEqualityComparer<UnityEngine.Color>
	// System.Collections.Generic.ObjectEqualityComparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.ObjectEqualityComparer<byte>
	// System.Collections.Generic.ObjectEqualityComparer<float>
	// System.Collections.Generic.ObjectEqualityComparer<int>
	// System.Collections.Generic.ObjectEqualityComparer<long>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.Generic.Queue.Enumerator<SpawnData>
	// System.Collections.Generic.Queue.Enumerator<object>
	// System.Collections.Generic.Queue<SpawnData>
	// System.Collections.Generic.Queue<object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_0<object,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_1<object,object>
	// System.Collections.Generic.SortedDictionary.Enumerator<object,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass5_0<object,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass6_0<object,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection<object,object>
	// System.Collections.Generic.SortedDictionary.KeyValuePairComparer<object,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass5_0<object,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass6_0<object,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection<object,object>
	// System.Collections.Generic.SortedDictionary<object,object>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass52_0<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass53_0<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet.Enumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet.Node<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet.<>c__DisplayClass9_0<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.Stack.Enumerator<object>
	// System.Collections.Generic.Stack<object>
	// System.Collections.Generic.TreeSet<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.TreeWalkPredicate<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.ValueTuple<object,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.ObjectModel.ReadOnlyCollection<UnityEngine.UIVertex>
	// System.Collections.ObjectModel.ReadOnlyCollection<UnityEngine.Vector3>
	// System.Collections.ObjectModel.ReadOnlyCollection<byte>
	// System.Collections.ObjectModel.ReadOnlyCollection<float>
	// System.Collections.ObjectModel.ReadOnlyCollection<int>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Collections.ObjectModel.ReadOnlyCollection<ushort>
	// System.Collections.ObjectModel.ReadOnlyDictionary.DictionaryEnumerator<object,Realms.Schema.Property>
	// System.Collections.ObjectModel.ReadOnlyDictionary.KeyCollection<object,Realms.Schema.Property>
	// System.Collections.ObjectModel.ReadOnlyDictionary.ValueCollection<object,Realms.Schema.Property>
	// System.Collections.ObjectModel.ReadOnlyDictionary<object,Realms.Schema.Property>
	// System.Comparison<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Comparison<System.ValueTuple<object,object>>
	// System.Comparison<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Comparison<UnityEngine.UIVertex>
	// System.Comparison<UnityEngine.Vector3>
	// System.Comparison<byte>
	// System.Comparison<float>
	// System.Comparison<int>
	// System.Comparison<object>
	// System.Comparison<ushort>
	// System.Converter<object,float>
	// System.Converter<object,int>
	// System.Converter<object,object>
	// System.Dynamic.Utils.CacheDict.Entry<object,object>
	// System.Dynamic.Utils.CacheDict<object,object>
	// System.Func<Cysharp.Threading.Tasks.UniTaskVoid>
	// System.Func<Realms.ChangeSet.Move,int>
	// System.Func<Realms.NotifiableObjectHandleBase.CollectionChangeSet.Move,Realms.ChangeSet.Move>
	// System.Func<System.Collections.Generic.KeyValuePair<int,object>,int>
	// System.Func<System.Collections.Generic.KeyValuePair<int,object>,object>
	// System.Func<System.Collections.Generic.KeyValuePair<object,int>,System.Collections.Generic.KeyValuePair<object,int>>
	// System.Func<System.Collections.Generic.KeyValuePair<object,int>,object>
	// System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>
	// System.Func<System.IntPtr,int>
	// System.Func<System.Threading.Tasks.VoidTaskResult>
	// System.Func<System.ValueTuple<object,byte,object>,object>
	// System.Func<UniRx.Unit,byte>
	// System.Func<UniRx.Unit,int,byte>
	// System.Func<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>>
	// System.Func<byte,byte>
	// System.Func<byte,ushort>
	// System.Func<byte>
	// System.Func<float,byte>
	// System.Func<int,object>
	// System.Func<int>
	// System.Func<long,byte>
	// System.Func<long,int,byte>
	// System.Func<long>
	// System.Func<object,System.Nullable<int>>
	// System.Func<object,System.Threading.Tasks.VoidTaskResult>
	// System.Func<object,byte>
	// System.Func<object,float>
	// System.Func<object,int,object>
	// System.Func<object,int>
	// System.Func<object,long>
	// System.Func<object,object,byte,object,object>
	// System.Func<object,object,object>
	// System.Func<object,object>
	// System.Func<object>
	// System.Func<ushort,byte>
	// System.IComparable<MonsterBuffer>
	// System.IEquatable<Unity.Entities.BakerDebugState.EntityComponentPair>
	// System.IEquatable<Unity.Entities.Entity>
	// System.IEquatable<Unity.Mathematics.int2>
	// System.IEquatable<uint>
	// System.IObservable<UniRx.TimeInterval<long>>
	// System.IObservable<UniRx.Unit>
	// System.IObservable<long>
	// System.IObservable<object>
	// System.IObserver<UniRx.TimeInterval<long>>
	// System.IObserver<UniRx.Unit>
	// System.IObserver<long>
	// System.IObserver<object>
	// System.Lazy<object>
	// System.Linq.Buffer<int>
	// System.Linq.Buffer<object>
	// System.Linq.Buffer<ushort>
	// System.Linq.Enumerable.<CastIterator>d__99<int>
	// System.Linq.Enumerable.<CastIterator>d__99<object>
	// System.Linq.Enumerable.<ConcatIterator>d__59<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Linq.Enumerable.<OfTypeIterator>d__97<object>
	// System.Linq.Enumerable.<SelectManyIterator>d__17<object,object>
	// System.Linq.Enumerable.Iterator<byte>
	// System.Linq.Enumerable.Iterator<float>
	// System.Linq.Enumerable.Iterator<object>
	// System.Linq.Enumerable.Iterator<ushort>
	// System.Linq.Enumerable.WhereEnumerableIterator<float>
	// System.Linq.Enumerable.WhereEnumerableIterator<ushort>
	// System.Linq.Enumerable.WhereSelectArrayIterator<byte,ushort>
	// System.Linq.Enumerable.WhereSelectArrayIterator<object,float>
	// System.Linq.Enumerable.WhereSelectEnumerableIterator<byte,ushort>
	// System.Linq.Enumerable.WhereSelectEnumerableIterator<object,float>
	// System.Linq.Enumerable.WhereSelectListIterator<byte,ushort>
	// System.Linq.Enumerable.WhereSelectListIterator<object,float>
	// System.Linq.EnumerableSorter<object,System.Nullable<int>>
	// System.Linq.EnumerableSorter<object,float>
	// System.Linq.EnumerableSorter<object>
	// System.Linq.GroupedEnumerable<System.Collections.Generic.KeyValuePair<object,int>,object,System.Collections.Generic.KeyValuePair<object,int>>
	// System.Linq.IGrouping<object,System.Collections.Generic.KeyValuePair<object,int>>
	// System.Linq.IdentityFunction.<>c<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Linq.IdentityFunction<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Linq.Lookup.<GetEnumerator>d__12<object,System.Collections.Generic.KeyValuePair<object,int>>
	// System.Linq.Lookup.Grouping.<GetEnumerator>d__7<object,System.Collections.Generic.KeyValuePair<object,int>>
	// System.Linq.Lookup.Grouping<object,System.Collections.Generic.KeyValuePair<object,int>>
	// System.Linq.Lookup<object,System.Collections.Generic.KeyValuePair<object,int>>
	// System.Linq.OrderedEnumerable.<GetEnumerator>d__1<object>
	// System.Linq.OrderedEnumerable<object,System.Nullable<int>>
	// System.Linq.OrderedEnumerable<object,float>
	// System.Linq.OrderedEnumerable<object>
	// System.Nullable<Realms.NotifiableObjectHandleBase.CollectionChangeSet>
	// System.Nullable<Realms.RealmValue.HandlesToCleanup>
	// System.Nullable<Realms.Schema.Property>
	// System.Nullable<System.DateTimeOffset>
	// System.Nullable<System.Threading.CancellationToken>
	// System.Nullable<System.TimeSpan>
	// System.Nullable<byte>
	// System.Nullable<float>
	// System.Nullable<int>
	// System.Nullable<long>
	// System.Predicate<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Predicate<System.ValueTuple<object,object>>
	// System.Predicate<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Predicate<UnityEngine.UIVertex>
	// System.Predicate<UnityEngine.Vector3>
	// System.Predicate<byte>
	// System.Predicate<float>
	// System.Predicate<int>
	// System.Predicate<object>
	// System.Predicate<ushort>
	// System.ReadOnlySpan.Enumerator<AutoDestroyTag>
	// System.ReadOnlySpan.Enumerator<ChainHitData>
	// System.ReadOnlySpan.Enumerator<HeroFishing.Battle.MapGridData>
	// System.ReadOnlySpan.Enumerator<HeroFishing.Battle.RemoveMonsterBoundaryData>
	// System.ReadOnlySpan.Enumerator<HitInfoBuffer>
	// System.ReadOnlySpan.Enumerator<KillMonsterData>
	// System.ReadOnlySpan.Enumerator<MonsterBuffer>
	// System.ReadOnlySpan.Enumerator<MonsterData>
	// System.ReadOnlySpan.Enumerator<MonsterFreezeTag>
	// System.ReadOnlySpan.Enumerator<MonsterHitNetworkData>
	// System.ReadOnlySpan.Enumerator<MonsterValue>
	// System.ReadOnlySpan.Enumerator<MoveData>
	// System.ReadOnlySpan.Enumerator<System.IntPtr>
	// System.ReadOnlySpan.Enumerator<Unity.Entities.BakerDebugState.DebugState>
	// System.ReadOnlySpan.Enumerator<Unity.Entities.BakerDebugState.EntityComponentPair>
	// System.ReadOnlySpan.Enumerator<Unity.Entities.ComponentType>
	// System.ReadOnlySpan.Enumerator<Unity.Entities.Entity>
	// System.ReadOnlySpan.Enumerator<Unity.Entities.EntityQuery>
	// System.ReadOnlySpan.Enumerator<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// System.ReadOnlySpan.Enumerator<Unity.Entities.TypeIndex>
	// System.ReadOnlySpan.Enumerator<Unity.Mathematics.int2>
	// System.ReadOnlySpan.Enumerator<UnityEngine.jvalue>
	// System.ReadOnlySpan.Enumerator<int>
	// System.ReadOnlySpan.Enumerator<uint>
	// System.ReadOnlySpan.Enumerator<ushort>
	// System.ReadOnlySpan<AutoDestroyTag>
	// System.ReadOnlySpan<ChainHitData>
	// System.ReadOnlySpan<HeroFishing.Battle.MapGridData>
	// System.ReadOnlySpan<HeroFishing.Battle.RemoveMonsterBoundaryData>
	// System.ReadOnlySpan<HitInfoBuffer>
	// System.ReadOnlySpan<KillMonsterData>
	// System.ReadOnlySpan<MonsterBuffer>
	// System.ReadOnlySpan<MonsterData>
	// System.ReadOnlySpan<MonsterFreezeTag>
	// System.ReadOnlySpan<MonsterHitNetworkData>
	// System.ReadOnlySpan<MonsterValue>
	// System.ReadOnlySpan<MoveData>
	// System.ReadOnlySpan<System.IntPtr>
	// System.ReadOnlySpan<Unity.Entities.BakerDebugState.DebugState>
	// System.ReadOnlySpan<Unity.Entities.BakerDebugState.EntityComponentPair>
	// System.ReadOnlySpan<Unity.Entities.ComponentType>
	// System.ReadOnlySpan<Unity.Entities.Entity>
	// System.ReadOnlySpan<Unity.Entities.EntityQuery>
	// System.ReadOnlySpan<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// System.ReadOnlySpan<Unity.Entities.TypeIndex>
	// System.ReadOnlySpan<Unity.Mathematics.int2>
	// System.ReadOnlySpan<UnityEngine.jvalue>
	// System.ReadOnlySpan<int>
	// System.ReadOnlySpan<uint>
	// System.ReadOnlySpan<ushort>
	// System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>
	// System.Runtime.CompilerServices.AsyncTaskMethodBuilder<byte>
	// System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>
	// System.Runtime.CompilerServices.ConditionalWeakTable.CreateValueCallback<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable.Enumerator<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable<object,object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<System.Threading.Tasks.VoidTaskResult>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<byte>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<long>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<System.Threading.Tasks.VoidTaskResult>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<byte>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<long>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<object>
	// System.Runtime.CompilerServices.ReadOnlyCollectionBuilder.Enumerator<object>
	// System.Runtime.CompilerServices.ReadOnlyCollectionBuilder<object>
	// System.Runtime.CompilerServices.TaskAwaiter<System.Threading.Tasks.VoidTaskResult>
	// System.Runtime.CompilerServices.TaskAwaiter<byte>
	// System.Runtime.CompilerServices.TaskAwaiter<long>
	// System.Runtime.CompilerServices.TaskAwaiter<object>
	// System.Runtime.CompilerServices.TrueReadOnlyCollection<object>
	// System.Span<AutoDestroyTag>
	// System.Span<ChainHitData>
	// System.Span<HeroFishing.Battle.MapGridData>
	// System.Span<HeroFishing.Battle.RemoveMonsterBoundaryData>
	// System.Span<HitInfoBuffer>
	// System.Span<KillMonsterData>
	// System.Span<MonsterBuffer>
	// System.Span<MonsterData>
	// System.Span<MonsterFreezeTag>
	// System.Span<MonsterHitNetworkData>
	// System.Span<MonsterValue>
	// System.Span<MoveData>
	// System.Span<System.IntPtr>
	// System.Span<Unity.Entities.BakerDebugState.DebugState>
	// System.Span<Unity.Entities.BakerDebugState.EntityComponentPair>
	// System.Span<Unity.Entities.ComponentType>
	// System.Span<Unity.Entities.Entity>
	// System.Span<Unity.Entities.EntityQuery>
	// System.Span<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// System.Span<Unity.Entities.TypeIndex>
	// System.Span<Unity.Mathematics.int2>
	// System.Span<UnityEngine.jvalue>
	// System.Span<int>
	// System.Span<uint>
	// System.Span<ushort>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<System.Threading.Tasks.VoidTaskResult>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<byte>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<long>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<object>
	// System.Threading.Tasks.Task<System.Threading.Tasks.VoidTaskResult>
	// System.Threading.Tasks.Task<byte>
	// System.Threading.Tasks.Task<long>
	// System.Threading.Tasks.Task<object>
	// System.Threading.Tasks.TaskCompletionSource<long>
	// System.Threading.Tasks.TaskCompletionSource<object>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<System.Threading.Tasks.VoidTaskResult>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<byte>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<long>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<object>
	// System.Threading.Tasks.TaskFactory<System.Threading.Tasks.VoidTaskResult>
	// System.Threading.Tasks.TaskFactory<byte>
	// System.Threading.Tasks.TaskFactory<long>
	// System.Threading.Tasks.TaskFactory<object>
	// System.Tuple<object,UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Tuple<object,int>
	// System.ValueTuple<System.Numerics.BigInteger,System.Numerics.BigInteger>
	// System.ValueTuple<Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRW<MoveData>,object>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,object>>
	// System.ValueTuple<byte,object>
	// System.ValueTuple<object,byte,object>
	// System.ValueTuple<object,object>
	// UniRx.InternalUtil.ImmutableList<object>
	// UniRx.InternalUtil.ListObserver<UniRx.Unit>
	// UniRx.InternalUtil.ListObserver<object>
	// UniRx.Observable.<RepeatInfinite>d__130<long>
	// UniRx.Observer.Subscribe<UniRx.TimeInterval<long>>
	// UniRx.Observer.Subscribe<UniRx.Unit>
	// UniRx.Observer.Subscribe<long>
	// UniRx.Observer.Subscribe<object>
	// UniRx.Observer.Subscribe_<UniRx.TimeInterval<long>>
	// UniRx.Observer.Subscribe_<UniRx.Unit>
	// UniRx.Observer.Subscribe_<long>
	// UniRx.Observer.Subscribe_<object>
	// UniRx.Operators.OperatorObservableBase.<>c__DisplayClass3_0<UniRx.TimeInterval<long>>
	// UniRx.Operators.OperatorObservableBase.<>c__DisplayClass3_0<UniRx.Unit>
	// UniRx.Operators.OperatorObservableBase.<>c__DisplayClass3_0<long>
	// UniRx.Operators.OperatorObservableBase<UniRx.TimeInterval<long>>
	// UniRx.Operators.OperatorObservableBase<UniRx.Unit>
	// UniRx.Operators.OperatorObservableBase<long>
	// UniRx.Operators.OperatorObserverBase<UniRx.Unit,UniRx.Unit>
	// UniRx.Operators.OperatorObserverBase<long,UniRx.TimeInterval<long>>
	// UniRx.Operators.OperatorObserverBase<long,long>
	// UniRx.Operators.RepeatUntilObservable.RepeatUntil.<SubscribeAfterEndOfFrame>d__13<long>
	// UniRx.Operators.RepeatUntilObservable.RepeatUntil<long>
	// UniRx.Operators.RepeatUntilObservable<long>
	// UniRx.Operators.SkipWhileObservable.SkipWhile<UniRx.Unit>
	// UniRx.Operators.SkipWhileObservable.SkipWhile<long>
	// UniRx.Operators.SkipWhileObservable.SkipWhile_<UniRx.Unit>
	// UniRx.Operators.SkipWhileObservable.SkipWhile_<long>
	// UniRx.Operators.SkipWhileObservable<UniRx.Unit>
	// UniRx.Operators.SkipWhileObservable<long>
	// UniRx.Operators.TakeUntilObservable.TakeUntil.TakeUntilOther<long,long>
	// UniRx.Operators.TakeUntilObservable.TakeUntil<long,long>
	// UniRx.Operators.TakeUntilObservable<long,long>
	// UniRx.Operators.TakeWhileObservable.TakeWhile<long>
	// UniRx.Operators.TakeWhileObservable.TakeWhile_<long>
	// UniRx.Operators.TakeWhileObservable<long>
	// UniRx.Operators.TimeIntervalObservable.TimeInterval<long>
	// UniRx.Operators.TimeIntervalObservable<long>
	// UniRx.Operators.TimeoutObservable.Timeout.<>c__DisplayClass8_0<UniRx.Unit>
	// UniRx.Operators.TimeoutObservable.Timeout<UniRx.Unit>
	// UniRx.Operators.TimeoutObservable.Timeout_<UniRx.Unit>
	// UniRx.Operators.TimeoutObservable<UniRx.Unit>
	// UniRx.Subject.Subscription<UniRx.Unit>
	// UniRx.Subject.Subscription<object>
	// UniRx.Subject<UniRx.Unit>
	// UniRx.Subject<object>
	// UniRx.TimeInterval<long>
	// Unity.Burst.SharedStatic<System.IntPtr>
	// Unity.Burst.SharedStatic<Unity.Collections.Long1024>
	// Unity.Burst.SharedStatic<Unity.Entities.TypeIndex>
	// Unity.Collections.LowLevel.Unsafe.HashMapHelper.Enumerator<Unity.Entities.Entity>
	// Unity.Collections.LowLevel.Unsafe.HashMapHelper.Enumerator<uint>
	// Unity.Collections.LowLevel.Unsafe.HashMapHelper<Unity.Entities.Entity>
	// Unity.Collections.LowLevel.Unsafe.HashMapHelper<uint>
	// Unity.Collections.LowLevel.Unsafe.UnsafeHashSet.ReadOnly<Unity.Entities.Entity>
	// Unity.Collections.LowLevel.Unsafe.UnsafeHashSet<Unity.Entities.Entity>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelReader<System.IntPtr>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelReader<Unity.Entities.ComponentType>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelReader<Unity.Entities.Entity>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelReader<Unity.Entities.EntityQuery>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelReader<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelReader<Unity.Entities.TypeIndex>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelReader<int>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelReader<ushort>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelWriter<System.IntPtr>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelWriter<Unity.Entities.ComponentType>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelWriter<Unity.Entities.Entity>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelWriter<Unity.Entities.EntityQuery>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelWriter<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelWriter<Unity.Entities.TypeIndex>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelWriter<int>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ParallelWriter<ushort>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ReadOnly<System.IntPtr>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ReadOnly<Unity.Entities.ComponentType>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ReadOnly<Unity.Entities.Entity>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ReadOnly<Unity.Entities.EntityQuery>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ReadOnly<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ReadOnly<Unity.Entities.TypeIndex>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ReadOnly<int>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList.ReadOnly<ushort>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList<System.IntPtr>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList<Unity.Entities.ComponentType>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList<Unity.Entities.Entity>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList<Unity.Entities.EntityQuery>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList<Unity.Entities.TypeIndex>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList<int>
	// Unity.Collections.LowLevel.Unsafe.UnsafeList<ushort>
	// Unity.Collections.LowLevel.Unsafe.UnsafeParallelHashMap.ReadOnly<Unity.Entities.BakerDebugState.EntityComponentPair,Unity.Entities.BakerDebugState.DebugState>
	// Unity.Collections.LowLevel.Unsafe.UnsafeParallelHashMap<Unity.Entities.BakerDebugState.EntityComponentPair,Unity.Entities.BakerDebugState.DebugState>
	// Unity.Collections.LowLevel.Unsafe.UnsafeParallelHashMapBase<Unity.Entities.BakerDebugState.EntityComponentPair,Unity.Entities.BakerDebugState.DebugState>
	// Unity.Collections.LowLevel.Unsafe.UnsafeParallelHashMapBase<Unity.Mathematics.int2,MonsterValue>
	// Unity.Collections.LowLevel.Unsafe.UnsafeParallelMultiHashMap.ReadOnly<Unity.Mathematics.int2,MonsterValue>
	// Unity.Collections.LowLevel.Unsafe.UnsafeParallelMultiHashMap<Unity.Mathematics.int2,MonsterValue>
	// Unity.Collections.LowLevel.Unsafe.UnsafePtrList.ParallelReader<Unity.Entities.Chunk>
	// Unity.Collections.LowLevel.Unsafe.UnsafePtrList.ParallelWriter<Unity.Entities.Chunk>
	// Unity.Collections.LowLevel.Unsafe.UnsafePtrList.ReadOnly<Unity.Entities.Chunk>
	// Unity.Collections.LowLevel.Unsafe.UnsafePtrList<Unity.Entities.Chunk>
	// Unity.Collections.NativeArray.Enumerator<AutoDestroyTag>
	// Unity.Collections.NativeArray.Enumerator<ChainHitData>
	// Unity.Collections.NativeArray.Enumerator<HeroFishing.Battle.MapGridData>
	// Unity.Collections.NativeArray.Enumerator<HeroFishing.Battle.RemoveMonsterBoundaryData>
	// Unity.Collections.NativeArray.Enumerator<HitInfoBuffer>
	// Unity.Collections.NativeArray.Enumerator<KillMonsterData>
	// Unity.Collections.NativeArray.Enumerator<MonsterBuffer>
	// Unity.Collections.NativeArray.Enumerator<MonsterData>
	// Unity.Collections.NativeArray.Enumerator<MonsterFreezeTag>
	// Unity.Collections.NativeArray.Enumerator<MonsterHitNetworkData>
	// Unity.Collections.NativeArray.Enumerator<MonsterValue>
	// Unity.Collections.NativeArray.Enumerator<MoveData>
	// Unity.Collections.NativeArray.Enumerator<System.IntPtr>
	// Unity.Collections.NativeArray.Enumerator<Unity.Entities.BakerDebugState.DebugState>
	// Unity.Collections.NativeArray.Enumerator<Unity.Entities.BakerDebugState.EntityComponentPair>
	// Unity.Collections.NativeArray.Enumerator<Unity.Entities.ComponentType>
	// Unity.Collections.NativeArray.Enumerator<Unity.Entities.Entity>
	// Unity.Collections.NativeArray.Enumerator<Unity.Entities.EntityQuery>
	// Unity.Collections.NativeArray.Enumerator<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// Unity.Collections.NativeArray.Enumerator<Unity.Entities.TypeIndex>
	// Unity.Collections.NativeArray.Enumerator<Unity.Mathematics.int2>
	// Unity.Collections.NativeArray.Enumerator<int>
	// Unity.Collections.NativeArray.Enumerator<uint>
	// Unity.Collections.NativeArray.Enumerator<ushort>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<AutoDestroyTag>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<ChainHitData>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<HeroFishing.Battle.MapGridData>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<HeroFishing.Battle.RemoveMonsterBoundaryData>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<HitInfoBuffer>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<KillMonsterData>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<MonsterBuffer>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<MonsterData>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<MonsterFreezeTag>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<MonsterHitNetworkData>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<MonsterValue>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<MoveData>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<System.IntPtr>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<Unity.Entities.BakerDebugState.DebugState>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<Unity.Entities.BakerDebugState.EntityComponentPair>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<Unity.Entities.ComponentType>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<Unity.Entities.Entity>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<Unity.Entities.EntityQuery>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<Unity.Entities.TypeIndex>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<Unity.Mathematics.int2>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<int>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<uint>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<ushort>
	// Unity.Collections.NativeArray.ReadOnly<AutoDestroyTag>
	// Unity.Collections.NativeArray.ReadOnly<ChainHitData>
	// Unity.Collections.NativeArray.ReadOnly<HeroFishing.Battle.MapGridData>
	// Unity.Collections.NativeArray.ReadOnly<HeroFishing.Battle.RemoveMonsterBoundaryData>
	// Unity.Collections.NativeArray.ReadOnly<HitInfoBuffer>
	// Unity.Collections.NativeArray.ReadOnly<KillMonsterData>
	// Unity.Collections.NativeArray.ReadOnly<MonsterBuffer>
	// Unity.Collections.NativeArray.ReadOnly<MonsterData>
	// Unity.Collections.NativeArray.ReadOnly<MonsterFreezeTag>
	// Unity.Collections.NativeArray.ReadOnly<MonsterHitNetworkData>
	// Unity.Collections.NativeArray.ReadOnly<MonsterValue>
	// Unity.Collections.NativeArray.ReadOnly<MoveData>
	// Unity.Collections.NativeArray.ReadOnly<System.IntPtr>
	// Unity.Collections.NativeArray.ReadOnly<Unity.Entities.BakerDebugState.DebugState>
	// Unity.Collections.NativeArray.ReadOnly<Unity.Entities.BakerDebugState.EntityComponentPair>
	// Unity.Collections.NativeArray.ReadOnly<Unity.Entities.ComponentType>
	// Unity.Collections.NativeArray.ReadOnly<Unity.Entities.Entity>
	// Unity.Collections.NativeArray.ReadOnly<Unity.Entities.EntityQuery>
	// Unity.Collections.NativeArray.ReadOnly<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// Unity.Collections.NativeArray.ReadOnly<Unity.Entities.TypeIndex>
	// Unity.Collections.NativeArray.ReadOnly<Unity.Mathematics.int2>
	// Unity.Collections.NativeArray.ReadOnly<int>
	// Unity.Collections.NativeArray.ReadOnly<uint>
	// Unity.Collections.NativeArray.ReadOnly<ushort>
	// Unity.Collections.NativeArray<AutoDestroyTag>
	// Unity.Collections.NativeArray<ChainHitData>
	// Unity.Collections.NativeArray<HeroFishing.Battle.MapGridData>
	// Unity.Collections.NativeArray<HeroFishing.Battle.RemoveMonsterBoundaryData>
	// Unity.Collections.NativeArray<HitInfoBuffer>
	// Unity.Collections.NativeArray<KillMonsterData>
	// Unity.Collections.NativeArray<MonsterBuffer>
	// Unity.Collections.NativeArray<MonsterData>
	// Unity.Collections.NativeArray<MonsterFreezeTag>
	// Unity.Collections.NativeArray<MonsterHitNetworkData>
	// Unity.Collections.NativeArray<MonsterValue>
	// Unity.Collections.NativeArray<MoveData>
	// Unity.Collections.NativeArray<System.IntPtr>
	// Unity.Collections.NativeArray<Unity.Entities.BakerDebugState.DebugState>
	// Unity.Collections.NativeArray<Unity.Entities.BakerDebugState.EntityComponentPair>
	// Unity.Collections.NativeArray<Unity.Entities.ComponentType>
	// Unity.Collections.NativeArray<Unity.Entities.Entity>
	// Unity.Collections.NativeArray<Unity.Entities.EntityQuery>
	// Unity.Collections.NativeArray<Unity.Entities.EntityQueryBuilder.QueryTypes>
	// Unity.Collections.NativeArray<Unity.Entities.TypeIndex>
	// Unity.Collections.NativeArray<Unity.Mathematics.int2>
	// Unity.Collections.NativeArray<int>
	// Unity.Collections.NativeArray<uint>
	// Unity.Collections.NativeArray<ushort>
	// Unity.Collections.NativeHashMap.ReadOnly<uint,Unity.Collections.NativeArray<ushort>>
	// Unity.Collections.NativeHashMap<uint,Unity.Collections.NativeArray<ushort>>
	// Unity.Collections.NativeKeyValueArrays<Unity.Entities.BakerDebugState.EntityComponentPair,Unity.Entities.BakerDebugState.DebugState>
	// Unity.Collections.NativeKeyValueArrays<Unity.Mathematics.int2,MonsterValue>
	// Unity.Collections.NativeList.ParallelWriter<Unity.Entities.Entity>
	// Unity.Collections.NativeList.ParallelWriter<ushort>
	// Unity.Collections.NativeList<Unity.Entities.Entity>
	// Unity.Collections.NativeList<ushort>
	// Unity.Collections.NativeParallelMultiHashMap.ReadOnly<Unity.Mathematics.int2,MonsterValue>
	// Unity.Collections.NativeParallelMultiHashMap<Unity.Mathematics.int2,MonsterValue>
	// Unity.Collections.NativeSlice.Enumerator<HitInfoBuffer>
	// Unity.Collections.NativeSlice.Enumerator<MonsterBuffer>
	// Unity.Collections.NativeSlice.Enumerator<MonsterHitNetworkData>
	// Unity.Collections.NativeSlice<HitInfoBuffer>
	// Unity.Collections.NativeSlice<MonsterBuffer>
	// Unity.Collections.NativeSlice<MonsterHitNetworkData>
	// Unity.Entities.Baker<object>
	// Unity.Entities.BufferLookup<HitInfoBuffer>
	// Unity.Entities.BufferLookup<MonsterBuffer>
	// Unity.Entities.BufferLookup<MonsterHitNetworkData>
	// Unity.Entities.ComponentLookup<AutoDestroyTag>
	// Unity.Entities.ComponentLookup<HeroFishing.Battle.MapGridData>
	// Unity.Entities.ComponentLookup<HeroFishing.Battle.RemoveMonsterBoundaryData>
	// Unity.Entities.ComponentLookup<MonsterFreezeTag>
	// Unity.Entities.ComponentLookup<MonsterValue>
	// Unity.Entities.ComponentTypeHandle<AreaCollisionData>
	// Unity.Entities.ComponentTypeHandle<AutoDestroyTag>
	// Unity.Entities.ComponentTypeHandle<BulletCollisionData>
	// Unity.Entities.ComponentTypeHandle<ChainHitData>
	// Unity.Entities.ComponentTypeHandle<HitParticleSpawnTag>
	// Unity.Entities.ComponentTypeHandle<LockMonsterData>
	// Unity.Entities.ComponentTypeHandle<MonsterDieNetworkData>
	// Unity.Entities.ComponentTypeHandle<MonsterDieTag>
	// Unity.Entities.ComponentTypeHandle<MonsterHitTag>
	// Unity.Entities.ComponentTypeHandle<MonsterValue>
	// Unity.Entities.ComponentTypeHandle<MoveData>
	// Unity.Entities.ComponentTypeHandle<ParticleSpawnTag>
	// Unity.Entities.ComponentTypeHandle<SpawnData>
	// Unity.Entities.ComponentTypeHandle<SpellAreaData>
	// Unity.Entities.ComponentTypeHandle<SpellBulletData>
	// Unity.Entities.ComponentTypeHandle<SpellHitNetworkData>
	// Unity.Entities.ComponentTypeHandle<SpellHitTag>
	// Unity.Entities.ComponentTypeHandle<object>
	// Unity.Entities.DynamicBuffer<HitInfoBuffer>
	// Unity.Entities.DynamicBuffer<MonsterBuffer>
	// Unity.Entities.DynamicBuffer<MonsterHitNetworkData>
	// Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRO<ChainHitData>
	// Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRO<MonsterValue>
	// Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRW<MonsterValue>
	// Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRW<MoveData>
	// Unity.Entities.JobChunkExtensions.JobChunkProducer.ExecuteJobFunction<AreaCollisionSystem.CollisionJob>
	// Unity.Entities.JobChunkExtensions.JobChunkProducer.ExecuteJobFunction<HeroFishing.Battle.AutoDestroySystem.DestroyJob>
	// Unity.Entities.JobChunkExtensions.JobChunkProducer.ExecuteJobFunction<HeroFishing.Battle.BulletCollisionSystem.MoveJob>
	// Unity.Entities.JobChunkExtensions.JobChunkProducer<AreaCollisionSystem.CollisionJob>
	// Unity.Entities.JobChunkExtensions.JobChunkProducer<HeroFishing.Battle.AutoDestroySystem.DestroyJob>
	// Unity.Entities.JobChunkExtensions.JobChunkProducer<HeroFishing.Battle.BulletCollisionSystem.MoveJob>
	// Unity.Entities.ManagedComponentAccessor<object>
	// Unity.Entities.QueryEnumerableWithEntity<ChainHitData>
	// Unity.Entities.QueryEnumerableWithEntity<HitParticleSpawnTag>
	// Unity.Entities.QueryEnumerableWithEntity<LockMonsterData>
	// Unity.Entities.QueryEnumerableWithEntity<MonsterDieNetworkData>
	// Unity.Entities.QueryEnumerableWithEntity<MonsterValue>
	// Unity.Entities.QueryEnumerableWithEntity<ParticleSpawnTag>
	// Unity.Entities.QueryEnumerableWithEntity<SpawnData>
	// Unity.Entities.QueryEnumerableWithEntity<SpellAreaData>
	// Unity.Entities.QueryEnumerableWithEntity<SpellBulletData>
	// Unity.Entities.QueryEnumerableWithEntity<SpellHitNetworkData>
	// Unity.Entities.QueryEnumerableWithEntity<SpellHitTag>
	// Unity.Entities.QueryEnumerableWithEntity<Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRO<ChainHitData>>
	// Unity.Entities.QueryEnumerableWithEntity<Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRW<MonsterValue>,object>
	// Unity.Entities.QueryEnumerableWithEntity<object,MonsterDieTag>
	// Unity.Entities.QueryEnumerableWithEntity<object,MonsterHitTag>
	// Unity.Entities.QueryEnumerableWithEntity<object>
	// Unity.Entities.RefRO<AutoDestroyTag>
	// Unity.Entities.RefRO<ChainHitData>
	// Unity.Entities.RefRO<HeroFishing.Battle.MapGridData>
	// Unity.Entities.RefRO<HeroFishing.Battle.RemoveMonsterBoundaryData>
	// Unity.Entities.RefRO<MonsterFreezeTag>
	// Unity.Entities.RefRO<MonsterValue>
	// Unity.Entities.RefRO<MoveData>
	// Unity.Entities.RefRW<AutoDestroyTag>
	// Unity.Entities.RefRW<HeroFishing.Battle.MapGridData>
	// Unity.Entities.RefRW<HeroFishing.Battle.RemoveMonsterBoundaryData>
	// Unity.Entities.RefRW<MonsterFreezeTag>
	// Unity.Entities.RefRW<MonsterValue>
	// Unity.Entities.RefRW<MoveData>
	// UnityEngine.AddressableAssets.AddressablesImpl.<>c__DisplayClass79_0<object>
	// UnityEngine.AddressableAssets.AddressablesImpl.<>c__DisplayClass88_0<object>
	// UnityEngine.AddressableAssets.AddressablesImpl.<>c__DisplayClass91_0<object>
	// UnityEngine.Events.InvokableCall<byte>
	// UnityEngine.Events.InvokableCall<object>
	// UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene,int>
	// UnityEngine.Events.UnityAction<byte>
	// UnityEngine.Events.UnityAction<object>
	// UnityEngine.Events.UnityEvent<byte>
	// UnityEngine.Events.UnityEvent<object>
	// UnityEngine.Rendering.VolumeParameter<UnityEngine.Color>
	// UnityEngine.Rendering.VolumeParameter<float>
	// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase.<>c__DisplayClass60_0<long>
	// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase.<>c__DisplayClass60_0<object>
	// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase.<>c__DisplayClass61_0<long>
	// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase.<>c__DisplayClass61_0<object>
	// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase<long>
	// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase<object>
	// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<long>
	// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>
	// UnityEngine.ResourceManagement.ChainOperationTypelessDepedency<object>
	// UnityEngine.ResourceManagement.ResourceManager.<>c__DisplayClass95_0<object>
	// UnityEngine.ResourceManagement.ResourceManager.CompletedOperation<object>
	// UnityEngine.ResourceManagement.Util.GlobalLinkedListNodeCache<object>
	// UnityEngine.ResourceManagement.Util.LinkedListNodeCache<object>
	// }}

	public void RefMethods()
	{
		// object Cinemachine.CinemachineVirtualCamera.GetCinemachineComponent<object>()
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,DBPlayer.<SetInMatchgameID>d__45>(Cysharp.Threading.Tasks.UniTask.Awaiter&,DBPlayer.<SetInMatchgameID>d__45&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Scoz.Func.UniTaskManager.<OneTimesTask>d__11>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Scoz.Func.UniTaskManager.<OneTimesTask>d__11&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Scoz.Func.UniTaskManager.<RepeatTask>d__9>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Scoz.Func.UniTaskManager.<RepeatTask>d__9&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Service.Realms.RealmManager.<AnonymousSignup>d__17>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Service.Realms.RealmManager.<AnonymousSignup>d__17&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Service.Realms.RealmManager.<OnSignin>d__21>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Service.Realms.RealmManager.<OnSignin>d__21&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,HeroFishing.Main.StartSceneUI.<InitPlayerData>d__27>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,HeroFishing.Main.StartSceneUI.<InitPlayerData>d__27&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,HeroFishing.Socket.GameConnector.<ConnToMatchmaker>d__22>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,HeroFishing.Socket.GameConnector.<ConnToMatchmaker>d__22&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,HeroFishing.Socket.GameConnector.<JoinMatchgame>d__29>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,HeroFishing.Socket.GameConnector.<JoinMatchgame>d__29&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,HeroFishing.Socket.GameConnector.<OnLoginToMatchmakerError>d__24>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,HeroFishing.Socket.GameConnector.<OnLoginToMatchmakerError>d__24&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,Service.Realms.RealmManager.<OnSignin>d__21>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,Service.Realms.RealmManager.<OnSignin>d__21&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,DBPlayer.<SetInMatchgameID>d__45>(System.Runtime.CompilerServices.TaskAwaiter&,DBPlayer.<SetInMatchgameID>d__45&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Service.Realms.RealmManager.<OnSignin>d__21>(System.Runtime.CompilerServices.TaskAwaiter&,Service.Realms.RealmManager.<OnSignin>d__21&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Service.Realms.RealmManager.<Signout>d__24>(System.Runtime.CompilerServices.TaskAwaiter&,Service.Realms.RealmManager.<Signout>d__24&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Service.Realms.RealmManager.<AnonymousSignup>d__17>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Service.Realms.RealmManager.<AnonymousSignup>d__17&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Service.Realms.RealmManager.<GetServerTime>d__22>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Service.Realms.RealmManager.<GetServerTime>d__22&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Service.Realms.RealmManager.<Subscribe_Matchgame>d__35>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Service.Realms.RealmManager.<Subscribe_Matchgame>d__35&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Scoz.Func.AddressablesLoader.<GetResourceByFullPath_Async>d__8<object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Scoz.Func.AddressablesLoader.<GetResourceByFullPath_Async>d__8<object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Service.Realms.RealmManager.<CallAtlasFunc_InitPlayerData>d__16>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Service.Realms.RealmManager.<CallAtlasFunc_InitPlayerData>d__16&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,HeroFishing.Socket.GameConnector.<SendRestfulAPI>d__10>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,HeroFishing.Socket.GameConnector.<SendRestfulAPI>d__10&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,Service.Realms.RealmManager.<CallAtlasFunc_InitPlayerData>d__16>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,Service.Realms.RealmManager.<CallAtlasFunc_InitPlayerData>d__16&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UnityAsyncExtensions.UnityWebRequestAsyncOperationAwaiter,Scoz.Func.Poster.<Post>d__0>(Cysharp.Threading.Tasks.UnityAsyncExtensions.UnityWebRequestAsyncOperationAwaiter&,Scoz.Func.Poster.<Post>d__0&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Service.Realms.RealmManager.<GetProvider>d__20>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Service.Realms.RealmManager.<GetProvider>d__20&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Service.Realms.RealmManager.<GetValidAccessToken>d__19>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Service.Realms.RealmManager.<GetValidAccessToken>d__19&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<DBPlayer.<SetInMatchgameID>d__45>(DBPlayer.<SetInMatchgameID>d__45&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<HeroFishing.Main.StartSceneUI.<InitPlayerData>d__27>(HeroFishing.Main.StartSceneUI.<InitPlayerData>d__27&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<HeroFishing.Socket.GameConnector.<ConnToMatchmaker>d__22>(HeroFishing.Socket.GameConnector.<ConnToMatchmaker>d__22&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<HeroFishing.Socket.GameConnector.<JoinMatchgame>d__29>(HeroFishing.Socket.GameConnector.<JoinMatchgame>d__29&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<HeroFishing.Socket.GameConnector.<OnLoginToMatchmakerError>d__24>(HeroFishing.Socket.GameConnector.<OnLoginToMatchmakerError>d__24&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Scoz.Func.UniTaskManager.<OneTimesTask>d__11>(Scoz.Func.UniTaskManager.<OneTimesTask>d__11&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Scoz.Func.UniTaskManager.<RepeatTask>d__9>(Scoz.Func.UniTaskManager.<RepeatTask>d__9&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Service.Realms.RealmManager.<AnonymousSignup>d__17>(Service.Realms.RealmManager.<AnonymousSignup>d__17&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Service.Realms.RealmManager.<GetServerTime>d__22>(Service.Realms.RealmManager.<GetServerTime>d__22&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Service.Realms.RealmManager.<OnSignin>d__21>(Service.Realms.RealmManager.<OnSignin>d__21&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Service.Realms.RealmManager.<Signout>d__24>(Service.Realms.RealmManager.<Signout>d__24&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Service.Realms.RealmManager.<Subscribe_Matchgame>d__35>(Service.Realms.RealmManager.<Subscribe_Matchgame>d__35&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.Start<HeroFishing.Socket.GameConnector.<SendRestfulAPI>d__10>(HeroFishing.Socket.GameConnector.<SendRestfulAPI>d__10&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.Start<Scoz.Func.AddressablesLoader.<GetResourceByFullPath_Async>d__8<object>>(Scoz.Func.AddressablesLoader.<GetResourceByFullPath_Async>d__8<object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.Start<Scoz.Func.Poster.<Post>d__0>(Scoz.Func.Poster.<Post>d__0&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.Start<Service.Realms.RealmManager.<CallAtlasFunc_InitPlayerData>d__16>(Service.Realms.RealmManager.<CallAtlasFunc_InitPlayerData>d__16&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.Start<Service.Realms.RealmManager.<GetProvider>d__20>(Service.Realms.RealmManager.<GetProvider>d__20&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.Start<Service.Realms.RealmManager.<GetValidAccessToken>d__19>(Service.Realms.RealmManager.<GetValidAccessToken>d__19&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,HeroFishing.Main.LobbySceneUI.<>c__DisplayClass19_0.<<RealmLoginCheck>b__0>d>(Cysharp.Threading.Tasks.UniTask.Awaiter&,HeroFishing.Main.LobbySceneUI.<>c__DisplayClass19_0.<<RealmLoginCheck>b__0>d&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,HeroFishing.Main.StartSceneUI.<<AuthChek>b__21_0>d>(Cysharp.Threading.Tasks.UniTask.Awaiter&,HeroFishing.Main.StartSceneUI.<<AuthChek>b__21_0>d&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,HeroFishing.Main.StartSceneUI.<>c__DisplayClass26_0.<<OnSignupClick>b__0>d>(Cysharp.Threading.Tasks.UniTask.Awaiter&,HeroFishing.Main.StartSceneUI.<>c__DisplayClass26_0.<<OnSignupClick>b__0>d&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Service.Realms.RealmManager.<>c__DisplayClass15_0.<<CallAtlasFuncNoneAsync>b__0>d>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Service.Realms.RealmManager.<>c__DisplayClass15_0.<<CallAtlasFuncNoneAsync>b__0>d&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoidMethodBuilder.Start<HeroFishing.Main.LobbySceneUI.<>c__DisplayClass19_0.<<RealmLoginCheck>b__0>d>(HeroFishing.Main.LobbySceneUI.<>c__DisplayClass19_0.<<RealmLoginCheck>b__0>d&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoidMethodBuilder.Start<HeroFishing.Main.StartSceneUI.<<AuthChek>b__21_0>d>(HeroFishing.Main.StartSceneUI.<<AuthChek>b__21_0>d&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoidMethodBuilder.Start<HeroFishing.Main.StartSceneUI.<>c__DisplayClass26_0.<<OnSignupClick>b__0>d>(HeroFishing.Main.StartSceneUI.<>c__DisplayClass26_0.<<OnSignupClick>b__0>d&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoidMethodBuilder.Start<Service.Realms.RealmManager.<>c__DisplayClass15_0.<<CallAtlasFuncNoneAsync>b__0>d>(Service.Realms.RealmManager.<>c__DisplayClass15_0.<<CallAtlasFuncNoneAsync>b__0>d&)
		// Cysharp.Threading.Tasks.UniTask<object> Cysharp.Threading.Tasks.UniTaskExtensions.AsUniTask<object>(System.Threading.Tasks.Task<object>,bool)
		// object LitJson.JsonMapper.ToObject<object>(string)
		// Realms.IRealmCollection<object> Realms.CollectionExtensions.AsRealmCollection<object>(System.Linq.IQueryable<object>)
		// System.Void Realms.CollectionExtensions.PopulateCollection<object>(System.Collections.Generic.ICollection<object>,System.Collections.Generic.ICollection<object>,bool,bool)
		// System.Void Realms.CollectionExtensions.PopulateCollectionCore<object>(System.Collections.Generic.ICollection<object>,System.Collections.Generic.ICollection<object>,bool,bool,System.Func<object,object>)
		// System.Threading.Tasks.Task<System.Linq.IQueryable<object>> Realms.CollectionExtensions.SubscribeAsync<object>(System.Linq.IQueryable<object>,Realms.Sync.SubscriptionOptions,Realms.Sync.WaitForSyncMode,System.Nullable<System.Threading.CancellationToken>)
		// System.IDisposable Realms.CollectionExtensions.SubscribeForNotifications<object>(System.Linq.IQueryable<object>,Realms.NotificationCallbackDelegate<object>)
		// object Realms.Helpers.Argument.EnsureType<object>(object,string,string)
		// System.Collections.Generic.IList<object> Realms.ManagedAccessor.GetListValue<object>(string)
		// Realms.RealmList<object> Realms.ObjectHandle.GetList<object>(Realms.Realm,string,Realms.Metadata,string)
		// object Realms.Realm.Add<object>(object,bool)
		// System.Void Realms.Realm.AddInternal<object>(object,System.Type,bool)
		// System.Linq.IQueryable<object> Realms.Realm.All<object>()
		// object Realms.Realm.Find<object>(string)
		// object Realms.Realm.FindCore<object>(Realms.RealmValue)
		// object Realms.RealmValue.AsRealmObject<object>()
		// Realms.Sync.Subscription Realms.Sync.SubscriptionSet.Add<object>(System.Linq.IQueryable<object>,Realms.Sync.SubscriptionOptions)
		// System.Threading.Tasks.Task<object> Realms.Sync.User.FunctionsClient.CallAsync<object>(string,object[])
		// System.Threading.Tasks.Task<object> Realms.Sync.User.FunctionsClient.CallSerializedAsync<object>(string,string,string)
		// object System.Activator.CreateInstance<object>()
		// float[] System.Array.ConvertAll<object,float>(object[],System.Converter<object,float>)
		// int[] System.Array.ConvertAll<object,int>(object[],System.Converter<object,int>)
		// object[] System.Array.ConvertAll<object,object>(object[],System.Converter<object,object>)
		// object[] System.Array.Empty<object>()
		// bool System.Array.Exists<object>(object[],System.Predicate<object>)
		// int System.Array.FindIndex<object>(object[],System.Predicate<object>)
		// int System.Array.FindIndex<object>(object[],int,int,System.Predicate<object>)
		// int System.Array.IndexOf<object>(object[],object)
		// int System.Array.IndexOfImpl<object>(object[],object,int,int)
		// System.Void System.Array.Resize<object>(object[]&,int)
		// System.Collections.Generic.List<object> System.Collections.Generic.List<object>.ConvertAll<object>(System.Converter<object,object>)
		// System.Collections.ObjectModel.ReadOnlyCollection<object> System.Dynamic.Utils.CollectionExtensions.ToReadOnly<object>(System.Collections.Generic.IEnumerable<object>)
		// bool System.Enum.TryParse<int>(string,bool,int&)
		// bool System.Enum.TryParse<int>(string,int&)
		// bool System.Enum.TryParse<object>(string,bool,object&)
		// bool System.Enum.TryParse<object>(string,object&)
		// System.Collections.Generic.IEnumerable<int> System.Linq.Enumerable.Cast<int>(System.Collections.IEnumerable)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Cast<object>(System.Collections.IEnumerable)
		// System.Collections.Generic.IEnumerable<int> System.Linq.Enumerable.CastIterator<int>(System.Collections.IEnumerable)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.CastIterator<object>(System.Collections.IEnumerable)
		// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>> System.Linq.Enumerable.Concat<System.Collections.Generic.KeyValuePair<object,int>>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>,System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>)
		// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>> System.Linq.Enumerable.ConcatIterator<System.Collections.Generic.KeyValuePair<object,int>>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>,System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>)
		// int System.Linq.Enumerable.Count<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.KeyValuePair<object,int> System.Linq.Enumerable.First<System.Collections.Generic.KeyValuePair<object,int>>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>)
		// System.Collections.Generic.KeyValuePair<object,object> System.Linq.Enumerable.First<System.Collections.Generic.KeyValuePair<object,object>>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle System.Linq.Enumerable.First<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>(System.Collections.Generic.IEnumerable<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)
		// object System.Linq.Enumerable.First<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<System.Linq.IGrouping<object,System.Collections.Generic.KeyValuePair<object,int>>> System.Linq.Enumerable.GroupBy<System.Collections.Generic.KeyValuePair<object,int>,object>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>,System.Func<System.Collections.Generic.KeyValuePair<object,int>,object>)
		// System.Collections.Generic.KeyValuePair<object,int> System.Linq.Enumerable.Last<System.Collections.Generic.KeyValuePair<object,int>>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>)
		// object System.Linq.Enumerable.Last<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.OfType<object>(System.Collections.IEnumerable)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.OfTypeIterator<object>(System.Collections.IEnumerable)
		// System.Linq.IOrderedEnumerable<object> System.Linq.Enumerable.OrderBy<object,float>(System.Collections.Generic.IEnumerable<object>,System.Func<object,float>)
		// System.Linq.IOrderedEnumerable<object> System.Linq.Enumerable.OrderByDescending<object,System.Nullable<int>>(System.Collections.Generic.IEnumerable<object>,System.Func<object,System.Nullable<int>>)
		// System.Collections.Generic.IEnumerable<float> System.Linq.Enumerable.Select<object,float>(System.Collections.Generic.IEnumerable<object>,System.Func<object,float>)
		// System.Collections.Generic.IEnumerable<ushort> System.Linq.Enumerable.Select<byte,ushort>(System.Collections.Generic.IEnumerable<byte>,System.Func<byte,ushort>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.SelectMany<object,object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,System.Collections.Generic.IEnumerable<object>>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.SelectManyIterator<object,object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,System.Collections.Generic.IEnumerable<object>>)
		// int[] System.Linq.Enumerable.ToArray<int>(System.Collections.Generic.IEnumerable<int>)
		// object[] System.Linq.Enumerable.ToArray<object>(System.Collections.Generic.IEnumerable<object>)
		// ushort[] System.Linq.Enumerable.ToArray<ushort>(System.Collections.Generic.IEnumerable<ushort>)
		// System.Collections.Generic.Dictionary<int,object> System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<int,object>,int,object>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>,System.Func<System.Collections.Generic.KeyValuePair<int,object>,int>,System.Func<System.Collections.Generic.KeyValuePair<int,object>,object>)
		// System.Collections.Generic.Dictionary<int,object> System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<int,object>,int,object>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>,System.Func<System.Collections.Generic.KeyValuePair<int,object>,int>,System.Func<System.Collections.Generic.KeyValuePair<int,object>,object>,System.Collections.Generic.IEqualityComparer<int>)
		// System.Collections.Generic.Dictionary<object,int> System.Linq.Enumerable.ToDictionary<object,object,int>(System.Collections.Generic.IEnumerable<object>,System.Func<object,object>,System.Func<object,int>)
		// System.Collections.Generic.Dictionary<object,int> System.Linq.Enumerable.ToDictionary<object,object,int>(System.Collections.Generic.IEnumerable<object>,System.Func<object,object>,System.Func<object,int>,System.Collections.Generic.IEqualityComparer<object>)
		// System.Collections.Generic.Dictionary<object,object> System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<object,object>,object,object>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>,System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>,System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>)
		// System.Collections.Generic.Dictionary<object,object> System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<object,object>,object,object>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>,System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>,System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>,System.Collections.Generic.IEqualityComparer<object>)
		// System.Collections.Generic.HashSet<int> System.Linq.Enumerable.ToHashSet<int>(System.Collections.Generic.IEnumerable<int>)
		// System.Collections.Generic.HashSet<int> System.Linq.Enumerable.ToHashSet<int>(System.Collections.Generic.IEnumerable<int>,System.Collections.Generic.IEqualityComparer<int>)
		// System.Collections.Generic.HashSet<object> System.Linq.Enumerable.ToHashSet<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.HashSet<object> System.Linq.Enumerable.ToHashSet<object>(System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEqualityComparer<object>)
		// System.Collections.Generic.List<float> System.Linq.Enumerable.ToList<float>(System.Collections.Generic.IEnumerable<float>)
		// System.Collections.Generic.List<int> System.Linq.Enumerable.ToList<int>(System.Collections.Generic.IEnumerable<int>)
		// System.Collections.Generic.List<object> System.Linq.Enumerable.ToList<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<float> System.Linq.Enumerable.Iterator<object>.Select<float>(System.Func<object,float>)
		// System.Collections.Generic.IEnumerable<ushort> System.Linq.Enumerable.Iterator<byte>.Select<ushort>(System.Func<byte,ushort>)
		// System.Linq.Expressions.Expression<object> System.Linq.Expressions.Expression.Lambda<object>(System.Linq.Expressions.Expression,System.Linq.Expressions.ParameterExpression[])
		// System.Linq.Expressions.Expression<object> System.Linq.Expressions.Expression.Lambda<object>(System.Linq.Expressions.Expression,bool,System.Collections.Generic.IEnumerable<System.Linq.Expressions.ParameterExpression>)
		// System.Linq.Expressions.Expression<object> System.Linq.Expressions.Expression.Lambda<object>(System.Linq.Expressions.Expression,string,bool,System.Collections.Generic.IEnumerable<System.Linq.Expressions.ParameterExpression>)
		// System.Linq.IQueryable<object> System.Linq.IQueryProvider.CreateQuery<object>(System.Linq.Expressions.Expression)
		// int System.Linq.IQueryProvider.Execute<int>(System.Linq.Expressions.Expression)
		// object System.Linq.IQueryProvider.Execute<object>(System.Linq.Expressions.Expression)
		// int System.Linq.Queryable.Count<object>(System.Linq.IQueryable<object>)
		// object System.Linq.Queryable.ElementAt<object>(System.Linq.IQueryable<object>,int)
		// System.Linq.IQueryable<object> System.Linq.Queryable.Where<object>(System.Linq.IQueryable<object>,System.Linq.Expressions.Expression<System.Func<object,bool>>)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Service.Realms.RealmManager.<SetupConfig>d__23>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Service.Realms.RealmManager.<SetupConfig>d__23&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Service.Realms.RealmManager.<SetupConfig>d__23>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Service.Realms.RealmManager.<SetupConfig>d__23&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,SpellLevelUI.<Upgrade>d__18>(System.Runtime.CompilerServices.TaskAwaiter&,SpellLevelUI.<Upgrade>d__18&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Service.Realms.RealmManager.<CallAtlasFunc>d__14>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Service.Realms.RealmManager.<CallAtlasFunc>d__14&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Service.Realms.RealmManager.<SetupConfig>d__23>(Service.Realms.RealmManager.<SetupConfig>d__23&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<byte>.Start<SpellLevelUI.<Upgrade>d__18>(SpellLevelUI.<Upgrade>d__18&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Realms.CollectionExtensions.<SubscribeAsync>d__18<object>>(Realms.CollectionExtensions.<SubscribeAsync>d__18<object>&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Realms.Sync.User.FunctionsClient.<CallSerializedAsync>d__4<object>>(Realms.Sync.User.FunctionsClient.<CallSerializedAsync>d__4<object>&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Service.Realms.RealmManager.<CallAtlasFunc>d__14>(Service.Realms.RealmManager.<CallAtlasFunc>d__14&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,AutoBackPool.<OnEnable>d__2>(Cysharp.Threading.Tasks.UniTask.Awaiter&,AutoBackPool.<OnEnable>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,BulletInstance.<Dispose>d__3>(Cysharp.Threading.Tasks.UniTask.Awaiter&,BulletInstance.<Dispose>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,HeroFishing.Socket.TcpClient.<Thread_Connect>d__37>(Cysharp.Threading.Tasks.UniTask.Awaiter&,HeroFishing.Socket.TcpClient.<Thread_Connect>d__37&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Service.Realms.RealmManager.<EmailPWSignup>d__18>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Service.Realms.RealmManager.<EmailPWSignup>d__18&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,SpellActivationBehaviour.<OnSpellPlay>d__2>(Cysharp.Threading.Tasks.UniTask.Awaiter&,SpellActivationBehaviour.<OnSpellPlay>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,SpellShakeCamera.<Play>d__6>(Cysharp.Threading.Tasks.UniTask.Awaiter&,SpellShakeCamera.<Play>d__6&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<byte>,SpellBtn.<Upgrade>d__32>(System.Runtime.CompilerServices.TaskAwaiter<byte>&,SpellBtn.<Upgrade>d__32&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Service.Realms.RealmManager.<EmailPWSignup>d__18>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Service.Realms.RealmManager.<EmailPWSignup>d__18&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<AutoBackPool.<OnEnable>d__2>(AutoBackPool.<OnEnable>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<BulletInstance.<Dispose>d__3>(BulletInstance.<Dispose>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<HeroFishing.Socket.TcpClient.<Thread_Connect>d__37>(HeroFishing.Socket.TcpClient.<Thread_Connect>d__37&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<Service.Realms.RealmManager.<EmailPWSignup>d__18>(Service.Realms.RealmManager.<EmailPWSignup>d__18&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<SpellActivationBehaviour.<OnSpellPlay>d__2>(SpellActivationBehaviour.<OnSpellPlay>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<SpellBtn.<Upgrade>d__32>(SpellBtn.<Upgrade>d__32&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<SpellShakeCamera.<Play>d__6>(SpellShakeCamera.<Play>d__6&)
		// object& System.Runtime.CompilerServices.Unsafe.As<object,object>(object&)
		// System.Void* System.Runtime.CompilerServices.Unsafe.AsPointer<object>(object&)
		// object System.Threading.Interlocked.CompareExchange<object>(object&,object,object)
		// System.Collections.Generic.IEnumerable<System.IObservable<long>> UniRx.Observable.RepeatInfinite<long>(System.IObservable<long>)
		// System.IObservable<long> UniRx.Observable.RepeatUntilCore<long>(System.Collections.Generic.IEnumerable<System.IObservable<long>>,System.IObservable<UniRx.Unit>,UnityEngine.GameObject)
		// System.IObservable<long> UniRx.Observable.RepeatUntilDestroy<long>(System.IObservable<long>,UnityEngine.GameObject)
		// System.IObservable<UniRx.Unit> UniRx.Observable.SkipWhile<UniRx.Unit>(System.IObservable<UniRx.Unit>,System.Func<UniRx.Unit,bool>)
		// System.IObservable<long> UniRx.Observable.SkipWhile<long>(System.IObservable<long>,System.Func<long,bool>)
		// System.IObservable<long> UniRx.Observable.TakeUntil<long,long>(System.IObservable<long>,System.IObservable<long>)
		// System.IObservable<long> UniRx.Observable.TakeWhile<long>(System.IObservable<long>,System.Func<long,bool>)
		// System.IObservable<UniRx.TimeInterval<long>> UniRx.Observable.TimeInterval<long>(System.IObservable<long>)
		// System.IObservable<UniRx.TimeInterval<long>> UniRx.Observable.TimeInterval<long>(System.IObservable<long>,UniRx.IScheduler)
		// System.IObservable<UniRx.Unit> UniRx.Observable.Timeout<UniRx.Unit>(System.IObservable<UniRx.Unit>,System.TimeSpan)
		// System.IObservable<UniRx.Unit> UniRx.Observable.Timeout<UniRx.Unit>(System.IObservable<UniRx.Unit>,System.TimeSpan,UniRx.IScheduler)
		// System.IDisposable UniRx.ObservableExtensions.Subscribe<UniRx.TimeInterval<long>>(System.IObservable<UniRx.TimeInterval<long>>,System.Action<UniRx.TimeInterval<long>>,System.Action)
		// System.IDisposable UniRx.ObservableExtensions.Subscribe<UniRx.Unit>(System.IObservable<UniRx.Unit>,System.Action<UniRx.Unit>,System.Action<System.Exception>)
		// System.IDisposable UniRx.ObservableExtensions.Subscribe<long>(System.IObservable<long>,System.Action<long>)
		// System.IDisposable UniRx.ObservableExtensions.Subscribe<object>(System.IObservable<object>,System.Action<object>,System.Action<System.Exception>)
		// System.IObserver<UniRx.TimeInterval<long>> UniRx.Observer.CreateSubscribeObserver<UniRx.TimeInterval<long>>(System.Action<UniRx.TimeInterval<long>>,System.Action<System.Exception>,System.Action)
		// System.IObserver<UniRx.Unit> UniRx.Observer.CreateSubscribeObserver<UniRx.Unit>(System.Action<UniRx.Unit>,System.Action<System.Exception>,System.Action)
		// System.IObserver<long> UniRx.Observer.CreateSubscribeObserver<long>(System.Action<long>,System.Action<System.Exception>,System.Action)
		// System.IObserver<object> UniRx.Observer.CreateSubscribeObserver<object>(System.Action<object>,System.Action<System.Exception>,System.Action)
		// long Unity.Burst.BurstRuntime.GetHashCode64<AreaCollisionSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<ChainHitSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<ClearAllEntitySystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<DirectoryInitSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<HeroFishing.Battle.AutoDestroySystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<HeroFishing.Battle.BulletCollisionSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<HeroFishing.Battle.BulletMoveSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<HeroFishing.Battle.BulletSpawnSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<HeroFishing.Battle.EffectSpawnSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<HeroFishing.Battle.MonsterBehaviourSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<HeroFishing.Battle.MonsterDieSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<HeroFishing.Battle.MonsterHitSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<HeroFishing.Battle.MonsterSpawnSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<HeroFishing.Battle.SpellEffectSpawnSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<HitNetworkSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<LockMonsterSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<MonsterDieNetworkSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<MonsterFreezeSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<RefreshSceneSystem>()
		// long Unity.Burst.BurstRuntime.GetHashCode64<SpellHitSystem>()
		// System.Void* Unity.Collections.AllocatorManager.Allocate<Unity.Collections.AllocatorManager.AllocatorHandle>(Unity.Collections.AllocatorManager.AllocatorHandle&,int,int,int)
		// Unity.Collections.AllocatorManager.Block Unity.Collections.AllocatorManager.AllocateBlock<Unity.Collections.AllocatorManager.AllocatorHandle>(Unity.Collections.AllocatorManager.AllocatorHandle&,int,int,int)
		// System.Void* Unity.Collections.AllocatorManager.AllocateStruct<Unity.Collections.AllocatorManager.AllocatorHandle,MonsterValue>(Unity.Collections.AllocatorManager.AllocatorHandle&,MonsterValue,int)
		// Unity.Collections.NativeArray<MonsterValue> Unity.Collections.CollectionHelper.CreateNativeArray<MonsterValue>(int,Unity.Collections.AllocatorManager.AllocatorHandle,Unity.Collections.NativeArrayOptions)
		// Unity.Collections.NativeArray<int> Unity.Collections.LowLevel.Unsafe.NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<int>(System.Void*,int,Unity.Collections.Allocator)
		// System.Void* Unity.Collections.LowLevel.Unsafe.NativeArrayUnsafeUtility.GetUnsafePtr<MonsterBuffer>(Unity.Collections.NativeArray<MonsterBuffer>)
		// System.Void* Unity.Collections.LowLevel.Unsafe.NativeArrayUnsafeUtility.GetUnsafePtr<MonsterValue>(Unity.Collections.NativeArray<MonsterValue>)
		// System.Void* Unity.Collections.LowLevel.Unsafe.NativeArrayUnsafeUtility.GetUnsafeReadOnlyPtr<Unity.Entities.Entity>(Unity.Collections.NativeArray<Unity.Entities.Entity>)
		// System.Void* Unity.Collections.LowLevel.Unsafe.UnsafeUtility.AddressOf<Unity.Entities.JobChunkExtensions.JobChunkWrapper<AreaCollisionSystem.CollisionJob>>(Unity.Entities.JobChunkExtensions.JobChunkWrapper<AreaCollisionSystem.CollisionJob>&)
		// System.Void* Unity.Collections.LowLevel.Unsafe.UnsafeUtility.AddressOf<Unity.Entities.JobChunkExtensions.JobChunkWrapper<HeroFishing.Battle.AutoDestroySystem.DestroyJob>>(Unity.Entities.JobChunkExtensions.JobChunkWrapper<HeroFishing.Battle.AutoDestroySystem.DestroyJob>&)
		// System.Void* Unity.Collections.LowLevel.Unsafe.UnsafeUtility.AddressOf<Unity.Entities.JobChunkExtensions.JobChunkWrapper<HeroFishing.Battle.BulletCollisionSystem.MoveJob>>(Unity.Entities.JobChunkExtensions.JobChunkWrapper<HeroFishing.Battle.BulletCollisionSystem.MoveJob>&)
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.AlignOf<MonsterValue>()
		// AreaCollisionData& Unity.Collections.LowLevel.Unsafe.UnsafeUtility.AsRef<AreaCollisionData>(System.Void*)
		// AutoDestroyTag& Unity.Collections.LowLevel.Unsafe.UnsafeUtility.AsRef<AutoDestroyTag>(System.Void*)
		// BulletCollisionData& Unity.Collections.LowLevel.Unsafe.UnsafeUtility.AsRef<BulletCollisionData>(System.Void*)
		// HeroFishing.Battle.LocalTestSys& Unity.Collections.LowLevel.Unsafe.UnsafeUtility.AsRef<HeroFishing.Battle.LocalTestSys>(System.Void*)
		// HeroFishing.Battle.MapGridData& Unity.Collections.LowLevel.Unsafe.UnsafeUtility.AsRef<HeroFishing.Battle.MapGridData>(System.Void*)
		// MoveData& Unity.Collections.LowLevel.Unsafe.UnsafeUtility.AsRef<MoveData>(System.Void*)
		// Unity.Entities.EndSimulationEntityCommandBufferSystem.Singleton& Unity.Collections.LowLevel.Unsafe.UnsafeUtility.AsRef<Unity.Entities.EndSimulationEntityCommandBufferSystem.Singleton>(System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<AreaCollisionData>(AreaCollisionData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<AutoDestroyTag>(AutoDestroyTag&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<BulletCollisionData>(BulletCollisionData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<ChainHitData>(ChainHitData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<FreezeTag>(FreezeTag&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<HeroFishing.Battle.LocalTestSys>(HeroFishing.Battle.LocalTestSys&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<HeroFishing.Battle.MapGridData>(HeroFishing.Battle.MapGridData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<HeroFishing.Battle.RemoveMonsterBoundaryData>(HeroFishing.Battle.RemoveMonsterBoundaryData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<HitInfoBuffer>(HitInfoBuffer&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<HitParticleSpawnTag>(HitParticleSpawnTag&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<LockMonsterData>(LockMonsterData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<MonsterBuffer>(MonsterBuffer&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<MonsterDieNetworkData>(MonsterDieNetworkData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<MonsterDieTag>(MonsterDieTag&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<MonsterHitNetworkData>(MonsterHitNetworkData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<MonsterHitTag>(MonsterHitTag&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<MonsterValue>(MonsterValue&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<MoveData>(MoveData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<SpawnData>(SpawnData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<SpellAreaData>(SpellAreaData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<SpellBulletData>(SpellBulletData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<SpellHitNetworkData>(SpellHitNetworkData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<SpellHitTag>(SpellHitTag&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<AreaCollisionData>(AreaCollisionData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<AutoDestroyTag>(AutoDestroyTag&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<BulletCollisionData>(BulletCollisionData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<ChainHitData>(ChainHitData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<FreezeTag>(FreezeTag&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<HeroFishing.Battle.LocalTestSys>(HeroFishing.Battle.LocalTestSys&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<HeroFishing.Battle.MapGridData>(HeroFishing.Battle.MapGridData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<HeroFishing.Battle.RemoveMonsterBoundaryData>(HeroFishing.Battle.RemoveMonsterBoundaryData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<HitInfoBuffer>(HitInfoBuffer&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<HitParticleSpawnTag>(HitParticleSpawnTag&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<LockMonsterData>(LockMonsterData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<MonsterBuffer>(MonsterBuffer&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<MonsterDieNetworkData>(MonsterDieNetworkData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<MonsterDieTag>(MonsterDieTag&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<MonsterHitNetworkData>(MonsterHitNetworkData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<MonsterHitTag>(MonsterHitTag&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<MonsterValue>(MonsterValue&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<MoveData>(MoveData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<SpawnData>(SpawnData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<SpellAreaData>(SpellAreaData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<SpellBulletData>(SpellBulletData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<SpellHitNetworkData>(SpellHitNetworkData&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<SpellHitTag>(SpellHitTag&,System.Void*)
		// MonsterBuffer Unity.Collections.LowLevel.Unsafe.UnsafeUtility.ReadArrayElement<MonsterBuffer>(System.Void*,int)
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<AreaCollisionData>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<AutoDestroyTag>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<BulletCollisionData>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<ChainHitData>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<HeroFishing.Battle.LocalTestSys>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<HitInfoBuffer>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<HitParticleSpawnTag>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<MonsterBuffer>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<MonsterDieTag>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<MonsterHitNetworkData>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<MonsterHitTag>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<MonsterValue>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<MoveData>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<SpellAreaData>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<SpellBulletData>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<SpellHitNetworkData>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<SpellHitTag>()
		// int Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<Unity.Collections.LowLevel.Unsafe.UnsafeUtility.AlignOfHelper<MonsterValue>>()
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.WriteArrayElement<MonsterBuffer>(System.Void*,int,MonsterBuffer)
		// System.Void Unity.Collections.NativeArrayExtensions.Initialize<MonsterValue>(Unity.Collections.NativeArray<MonsterValue>&,int,Unity.Collections.AllocatorManager.AllocatorHandle,Unity.Collections.NativeArrayOptions)
		// System.Void Unity.Collections.NativeSortExtension.HeapSortStruct<MonsterBuffer,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>>(System.Void*,int,int,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>)
		// System.Void Unity.Collections.NativeSortExtension.HeapifyStruct<MonsterBuffer,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>>(System.Void*,int,int,int,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>)
		// System.Void Unity.Collections.NativeSortExtension.InsertionSortStruct<MonsterBuffer,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>>(System.Void*,int,int,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>)
		// System.Void Unity.Collections.NativeSortExtension.IntroSortStruct<MonsterBuffer,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>>(System.Void*,int,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>)
		// System.Void Unity.Collections.NativeSortExtension.IntroSortStruct<MonsterBuffer,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>>(System.Void*,int,int,int,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>)
		// int Unity.Collections.NativeSortExtension.PartitionStruct<MonsterBuffer,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>>(System.Void*,int,int,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>)
		// System.Void Unity.Collections.NativeSortExtension.Sort<MonsterBuffer>(Unity.Collections.NativeArray<MonsterBuffer>)
		// System.Void Unity.Collections.NativeSortExtension.SwapIfGreaterWithItemsStruct<MonsterBuffer,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>>(System.Void*,int,int,Unity.Collections.NativeSortExtension.DefaultComparer<MonsterBuffer>)
		// System.Void Unity.Collections.NativeSortExtension.SwapStruct<MonsterBuffer>(System.Void*,int,int)
		// Unity.Entities.ManagedComponentAccessor<object> Unity.Entities.ArchetypeChunk.GetManagedComponentAccessor<object>(Unity.Entities.ComponentTypeHandle<object>&,Unity.Entities.EntityManager)
		// System.Void* Unity.Entities.ArchetypeChunk.GetRequiredComponentDataPtrRW<AreaCollisionData>(Unity.Entities.ComponentTypeHandle<AreaCollisionData>&)
		// System.Void* Unity.Entities.ArchetypeChunk.GetRequiredComponentDataPtrRW<AutoDestroyTag>(Unity.Entities.ComponentTypeHandle<AutoDestroyTag>&)
		// System.Void* Unity.Entities.ArchetypeChunk.GetRequiredComponentDataPtrRW<BulletCollisionData>(Unity.Entities.ComponentTypeHandle<BulletCollisionData>&)
		// System.Void* Unity.Entities.ArchetypeChunk.GetRequiredComponentDataPtrRW<MoveData>(Unity.Entities.ComponentTypeHandle<MoveData>&)
		// Unity.Collections.NativeArray<MonsterValue> Unity.Entities.ChunkIterationUtility.CreateComponentDataArray<MonsterValue>(Unity.Collections.AllocatorManager.AllocatorHandle,Unity.Entities.ComponentTypeHandle<MonsterValue>&,int,Unity.Entities.EntityQuery)
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<AreaCollisionData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<AutoDestroyTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<BulletCollisionData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<ChainHitData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<ClearAllTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<FreezeTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<HeroFishing.Battle.BulletSpawnSys>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<HeroFishing.Battle.CollisionSys>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<HeroFishing.Battle.LocalTestSys>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<HeroFishing.Battle.MapGridData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<HeroFishing.Battle.MonsterSpawnSys>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<HeroFishing.Battle.RemoveMonsterBoundaryData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<HitInfoBuffer>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<HitParticleSpawnTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<LockMonsterData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<MonsterBuffer>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<MonsterDieNetworkData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<MonsterDieTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<MonsterFreezeTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<MonsterHitNetworkData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<MonsterHitTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<MonsterValue>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<MoveData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<ParticleSpawnTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<RefreshSceneTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<SpawnData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<SpawnTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<SpellAreaData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<SpellBulletData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<SpellHitNetworkData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<SpellHitTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<Unity.Entities.EndSimulationEntityCommandBufferSystem.Singleton>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadOnly<object>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<AlreadyUpdateTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<AreaCollisionData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<AutoDestroyTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<BulletCollisionData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<ChainHitData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<ClearAllTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<FreezeTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<HeroFishing.Battle.BulletSpawnSys>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<HeroFishing.Battle.CollisionSys>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<HeroFishing.Battle.LocalTestSys>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<HeroFishing.Battle.MapGridData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<HeroFishing.Battle.MonsterSpawnSys>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<HeroFishing.Battle.RemoveMonsterBoundaryData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<HitInfoBuffer>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<HitParticleSpawnTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<LockMonsterData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<MonsterBuffer>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<MonsterDieNetworkData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<MonsterDieTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<MonsterFreezeTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<MonsterHitNetworkData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<MonsterHitTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<MonsterValue>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<MoveData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<ParticleSpawnTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<RefreshSceneTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<SpawnData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<SpawnTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<SpellAreaData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<SpellBulletData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<SpellHitNetworkData>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<SpellHitTag>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<Unity.Entities.EndSimulationEntityCommandBufferSystem.Singleton>()
		// Unity.Entities.ComponentType Unity.Entities.ComponentType.ReadWrite<object>()
		// Unity.Entities.DynamicBuffer<MonsterBuffer> Unity.Entities.EntityCommandBuffer.AddBuffer<MonsterBuffer>(Unity.Entities.Entity)
		// System.Void Unity.Entities.EntityCommandBuffer.AddComponent<AlreadyUpdateTag>(Unity.Entities.Entity)
		// System.Void Unity.Entities.EntityCommandBuffer.AddComponent<AreaCollisionData>(Unity.Entities.Entity,AreaCollisionData)
		// System.Void Unity.Entities.EntityCommandBuffer.AddComponent<AutoDestroyTag>(Unity.Entities.Entity,AutoDestroyTag)
		// System.Void Unity.Entities.EntityCommandBuffer.AddComponent<AutoDestroyTag>(Unity.Entities.EntityQuery,AutoDestroyTag)
		// System.Void Unity.Entities.EntityCommandBuffer.AddComponent<BulletCollisionData>(Unity.Entities.Entity,BulletCollisionData)
		// System.Void Unity.Entities.EntityCommandBuffer.AddComponent<HeroFishing.Battle.LocalTestSys>(Unity.Entities.Entity,HeroFishing.Battle.LocalTestSys)
		// System.Void Unity.Entities.EntityCommandBuffer.AddComponent<MonsterDieTag>(Unity.Entities.Entity,MonsterDieTag)
		// System.Void Unity.Entities.EntityCommandBuffer.AddComponent<MonsterFreezeTag>(Unity.Entities.Entity)
		// System.Void Unity.Entities.EntityCommandBuffer.AddComponent<MonsterValue>(Unity.Entities.Entity,MonsterValue)
		// System.Void Unity.Entities.EntityCommandBuffer.AddComponent<MoveData>(Unity.Entities.Entity,MoveData)
		// System.Void Unity.Entities.EntityCommandBuffer.AddComponent<SpawnTag>(Unity.Entities.Entity)
		// System.Void Unity.Entities.EntityCommandBuffer.AddComponent<SpellBulletData>(Unity.Entities.Entity,SpellBulletData)
		// System.Void Unity.Entities.EntityCommandBuffer.AppendToBuffer<MonsterBuffer>(Unity.Entities.Entity,MonsterBuffer)
		// System.Void Unity.Entities.EntityCommandBuffer.RemoveComponent<AlreadyUpdateTag>(Unity.Entities.EntityQuery,Unity.Entities.EntityQueryCaptureMode)
		// System.Void Unity.Entities.EntityCommandBuffer.RemoveComponent<MonsterFreezeTag>(Unity.Entities.Entity)
		// System.Void Unity.Entities.EntityCommandBuffer.RemoveComponent<RefreshSceneTag>(Unity.Entities.Entity)
		// Unity.Entities.DynamicBuffer<HitInfoBuffer> Unity.Entities.EntityCommandBuffer.ParallelWriter.AddBuffer<HitInfoBuffer>(int,Unity.Entities.Entity)
		// Unity.Entities.DynamicBuffer<MonsterHitNetworkData> Unity.Entities.EntityCommandBuffer.ParallelWriter.AddBuffer<MonsterHitNetworkData>(int,Unity.Entities.Entity)
		// System.Void Unity.Entities.EntityCommandBuffer.ParallelWriter.AddComponent<AutoDestroyTag>(int,Unity.Entities.Entity,AutoDestroyTag)
		// System.Void Unity.Entities.EntityCommandBuffer.ParallelWriter.AddComponent<ChainHitData>(int,Unity.Entities.Entity,ChainHitData)
		// System.Void Unity.Entities.EntityCommandBuffer.ParallelWriter.AddComponent<HitParticleSpawnTag>(int,Unity.Entities.Entity,HitParticleSpawnTag)
		// System.Void Unity.Entities.EntityCommandBuffer.ParallelWriter.AddComponent<MonsterDieTag>(int,Unity.Entities.Entity,MonsterDieTag)
		// System.Void Unity.Entities.EntityCommandBuffer.ParallelWriter.AddComponent<MonsterHitTag>(int,Unity.Entities.Entity,MonsterHitTag)
		// System.Void Unity.Entities.EntityCommandBuffer.ParallelWriter.AddComponent<SpellAreaData>(int,Unity.Entities.Entity,SpellAreaData)
		// System.Void Unity.Entities.EntityCommandBuffer.ParallelWriter.AddComponent<SpellBulletData>(int,Unity.Entities.Entity,SpellBulletData)
		// System.Void Unity.Entities.EntityCommandBuffer.ParallelWriter.AddComponent<SpellHitNetworkData>(int,Unity.Entities.Entity,SpellHitNetworkData)
		// System.Void Unity.Entities.EntityCommandBuffer.ParallelWriter.AddComponent<SpellHitTag>(int,Unity.Entities.Entity,SpellHitTag)
		// System.Void Unity.Entities.EntityCommandBuffer.ParallelWriter.AppendToBuffer<HitInfoBuffer>(int,Unity.Entities.Entity,HitInfoBuffer)
		// System.Void Unity.Entities.EntityCommandBuffer.ParallelWriter.AppendToBuffer<MonsterHitNetworkData>(int,Unity.Entities.Entity,MonsterHitNetworkData)
		// System.Void Unity.Entities.EntityCommandBuffer.ParallelWriter.RemoveComponent<MonsterDieTag>(int,Unity.Entities.Entity)
		// System.Void Unity.Entities.EntityCommandBuffer.ParallelWriter.RemoveComponent<MonsterHitTag>(int,Unity.Entities.Entity)
		// Unity.Entities.BufferHeader* Unity.Entities.EntityCommandBufferData.AddEntityBufferCommand<HitInfoBuffer>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,int&)
		// Unity.Entities.BufferHeader* Unity.Entities.EntityCommandBufferData.AddEntityBufferCommand<MonsterBuffer>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,int&)
		// Unity.Entities.BufferHeader* Unity.Entities.EntityCommandBufferData.AddEntityBufferCommand<MonsterHitNetworkData>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,int&)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<AreaCollisionData>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,AreaCollisionData)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<AutoDestroyTag>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,AutoDestroyTag)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<BulletCollisionData>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,BulletCollisionData)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<ChainHitData>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,ChainHitData)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<HeroFishing.Battle.LocalTestSys>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,HeroFishing.Battle.LocalTestSys)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<HitParticleSpawnTag>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,HitParticleSpawnTag)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<MonsterDieTag>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,MonsterDieTag)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<MonsterHitTag>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,MonsterHitTag)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<MonsterValue>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,MonsterValue)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<MoveData>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,MoveData)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<SpellAreaData>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,SpellAreaData)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<SpellBulletData>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,SpellBulletData)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<SpellHitNetworkData>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,SpellHitNetworkData)
		// System.Void Unity.Entities.EntityCommandBufferData.AddEntityComponentTypeWithValueCommand<SpellHitTag>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,SpellHitTag)
		// bool Unity.Entities.EntityCommandBufferData.AppendMultipleEntitiesComponentCommandWithValue<AutoDestroyTag>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity*,int,bool,AutoDestroyTag)
		// bool Unity.Entities.EntityCommandBufferData.AppendMultipleEntitiesComponentCommandWithValue<AutoDestroyTag>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.ECBCommand,Unity.Entities.EntityQuery,AutoDestroyTag)
		// System.Void Unity.Entities.EntityCommandBufferData.AppendToBufferCommand<HitInfoBuffer>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.Entity,HitInfoBuffer)
		// System.Void Unity.Entities.EntityCommandBufferData.AppendToBufferCommand<MonsterBuffer>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.Entity,MonsterBuffer)
		// System.Void Unity.Entities.EntityCommandBufferData.AppendToBufferCommand<MonsterHitNetworkData>(Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.Entity,MonsterHitNetworkData)
		// Unity.Entities.DynamicBuffer<HitInfoBuffer> Unity.Entities.EntityCommandBufferData.CreateBufferCommand<HitInfoBuffer>(Unity.Entities.ECBCommand,Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.Entity)
		// Unity.Entities.DynamicBuffer<MonsterBuffer> Unity.Entities.EntityCommandBufferData.CreateBufferCommand<MonsterBuffer>(Unity.Entities.ECBCommand,Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.Entity)
		// Unity.Entities.DynamicBuffer<MonsterHitNetworkData> Unity.Entities.EntityCommandBufferData.CreateBufferCommand<MonsterHitNetworkData>(Unity.Entities.ECBCommand,Unity.Entities.EntityCommandBufferChain*,int,Unity.Entities.Entity)
		// System.Void Unity.Entities.EntityCommandBufferManagedComponentExtensions.AddComponent<object>(Unity.Entities.EntityCommandBuffer,Unity.Entities.Entity,object)
		// System.Void Unity.Entities.EntityCommandBufferManagedComponentExtensions.AddEntityManagedComponentCommandFromMainThread<object>(Unity.Entities.EntityCommandBufferData*,int,Unity.Entities.ECBCommand,Unity.Entities.Entity,object)
		// System.Void Unity.Entities.EntityDataAccess.SetComponentData<FreezeTag>(Unity.Entities.Entity,FreezeTag,Unity.Entities.SystemHandle&)
		// System.Void Unity.Entities.EntityDataAccess.SetComponentData<HeroFishing.Battle.MapGridData>(Unity.Entities.Entity,HeroFishing.Battle.MapGridData,Unity.Entities.SystemHandle&)
		// System.Void Unity.Entities.EntityDataAccess.SetComponentData<HeroFishing.Battle.RemoveMonsterBoundaryData>(Unity.Entities.Entity,HeroFishing.Battle.RemoveMonsterBoundaryData,Unity.Entities.SystemHandle&)
		// System.Void Unity.Entities.EntityDataAccess.SetComponentData<LockMonsterData>(Unity.Entities.Entity,LockMonsterData,Unity.Entities.SystemHandle&)
		// System.Void Unity.Entities.EntityDataAccess.SetComponentData<MonsterDieNetworkData>(Unity.Entities.Entity,MonsterDieNetworkData,Unity.Entities.SystemHandle&)
		// System.Void Unity.Entities.EntityDataAccess.SetComponentData<SpawnData>(Unity.Entities.Entity,SpawnData,Unity.Entities.SystemHandle&)
		// System.Void Unity.Entities.EntityDataAccess.SetComponentData<SpellAreaData>(Unity.Entities.Entity,SpellAreaData,Unity.Entities.SystemHandle&)
		// System.Void Unity.Entities.EntityDataAccess.SetComponentData<SpellBulletData>(Unity.Entities.Entity,SpellBulletData,Unity.Entities.SystemHandle&)
		// bool Unity.Entities.EntityManager.AddComponent<RefreshSceneTag>(Unity.Entities.Entity)
		// bool Unity.Entities.EntityManager.AddComponent<SpawnTag>(Unity.Entities.Entity)
		// bool Unity.Entities.EntityManager.AddComponentData<FreezeTag>(Unity.Entities.Entity,FreezeTag)
		// bool Unity.Entities.EntityManager.AddComponentData<HeroFishing.Battle.MapGridData>(Unity.Entities.Entity,HeroFishing.Battle.MapGridData)
		// bool Unity.Entities.EntityManager.AddComponentData<HeroFishing.Battle.RemoveMonsterBoundaryData>(Unity.Entities.Entity,HeroFishing.Battle.RemoveMonsterBoundaryData)
		// bool Unity.Entities.EntityManager.AddComponentData<LockMonsterData>(Unity.Entities.Entity,LockMonsterData)
		// bool Unity.Entities.EntityManager.AddComponentData<MonsterDieNetworkData>(Unity.Entities.Entity,MonsterDieNetworkData)
		// bool Unity.Entities.EntityManager.AddComponentData<SpawnData>(Unity.Entities.Entity,SpawnData)
		// bool Unity.Entities.EntityManager.AddComponentData<SpellAreaData>(Unity.Entities.Entity,SpellAreaData)
		// bool Unity.Entities.EntityManager.AddComponentData<SpellBulletData>(Unity.Entities.Entity,SpellBulletData)
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<ChainHitData>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<HeroFishing.Battle.MapGridData>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<HeroFishing.Battle.RemoveMonsterBoundaryData>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<HitParticleSpawnTag>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<LockMonsterData>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<MonsterDieNetworkData>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<MonsterDieTag>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<MonsterFreezeTag>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<MonsterHitTag>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<MonsterValue>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<ParticleSpawnTag>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<SpawnData>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<SpellAreaData>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<SpellBulletData>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<SpellHitNetworkData>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRO<SpellHitTag>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRW<MonsterHitNetworkData>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRW<MonsterValue>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRW<MoveData>()
		// System.Void Unity.Entities.EntityManager.CompleteDependencyBeforeRW<object>()
		// Unity.Entities.BufferLookup<HitInfoBuffer> Unity.Entities.EntityManager.GetBufferLookup<HitInfoBuffer>(Unity.Entities.TypeIndex,bool)
		// Unity.Entities.BufferLookup<HitInfoBuffer> Unity.Entities.EntityManager.GetBufferLookup<HitInfoBuffer>(bool)
		// Unity.Entities.BufferLookup<MonsterBuffer> Unity.Entities.EntityManager.GetBufferLookup<MonsterBuffer>(Unity.Entities.TypeIndex,bool)
		// Unity.Entities.BufferLookup<MonsterBuffer> Unity.Entities.EntityManager.GetBufferLookup<MonsterBuffer>(bool)
		// Unity.Entities.BufferLookup<MonsterHitNetworkData> Unity.Entities.EntityManager.GetBufferLookup<MonsterHitNetworkData>(Unity.Entities.TypeIndex,bool)
		// Unity.Entities.BufferLookup<MonsterHitNetworkData> Unity.Entities.EntityManager.GetBufferLookup<MonsterHitNetworkData>(bool)
		// Unity.Entities.ComponentLookup<AutoDestroyTag> Unity.Entities.EntityManager.GetComponentLookup<AutoDestroyTag>(Unity.Entities.TypeIndex,bool)
		// Unity.Entities.ComponentLookup<AutoDestroyTag> Unity.Entities.EntityManager.GetComponentLookup<AutoDestroyTag>(bool)
		// Unity.Entities.ComponentLookup<HeroFishing.Battle.MapGridData> Unity.Entities.EntityManager.GetComponentLookup<HeroFishing.Battle.MapGridData>(Unity.Entities.TypeIndex,bool)
		// Unity.Entities.ComponentLookup<HeroFishing.Battle.MapGridData> Unity.Entities.EntityManager.GetComponentLookup<HeroFishing.Battle.MapGridData>(bool)
		// Unity.Entities.ComponentLookup<HeroFishing.Battle.RemoveMonsterBoundaryData> Unity.Entities.EntityManager.GetComponentLookup<HeroFishing.Battle.RemoveMonsterBoundaryData>(Unity.Entities.TypeIndex,bool)
		// Unity.Entities.ComponentLookup<HeroFishing.Battle.RemoveMonsterBoundaryData> Unity.Entities.EntityManager.GetComponentLookup<HeroFishing.Battle.RemoveMonsterBoundaryData>(bool)
		// Unity.Entities.ComponentLookup<MonsterFreezeTag> Unity.Entities.EntityManager.GetComponentLookup<MonsterFreezeTag>(Unity.Entities.TypeIndex,bool)
		// Unity.Entities.ComponentLookup<MonsterFreezeTag> Unity.Entities.EntityManager.GetComponentLookup<MonsterFreezeTag>(bool)
		// Unity.Entities.ComponentLookup<MonsterValue> Unity.Entities.EntityManager.GetComponentLookup<MonsterValue>(Unity.Entities.TypeIndex,bool)
		// Unity.Entities.ComponentLookup<MonsterValue> Unity.Entities.EntityManager.GetComponentLookup<MonsterValue>(bool)
		// Unity.Entities.ComponentTypeHandle<AreaCollisionData> Unity.Entities.EntityManager.GetComponentTypeHandle<AreaCollisionData>(bool)
		// Unity.Entities.ComponentTypeHandle<AutoDestroyTag> Unity.Entities.EntityManager.GetComponentTypeHandle<AutoDestroyTag>(bool)
		// Unity.Entities.ComponentTypeHandle<BulletCollisionData> Unity.Entities.EntityManager.GetComponentTypeHandle<BulletCollisionData>(bool)
		// Unity.Entities.ComponentTypeHandle<ChainHitData> Unity.Entities.EntityManager.GetComponentTypeHandle<ChainHitData>(bool)
		// Unity.Entities.ComponentTypeHandle<HitParticleSpawnTag> Unity.Entities.EntityManager.GetComponentTypeHandle<HitParticleSpawnTag>(bool)
		// Unity.Entities.ComponentTypeHandle<LockMonsterData> Unity.Entities.EntityManager.GetComponentTypeHandle<LockMonsterData>(bool)
		// Unity.Entities.ComponentTypeHandle<MonsterDieNetworkData> Unity.Entities.EntityManager.GetComponentTypeHandle<MonsterDieNetworkData>(bool)
		// Unity.Entities.ComponentTypeHandle<MonsterDieTag> Unity.Entities.EntityManager.GetComponentTypeHandle<MonsterDieTag>(bool)
		// Unity.Entities.ComponentTypeHandle<MonsterHitTag> Unity.Entities.EntityManager.GetComponentTypeHandle<MonsterHitTag>(bool)
		// Unity.Entities.ComponentTypeHandle<MonsterValue> Unity.Entities.EntityManager.GetComponentTypeHandle<MonsterValue>(bool)
		// Unity.Entities.ComponentTypeHandle<MoveData> Unity.Entities.EntityManager.GetComponentTypeHandle<MoveData>(bool)
		// Unity.Entities.ComponentTypeHandle<ParticleSpawnTag> Unity.Entities.EntityManager.GetComponentTypeHandle<ParticleSpawnTag>(bool)
		// Unity.Entities.ComponentTypeHandle<SpawnData> Unity.Entities.EntityManager.GetComponentTypeHandle<SpawnData>(bool)
		// Unity.Entities.ComponentTypeHandle<SpellAreaData> Unity.Entities.EntityManager.GetComponentTypeHandle<SpellAreaData>(bool)
		// Unity.Entities.ComponentTypeHandle<SpellBulletData> Unity.Entities.EntityManager.GetComponentTypeHandle<SpellBulletData>(bool)
		// Unity.Entities.ComponentTypeHandle<SpellHitNetworkData> Unity.Entities.EntityManager.GetComponentTypeHandle<SpellHitNetworkData>(bool)
		// Unity.Entities.ComponentTypeHandle<SpellHitTag> Unity.Entities.EntityManager.GetComponentTypeHandle<SpellHitTag>(bool)
		// Unity.Entities.ComponentTypeHandle<object> Unity.Entities.EntityManager.GetComponentTypeHandle<object>(bool)
		// bool Unity.Entities.EntityManager.HasComponent<MonsterFreezeTag>(Unity.Entities.Entity)
		// bool Unity.Entities.EntityManager.RemoveComponent<FreezeTag>(Unity.Entities.Entity)
		// System.Void Unity.Entities.EntityManager.SetComponentData<FreezeTag>(Unity.Entities.Entity,FreezeTag)
		// System.Void Unity.Entities.EntityManager.SetComponentData<HeroFishing.Battle.MapGridData>(Unity.Entities.Entity,HeroFishing.Battle.MapGridData)
		// System.Void Unity.Entities.EntityManager.SetComponentData<HeroFishing.Battle.RemoveMonsterBoundaryData>(Unity.Entities.Entity,HeroFishing.Battle.RemoveMonsterBoundaryData)
		// System.Void Unity.Entities.EntityManager.SetComponentData<LockMonsterData>(Unity.Entities.Entity,LockMonsterData)
		// System.Void Unity.Entities.EntityManager.SetComponentData<MonsterDieNetworkData>(Unity.Entities.Entity,MonsterDieNetworkData)
		// System.Void Unity.Entities.EntityManager.SetComponentData<SpawnData>(Unity.Entities.Entity,SpawnData)
		// System.Void Unity.Entities.EntityManager.SetComponentData<SpellAreaData>(Unity.Entities.Entity,SpellAreaData)
		// System.Void Unity.Entities.EntityManager.SetComponentData<SpellBulletData>(Unity.Entities.Entity,SpellBulletData)
		// HeroFishing.Battle.LocalTestSys Unity.Entities.EntityQuery.GetSingleton<HeroFishing.Battle.LocalTestSys>()
		// HeroFishing.Battle.MapGridData Unity.Entities.EntityQuery.GetSingleton<HeroFishing.Battle.MapGridData>()
		// Unity.Entities.EndSimulationEntityCommandBufferSystem.Singleton Unity.Entities.EntityQuery.GetSingleton<Unity.Entities.EndSimulationEntityCommandBufferSystem.Singleton>()
		// bool Unity.Entities.EntityQuery.HasSingleton<FreezeTag>()
		// bool Unity.Entities.EntityQuery.HasSingleton<HeroFishing.Battle.LocalTestSys>()
		// Unity.Collections.NativeArray<MonsterValue> Unity.Entities.EntityQuery.ToComponentDataArray<MonsterValue>(Unity.Collections.AllocatorManager.AllocatorHandle)
		// Unity.Entities.EntityQueryBuilder Unity.Entities.EntityQueryBuilder.WithAbsent<AutoDestroyTag,AlreadyUpdateTag>()
		// Unity.Entities.EntityQueryBuilder Unity.Entities.EntityQueryBuilder.WithAbsent<AutoDestroyTag>()
		// Unity.Entities.EntityQueryBuilder Unity.Entities.EntityQueryBuilder.WithAll<MonsterValue,AlreadyUpdateTag>()
		// Unity.Entities.EntityQueryBuilder Unity.Entities.EntityQueryBuilder.WithAll<MonsterValue>()
		// Unity.Entities.EntityQueryBuilder Unity.Entities.EntityQueryBuilder.WithAny<SpellBulletData,SpellAreaData>()
		// Unity.Entities.EntityQueryBuilder Unity.Entities.EntityQueryBuilder.WithAny<object,object,ClearAllTag>()
		// HeroFishing.Battle.LocalTestSys Unity.Entities.EntityQueryImpl.GetSingleton<HeroFishing.Battle.LocalTestSys>()
		// HeroFishing.Battle.MapGridData Unity.Entities.EntityQueryImpl.GetSingleton<HeroFishing.Battle.MapGridData>()
		// Unity.Entities.EndSimulationEntityCommandBufferSystem.Singleton Unity.Entities.EntityQueryImpl.GetSingleton<Unity.Entities.EndSimulationEntityCommandBufferSystem.Singleton>()
		// bool Unity.Entities.EntityQueryImpl.HasSingleton<FreezeTag>()
		// bool Unity.Entities.EntityQueryImpl.HasSingleton<HeroFishing.Battle.LocalTestSys>()
		// Unity.Collections.NativeArray<MonsterValue> Unity.Entities.EntityQueryImpl.ToComponentDataArray<MonsterValue>(Unity.Collections.AllocatorManager.AllocatorHandle,Unity.Entities.EntityQuery)
		// System.Void Unity.Entities.IBaker.AddComponent<AutoDestroyTag>(Unity.Entities.Entity,AutoDestroyTag&)
		// System.Void Unity.Entities.IBaker.AddComponent<HeroFishing.Battle.BulletSpawnSys>(Unity.Entities.Entity)
		// System.Void Unity.Entities.IBaker.AddComponent<HeroFishing.Battle.CollisionSys>(Unity.Entities.Entity)
		// System.Void Unity.Entities.IBaker.AddComponent<HeroFishing.Battle.LocalTestSys>(Unity.Entities.Entity,HeroFishing.Battle.LocalTestSys&)
		// System.Void Unity.Entities.IBaker.AddComponent<HeroFishing.Battle.MonsterSpawnSys>(Unity.Entities.Entity)
		// System.Void Unity.Entities.IBaker.AddDebugTrackingForComponent<AutoDestroyTag>(Unity.Entities.Entity)
		// System.Void Unity.Entities.IBaker.AddDebugTrackingForComponent<HeroFishing.Battle.LocalTestSys>(Unity.Entities.Entity)
		// System.Void Unity.Entities.IBaker.AddTrackingForComponent<AutoDestroyTag>()
		// System.Void Unity.Entities.IBaker.AddTrackingForComponent<HeroFishing.Battle.LocalTestSys>()
		// object Unity.Entities.IBaker.GetComponent<object>()
		// object Unity.Entities.IBaker.GetComponentInternal<object>(UnityEngine.GameObject)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr<AreaCollisionData>(Unity.Entities.ArchetypeChunk,Unity.Entities.ComponentTypeHandle<AreaCollisionData>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr<AutoDestroyTag>(Unity.Entities.ArchetypeChunk,Unity.Entities.ComponentTypeHandle<AutoDestroyTag>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr<BulletCollisionData>(Unity.Entities.ArchetypeChunk,Unity.Entities.ComponentTypeHandle<BulletCollisionData>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr<MoveData>(Unity.Entities.ArchetypeChunk,Unity.Entities.ComponentTypeHandle<MoveData>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks<MonsterValue>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<MonsterValue>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks<MoveData>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<MoveData>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks<ChainHitData>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<ChainHitData>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks<HitParticleSpawnTag>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<HitParticleSpawnTag>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks<LockMonsterData>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<LockMonsterData>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks<MonsterDieNetworkData>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<MonsterDieNetworkData>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks<MonsterDieTag>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<MonsterDieTag>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks<MonsterHitTag>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<MonsterHitTag>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks<MonsterValue>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<MonsterValue>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks<ParticleSpawnTag>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<ParticleSpawnTag>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks<SpawnData>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<SpawnData>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks<SpellAreaData>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<SpellAreaData>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks<SpellBulletData>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<SpellBulletData>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks<SpellHitNetworkData>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<SpellHitNetworkData>&)
		// System.IntPtr Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks<SpellHitTag>(Unity.Entities.ArchetypeChunk&,Unity.Entities.ComponentTypeHandle<SpellHitTag>&)
		// ChainHitData Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ChainHitData>(System.IntPtr,int)
		// HitParticleSpawnTag Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<HitParticleSpawnTag>(System.IntPtr,int)
		// LockMonsterData Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<LockMonsterData>(System.IntPtr,int)
		// MonsterDieNetworkData Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<MonsterDieNetworkData>(System.IntPtr,int)
		// MonsterDieTag Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<MonsterDieTag>(System.IntPtr,int)
		// MonsterHitTag Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<MonsterHitTag>(System.IntPtr,int)
		// MonsterValue Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<MonsterValue>(System.IntPtr,int)
		// ParticleSpawnTag Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ParticleSpawnTag>(System.IntPtr,int)
		// SpawnData Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<SpawnData>(System.IntPtr,int)
		// SpellAreaData Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<SpellAreaData>(System.IntPtr,int)
		// SpellBulletData Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<SpellBulletData>(System.IntPtr,int)
		// SpellHitNetworkData Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<SpellHitNetworkData>(System.IntPtr,int)
		// SpellHitTag Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<SpellHitTag>(System.IntPtr,int)
		// Unity.Entities.Entity Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Unity.Entities.Entity>(System.IntPtr,int)
		// AreaCollisionData& Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AreaCollisionData>(System.IntPtr,int)
		// AutoDestroyTag& Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoDestroyTag>(System.IntPtr,int)
		// BulletCollisionData& Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BulletCollisionData>(System.IntPtr,int)
		// MoveData& Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveData>(System.IntPtr,int)
		// Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRO<ChainHitData> Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetUncheckedRefRO<ChainHitData>(System.IntPtr,int)
		// Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRO<MonsterValue> Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetUncheckedRefRO<MonsterValue>(System.IntPtr,int)
		// Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRW<MonsterValue> Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetUncheckedRefRW<MonsterValue>(System.IntPtr,int)
		// Unity.Entities.Internal.InternalCompilerInterface.UncheckedRefRW<MoveData> Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetUncheckedRefRW<MoveData>(System.IntPtr,int)
		// System.Void Unity.Entities.JobChunkExtensions.EarlyJobInit<AreaCollisionSystem.CollisionJob>()
		// System.Void Unity.Entities.JobChunkExtensions.EarlyJobInit<HeroFishing.Battle.AutoDestroySystem.DestroyJob>()
		// System.Void Unity.Entities.JobChunkExtensions.EarlyJobInit<HeroFishing.Battle.BulletCollisionSystem.MoveJob>()
		// System.Void Unity.Entities.JobChunkExtensions.RunByRef<AreaCollisionSystem.CollisionJob>(AreaCollisionSystem.CollisionJob&,Unity.Entities.EntityQuery)
		// System.Void Unity.Entities.JobChunkExtensions.RunByRef<HeroFishing.Battle.AutoDestroySystem.DestroyJob>(HeroFishing.Battle.AutoDestroySystem.DestroyJob&,Unity.Entities.EntityQuery)
		// System.Void Unity.Entities.JobChunkExtensions.RunByRef<HeroFishing.Battle.BulletCollisionSystem.MoveJob>(HeroFishing.Battle.BulletCollisionSystem.MoveJob&,Unity.Entities.EntityQuery)
		// Unity.Jobs.JobHandle Unity.Entities.JobChunkExtensions.ScheduleByRef<AreaCollisionSystem.CollisionJob>(AreaCollisionSystem.CollisionJob&,Unity.Entities.EntityQuery,Unity.Jobs.JobHandle)
		// Unity.Jobs.JobHandle Unity.Entities.JobChunkExtensions.ScheduleByRef<HeroFishing.Battle.AutoDestroySystem.DestroyJob>(HeroFishing.Battle.AutoDestroySystem.DestroyJob&,Unity.Entities.EntityQuery,Unity.Jobs.JobHandle)
		// Unity.Jobs.JobHandle Unity.Entities.JobChunkExtensions.ScheduleByRef<HeroFishing.Battle.BulletCollisionSystem.MoveJob>(HeroFishing.Battle.BulletCollisionSystem.MoveJob&,Unity.Entities.EntityQuery,Unity.Jobs.JobHandle)
		// Unity.Jobs.JobHandle Unity.Entities.JobChunkExtensions.ScheduleInternal<AreaCollisionSystem.CollisionJob>(AreaCollisionSystem.CollisionJob&,Unity.Entities.EntityQuery,Unity.Jobs.JobHandle,Unity.Jobs.LowLevel.Unsafe.ScheduleMode,Unity.Collections.NativeArray<int>)
		// Unity.Jobs.JobHandle Unity.Entities.JobChunkExtensions.ScheduleInternal<HeroFishing.Battle.AutoDestroySystem.DestroyJob>(HeroFishing.Battle.AutoDestroySystem.DestroyJob&,Unity.Entities.EntityQuery,Unity.Jobs.JobHandle,Unity.Jobs.LowLevel.Unsafe.ScheduleMode,Unity.Collections.NativeArray<int>)
		// Unity.Jobs.JobHandle Unity.Entities.JobChunkExtensions.ScheduleInternal<HeroFishing.Battle.BulletCollisionSystem.MoveJob>(HeroFishing.Battle.BulletCollisionSystem.MoveJob&,Unity.Entities.EntityQuery,Unity.Jobs.JobHandle,Unity.Jobs.LowLevel.Unsafe.ScheduleMode,Unity.Collections.NativeArray<int>)
		// Unity.Jobs.JobHandle Unity.Entities.JobChunkExtensions.ScheduleParallelByRef<AreaCollisionSystem.CollisionJob>(AreaCollisionSystem.CollisionJob&,Unity.Entities.EntityQuery,Unity.Jobs.JobHandle)
		// Unity.Jobs.JobHandle Unity.Entities.JobChunkExtensions.ScheduleParallelByRef<HeroFishing.Battle.AutoDestroySystem.DestroyJob>(HeroFishing.Battle.AutoDestroySystem.DestroyJob&,Unity.Entities.EntityQuery,Unity.Jobs.JobHandle)
		// Unity.Jobs.JobHandle Unity.Entities.JobChunkExtensions.ScheduleParallelByRef<HeroFishing.Battle.BulletCollisionSystem.MoveJob>(HeroFishing.Battle.BulletCollisionSystem.MoveJob&,Unity.Entities.EntityQuery,Unity.Jobs.JobHandle)
		// Unity.Entities.BufferLookup<HitInfoBuffer> Unity.Entities.SystemState.GetBufferLookup<HitInfoBuffer>(bool)
		// Unity.Entities.BufferLookup<MonsterBuffer> Unity.Entities.SystemState.GetBufferLookup<MonsterBuffer>(bool)
		// Unity.Entities.BufferLookup<MonsterHitNetworkData> Unity.Entities.SystemState.GetBufferLookup<MonsterHitNetworkData>(bool)
		// Unity.Entities.ComponentLookup<AutoDestroyTag> Unity.Entities.SystemState.GetComponentLookup<AutoDestroyTag>(bool)
		// Unity.Entities.ComponentLookup<HeroFishing.Battle.MapGridData> Unity.Entities.SystemState.GetComponentLookup<HeroFishing.Battle.MapGridData>(bool)
		// Unity.Entities.ComponentLookup<HeroFishing.Battle.RemoveMonsterBoundaryData> Unity.Entities.SystemState.GetComponentLookup<HeroFishing.Battle.RemoveMonsterBoundaryData>(bool)
		// Unity.Entities.ComponentLookup<MonsterFreezeTag> Unity.Entities.SystemState.GetComponentLookup<MonsterFreezeTag>(bool)
		// Unity.Entities.ComponentLookup<MonsterValue> Unity.Entities.SystemState.GetComponentLookup<MonsterValue>(bool)
		// Unity.Entities.ComponentTypeHandle<AreaCollisionData> Unity.Entities.SystemState.GetComponentTypeHandle<AreaCollisionData>(bool)
		// Unity.Entities.ComponentTypeHandle<AutoDestroyTag> Unity.Entities.SystemState.GetComponentTypeHandle<AutoDestroyTag>(bool)
		// Unity.Entities.ComponentTypeHandle<BulletCollisionData> Unity.Entities.SystemState.GetComponentTypeHandle<BulletCollisionData>(bool)
		// Unity.Entities.ComponentTypeHandle<ChainHitData> Unity.Entities.SystemState.GetComponentTypeHandle<ChainHitData>(bool)
		// Unity.Entities.ComponentTypeHandle<HitParticleSpawnTag> Unity.Entities.SystemState.GetComponentTypeHandle<HitParticleSpawnTag>(bool)
		// Unity.Entities.ComponentTypeHandle<LockMonsterData> Unity.Entities.SystemState.GetComponentTypeHandle<LockMonsterData>(bool)
		// Unity.Entities.ComponentTypeHandle<MonsterDieNetworkData> Unity.Entities.SystemState.GetComponentTypeHandle<MonsterDieNetworkData>(bool)
		// Unity.Entities.ComponentTypeHandle<MonsterDieTag> Unity.Entities.SystemState.GetComponentTypeHandle<MonsterDieTag>(bool)
		// Unity.Entities.ComponentTypeHandle<MonsterHitTag> Unity.Entities.SystemState.GetComponentTypeHandle<MonsterHitTag>(bool)
		// Unity.Entities.ComponentTypeHandle<MonsterValue> Unity.Entities.SystemState.GetComponentTypeHandle<MonsterValue>(bool)
		// Unity.Entities.ComponentTypeHandle<MoveData> Unity.Entities.SystemState.GetComponentTypeHandle<MoveData>(bool)
		// Unity.Entities.ComponentTypeHandle<ParticleSpawnTag> Unity.Entities.SystemState.GetComponentTypeHandle<ParticleSpawnTag>(bool)
		// Unity.Entities.ComponentTypeHandle<SpawnData> Unity.Entities.SystemState.GetComponentTypeHandle<SpawnData>(bool)
		// Unity.Entities.ComponentTypeHandle<SpellAreaData> Unity.Entities.SystemState.GetComponentTypeHandle<SpellAreaData>(bool)
		// Unity.Entities.ComponentTypeHandle<SpellBulletData> Unity.Entities.SystemState.GetComponentTypeHandle<SpellBulletData>(bool)
		// Unity.Entities.ComponentTypeHandle<SpellHitNetworkData> Unity.Entities.SystemState.GetComponentTypeHandle<SpellHitNetworkData>(bool)
		// Unity.Entities.ComponentTypeHandle<SpellHitTag> Unity.Entities.SystemState.GetComponentTypeHandle<SpellHitTag>(bool)
		// System.Void Unity.Entities.SystemState.RequireForUpdate<AreaCollisionData>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<AutoDestroyTag>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<BulletCollisionData>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<ChainHitData>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<ClearAllTag>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<HeroFishing.Battle.BulletSpawnSys>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<HeroFishing.Battle.CollisionSys>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<HeroFishing.Battle.MonsterSpawnSys>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<HitParticleSpawnTag>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<LockMonsterData>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<MonsterDieNetworkData>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<MonsterDieTag>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<MonsterHitTag>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<MonsterValue>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<MoveData>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<ParticleSpawnTag>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<RefreshSceneTag>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<SpawnTag>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<SpellHitNetworkData>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<SpellHitTag>()
		// System.Void Unity.Entities.SystemState.RequireForUpdate<object>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<AlreadyUpdateTag>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<AreaCollisionData>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<AutoDestroyTag>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<BulletCollisionData>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<ChainHitData>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<ClearAllTag>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<FreezeTag>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<HeroFishing.Battle.BulletSpawnSys>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<HeroFishing.Battle.CollisionSys>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<HeroFishing.Battle.LocalTestSys>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<HeroFishing.Battle.MapGridData>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<HeroFishing.Battle.MonsterSpawnSys>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<HeroFishing.Battle.RemoveMonsterBoundaryData>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<HitInfoBuffer>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<HitParticleSpawnTag>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<LockMonsterData>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<MonsterBuffer>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<MonsterDieNetworkData>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<MonsterDieTag>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<MonsterFreezeTag>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<MonsterHitNetworkData>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<MonsterHitTag>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<MonsterValue>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<MoveData>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<ParticleSpawnTag>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<RefreshSceneTag>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<SpawnData>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<SpawnTag>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<SpellAreaData>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<SpellBulletData>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<SpellHitNetworkData>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<SpellHitTag>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<Unity.Entities.EndSimulationEntityCommandBufferSystem.Singleton>()
		// Unity.Entities.TypeIndex Unity.Entities.TypeManager.GetTypeIndex<object>()
		// Unity.Entities.TypeManager.TypeInfo& modreq(System.Runtime.InteropServices.InAttribute) Unity.Entities.TypeManager.GetTypeInfo<HitInfoBuffer>()
		// Unity.Entities.TypeManager.TypeInfo& modreq(System.Runtime.InteropServices.InAttribute) Unity.Entities.TypeManager.GetTypeInfo<MonsterBuffer>()
		// Unity.Entities.TypeManager.TypeInfo& modreq(System.Runtime.InteropServices.InAttribute) Unity.Entities.TypeManager.GetTypeInfo<MonsterHitNetworkData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<AlreadyUpdateTag>()
		// System.Void Unity.Entities.TypeManager.ManagedException<AreaCollisionData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<AutoDestroyTag>()
		// System.Void Unity.Entities.TypeManager.ManagedException<BulletCollisionData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<ChainHitData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<ClearAllTag>()
		// System.Void Unity.Entities.TypeManager.ManagedException<FreezeTag>()
		// System.Void Unity.Entities.TypeManager.ManagedException<HeroFishing.Battle.BulletSpawnSys>()
		// System.Void Unity.Entities.TypeManager.ManagedException<HeroFishing.Battle.CollisionSys>()
		// System.Void Unity.Entities.TypeManager.ManagedException<HeroFishing.Battle.LocalTestSys>()
		// System.Void Unity.Entities.TypeManager.ManagedException<HeroFishing.Battle.MapGridData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<HeroFishing.Battle.MonsterSpawnSys>()
		// System.Void Unity.Entities.TypeManager.ManagedException<HeroFishing.Battle.RemoveMonsterBoundaryData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<HitInfoBuffer>()
		// System.Void Unity.Entities.TypeManager.ManagedException<HitParticleSpawnTag>()
		// System.Void Unity.Entities.TypeManager.ManagedException<LockMonsterData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<MonsterBuffer>()
		// System.Void Unity.Entities.TypeManager.ManagedException<MonsterDieNetworkData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<MonsterDieTag>()
		// System.Void Unity.Entities.TypeManager.ManagedException<MonsterFreezeTag>()
		// System.Void Unity.Entities.TypeManager.ManagedException<MonsterHitNetworkData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<MonsterHitTag>()
		// System.Void Unity.Entities.TypeManager.ManagedException<MonsterValue>()
		// System.Void Unity.Entities.TypeManager.ManagedException<MoveData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<ParticleSpawnTag>()
		// System.Void Unity.Entities.TypeManager.ManagedException<RefreshSceneTag>()
		// System.Void Unity.Entities.TypeManager.ManagedException<SpawnData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<SpawnTag>()
		// System.Void Unity.Entities.TypeManager.ManagedException<SpellAreaData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<SpellBulletData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<SpellHitNetworkData>()
		// System.Void Unity.Entities.TypeManager.ManagedException<SpellHitTag>()
		// System.Void Unity.Entities.TypeManager.ManagedException<Unity.Entities.EndSimulationEntityCommandBufferSystem.Singleton>()
		// System.Void Unity.Entities.TypeManager.ManagedException<object>()
		// object Unity.VisualScripting.ComponentHolderProtocol.AddComponent<object>(UnityEngine.Object)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<object>(object)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<System.Collections.Generic.IList<object>> UnityEngine.AddressableAssets.Addressables.LoadAssetsAsync<object>(object,System.Action<object>)
		// System.Void UnityEngine.AddressableAssets.Addressables.Release<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>)
		// System.Void UnityEngine.AddressableAssets.AddressablesImpl.<AutoReleaseHandleOnCompletion>b__116_0<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>)
		// System.Void UnityEngine.AddressableAssets.AddressablesImpl.AutoReleaseHandleOnCompletion<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.AddressableAssets.AddressablesImpl.LoadAssetAsync<object>(object)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.AddressableAssets.AddressablesImpl.LoadAssetWithChain<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,object)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<System.Collections.Generic.IList<object>> UnityEngine.AddressableAssets.AddressablesImpl.LoadAssetsAsync<object>(System.Collections.Generic.IList<UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation>,System.Action<object>,bool)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<System.Collections.Generic.IList<object>> UnityEngine.AddressableAssets.AddressablesImpl.LoadAssetsAsync<object>(object,System.Action<object>,bool)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<System.Collections.Generic.IList<object>> UnityEngine.AddressableAssets.AddressablesImpl.LoadAssetsWithChain<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,System.Collections.Generic.IList<UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation>,System.Action<object>,bool)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<System.Collections.Generic.IList<object>> UnityEngine.AddressableAssets.AddressablesImpl.LoadAssetsWithChain<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,object,System.Action<object>,bool)
		// System.Void UnityEngine.AddressableAssets.AddressablesImpl.Release<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.AddressableAssets.AddressablesImpl.TrackHandle<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>)
		// int UnityEngine.AndroidJNIHelper.ConvertFromJNIArray<int>(System.IntPtr)
		// object UnityEngine.AndroidJNIHelper.ConvertFromJNIArray<object>(System.IntPtr)
		// System.IntPtr UnityEngine.AndroidJNIHelper.GetFieldID<object>(System.IntPtr,string,bool)
		// System.IntPtr UnityEngine.AndroidJNIHelper.GetMethodID<int>(System.IntPtr,string,object[],bool)
		// System.IntPtr UnityEngine.AndroidJNIHelper.GetMethodID<object>(System.IntPtr,string,object[],bool)
		// int UnityEngine.AndroidJavaObject.Call<int>(string,object[])
		// object UnityEngine.AndroidJavaObject.Call<object>(string,object[])
		// int UnityEngine.AndroidJavaObject.CallStatic<int>(string,object[])
		// int UnityEngine.AndroidJavaObject.FromJavaArrayDeleteLocalRef<int>(System.IntPtr)
		// object UnityEngine.AndroidJavaObject.FromJavaArrayDeleteLocalRef<object>(System.IntPtr)
		// object UnityEngine.AndroidJavaObject.GetStatic<object>(string)
		// int UnityEngine.AndroidJavaObject._Call<int>(System.IntPtr,object[])
		// int UnityEngine.AndroidJavaObject._Call<int>(string,object[])
		// object UnityEngine.AndroidJavaObject._Call<object>(System.IntPtr,object[])
		// object UnityEngine.AndroidJavaObject._Call<object>(string,object[])
		// int UnityEngine.AndroidJavaObject._CallStatic<int>(System.IntPtr,object[])
		// int UnityEngine.AndroidJavaObject._CallStatic<int>(string,object[])
		// object UnityEngine.AndroidJavaObject._GetStatic<object>(System.IntPtr)
		// object UnityEngine.AndroidJavaObject._GetStatic<object>(string)
		// object UnityEngine.Component.GetComponent<object>()
		// object UnityEngine.Component.GetComponentInChildren<object>()
		// object UnityEngine.Component.GetComponentInParent<object>()
		// object[] UnityEngine.Component.GetComponents<object>()
		// object[] UnityEngine.Component.GetComponentsInChildren<object>()
		// object[] UnityEngine.Component.GetComponentsInChildren<object>(bool)
		// object UnityEngine.GameObject.AddComponent<object>()
		// object UnityEngine.GameObject.GetComponent<object>()
		// object UnityEngine.GameObject.GetComponentInChildren<object>()
		// object UnityEngine.GameObject.GetComponentInChildren<object>(bool)
		// object[] UnityEngine.GameObject.GetComponents<object>()
		// object[] UnityEngine.GameObject.GetComponentsInChildren<object>(bool)
		// bool UnityEngine.GameObject.TryGetComponent<object>(object&)
		// object UnityEngine.Object.FindObjectOfType<object>()
		// object UnityEngine.Object.Instantiate<object>(object)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform,bool)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Vector3,UnityEngine.Quaternion)
		// bool UnityEngine.Rendering.VolumeProfile.TryGet<object>(System.Type,object&)
		// bool UnityEngine.Rendering.VolumeProfile.TryGet<object>(object&)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle.Convert<object>()
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.ResourceManager.CreateChainOperation<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,System.Func<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>>)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.ResourceManager.CreateChainOperation<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,System.Func<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>>,bool)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.ResourceManager.CreateCompletedOperation<object>(object,string)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.ResourceManager.CreateCompletedOperationInternal<object>(object,bool,System.Exception,bool)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.ResourceManager.CreateCompletedOperationWithException<object>(object,System.Exception)
		// object UnityEngine.ResourceManagement.ResourceManager.CreateOperation<object>(System.Type,int,UnityEngine.ResourceManagement.Util.IOperationCacheKey,System.Action<UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation>)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.ResourceManager.ProvideResource<object>(UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<System.Collections.Generic.IList<object>> UnityEngine.ResourceManagement.ResourceManager.ProvideResources<object>(System.Collections.Generic.IList<UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation>,bool,System.Action<object>)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.ResourceManager.StartOperation<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase<object>,UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle)
		// object UnityEngine.Resources.GetBuiltinResource<object>(string)
		// object UnityEngine.Resources.Load<object>(string)
		// int UnityEngine._AndroidJNIHelper.ConvertFromJNIArray<int>(System.IntPtr)
		// object UnityEngine._AndroidJNIHelper.ConvertFromJNIArray<object>(System.IntPtr)
		// System.IntPtr UnityEngine._AndroidJNIHelper.GetFieldID<object>(System.IntPtr,string,bool)
		// System.IntPtr UnityEngine._AndroidJNIHelper.GetMethodID<int>(System.IntPtr,string,object[],bool)
		// System.IntPtr UnityEngine._AndroidJNIHelper.GetMethodID<object>(System.IntPtr,string,object[],bool)
		// string UnityEngine._AndroidJNIHelper.GetSignature<int>(object[])
		// string UnityEngine._AndroidJNIHelper.GetSignature<object>(object[])
	}
}