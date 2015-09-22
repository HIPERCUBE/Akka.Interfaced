// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Akka.Interfaced CodeGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Interfaced;
using ProtoBuf;
using TypeAlias;

#region SlimUnityChat.Interface.IOccupant

namespace SlimUnityChat.Interface
{
    [MessageTableForInterfacedActor(typeof(IOccupant))]
    public static class IOccupant__MessageTable
    {
        public static Type[,] GetMessageTypes()
        {
            return new Type[,]
            {
                {typeof(IOccupant__Say__Invoke), null},
                {typeof(IOccupant__GetHistory__Invoke), typeof(IOccupant__GetHistory__Return)},
                {typeof(IOccupant__Invite__Invoke), null},
            };
        }
    }

    [ProtoContract, TypeAlias]
    public class IOccupant__Say__Invoke : IInterfacedMessage, ITagOverridable, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String msg;
        [ProtoMember(2)] public System.String senderUserId;

        public Type GetInterfaceType() { return typeof(IOccupant); }

        public void SetTag(object value) { senderUserId = (System.String)value; }

        public async Task<IValueGetable> Invoke(object target)
        {
            await ((IOccupant)target).Say(msg, senderUserId);
            return null;
        }
    }

    [ProtoContract, TypeAlias]
    public class IOccupant__GetHistory__Invoke : IInterfacedMessage, ITagOverridable, IAsyncInvokable
    {
        public Type GetInterfaceType() { return typeof(IOccupant); }

        public void SetTag(object value) { }

        public async Task<IValueGetable> Invoke(object target)
        {
            var __v = await((IOccupant)target).GetHistory();
            return (IValueGetable)(new IOccupant__GetHistory__Return { v = (System.Collections.Generic.List<SlimUnityChat.Interface.ChatItem>)__v });
        }
    }

    [ProtoContract, TypeAlias]
    public class IOccupant__GetHistory__Return : IInterfacedMessage, IValueGetable
    {
        [ProtoMember(1)] public System.Collections.Generic.List<SlimUnityChat.Interface.ChatItem> v;

        public Type GetInterfaceType() { return typeof(IOccupant); }

        public object Value { get { return v; } }
    }

    [ProtoContract, TypeAlias]
    public class IOccupant__Invite__Invoke : IInterfacedMessage, ITagOverridable, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String targetUserId;
        [ProtoMember(2)] public System.String senderUserId;

        public Type GetInterfaceType() { return typeof(IOccupant); }

        public void SetTag(object value) { senderUserId = (System.String)value; }

        public async Task<IValueGetable> Invoke(object target)
        {
            await ((IOccupant)target).Invite(targetUserId, senderUserId);
            return null;
        }
    }

    [ProtoContract, TypeAlias]
    public class OccupantRef : InterfacedActorRef, IOccupant
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return (ActorRefBase)Actor; }
            set { Actor = value; }
        }

        private OccupantRef()
            : base(null)
        {
        }

        public OccupantRef(IActorRef actor)
            : base(actor)
        {
        }

        public OccupantRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout)
            : base(actor, requestWaiter, timeout)
        {
        }

        public OccupantRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new OccupantRef(Actor, requestWaiter, Timeout);
        }

        public OccupantRef WithTimeout(TimeSpan? timeout)
        {
            return new OccupantRef(Actor, RequestWaiter, timeout);
        }

        public Task Say(System.String msg, System.String senderUserId = null)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IOccupant__Say__Invoke { msg = msg, senderUserId = senderUserId }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task<System.Collections.Generic.List<SlimUnityChat.Interface.ChatItem>> GetHistory()
        {
            var requestMessage = new RequestMessage
            {
                Message = new IOccupant__GetHistory__Invoke {  }
            };
            return SendRequestAndReceive<System.Collections.Generic.List<SlimUnityChat.Interface.ChatItem>>(requestMessage);
        }

        public Task Invite(System.String targetUserId, System.String senderUserId = null)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IOccupant__Invite__Invoke { targetUserId = targetUserId, senderUserId = senderUserId }
            };
            return SendRequestAndWait(requestMessage);
        }
    }
}

#endregion

#region SlimUnityChat.Interface.IRoom

namespace SlimUnityChat.Interface
{
    [MessageTableForInterfacedActor(typeof(IRoom))]
    public static class IRoom__MessageTable
    {
        public static Type[,] GetMessageTypes()
        {
            return new Type[,]
            {
                {typeof(IRoom__Enter__Invoke), typeof(IRoom__Enter__Return)},
                {typeof(IRoom__Exit__Invoke), null},
            };
        }
    }

    [ProtoContract, TypeAlias]
    public class IRoom__Enter__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String userId;
        [ProtoMember(2)] public SlimUnityChat.Interface.RoomObserver observer;

        public Type GetInterfaceType() { return typeof(IRoom); }

        public async Task<IValueGetable> Invoke(object target)
        {
            var __v = await((IRoom)target).Enter(userId, observer);
            return (IValueGetable)(new IRoom__Enter__Return { v = __v });
        }
    }

    [ProtoContract, TypeAlias]
    public class IRoom__Enter__Return : IInterfacedMessage, IValueGetable
    {
        [ProtoMember(1)] public SlimUnityChat.Interface.RoomInfo v;

        public Type GetInterfaceType() { return typeof(IRoom); }

        public object Value { get { return v; } }
    }

    [ProtoContract, TypeAlias]
    public class IRoom__Exit__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String userId;

        public Type GetInterfaceType() { return typeof(IRoom); }

        public async Task<IValueGetable> Invoke(object target)
        {
            await ((IRoom)target).Exit(userId);
            return null;
        }
    }

    [ProtoContract, TypeAlias]
    public class RoomRef : InterfacedActorRef, IRoom
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return (ActorRefBase)Actor; }
            set { Actor = value; }
        }

        private RoomRef()
            : base(null)
        {
        }

        public RoomRef(IActorRef actor)
            : base(actor)
        {
        }

        public RoomRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout)
            : base(actor, requestWaiter, timeout)
        {
        }

        public RoomRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new RoomRef(Actor, requestWaiter, Timeout);
        }

        public RoomRef WithTimeout(TimeSpan? timeout)
        {
            return new RoomRef(Actor, RequestWaiter, timeout);
        }

        public Task<SlimUnityChat.Interface.RoomInfo> Enter(System.String userId, SlimUnityChat.Interface.IRoomObserver observer)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IRoom__Enter__Invoke { userId = userId, observer = (SlimUnityChat.Interface.RoomObserver)observer }
            };
            return SendRequestAndReceive<SlimUnityChat.Interface.RoomInfo>(requestMessage);
        }

        public Task Exit(System.String userId)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IRoom__Exit__Invoke { userId = userId }
            };
            return SendRequestAndWait(requestMessage);
        }
    }
}

#endregion

#region SlimUnityChat.Interface.IRoomDirectory

namespace SlimUnityChat.Interface
{
    [MessageTableForInterfacedActor(typeof(IRoomDirectory))]
    public static class IRoomDirectory__MessageTable
    {
        public static Type[,] GetMessageTypes()
        {
            return new Type[,]
            {
                {typeof(IRoomDirectory__GetOrCreateRoom__Invoke), typeof(IRoomDirectory__GetOrCreateRoom__Return)},
                {typeof(IRoomDirectory__RemoveRoom__Invoke), null},
                {typeof(IRoomDirectory__GetRoomList__Invoke), typeof(IRoomDirectory__GetRoomList__Return)},
            };
        }
    }

    [ProtoContract, TypeAlias]
    public class IRoomDirectory__GetOrCreateRoom__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String name;

        public Type GetInterfaceType() { return typeof(IRoomDirectory); }

        public async Task<IValueGetable> Invoke(object target)
        {
            var __v = await((IRoomDirectory)target).GetOrCreateRoom(name);
            return (IValueGetable)(new IRoomDirectory__GetOrCreateRoom__Return { v = (SlimUnityChat.Interface.RoomRef)__v });
        }
    }

    [ProtoContract, TypeAlias]
    public class IRoomDirectory__GetOrCreateRoom__Return : IInterfacedMessage, IValueGetable
    {
        [ProtoMember(1)] public SlimUnityChat.Interface.RoomRef v;

        public Type GetInterfaceType() { return typeof(IRoomDirectory); }

        public object Value { get { return v; } }
    }

    [ProtoContract, TypeAlias]
    public class IRoomDirectory__RemoveRoom__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String name;

        public Type GetInterfaceType() { return typeof(IRoomDirectory); }

        public async Task<IValueGetable> Invoke(object target)
        {
            await ((IRoomDirectory)target).RemoveRoom(name);
            return null;
        }
    }

    [ProtoContract, TypeAlias]
    public class IRoomDirectory__GetRoomList__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        public Type GetInterfaceType() { return typeof(IRoomDirectory); }

        public async Task<IValueGetable> Invoke(object target)
        {
            var __v = await((IRoomDirectory)target).GetRoomList();
            return (IValueGetable)(new IRoomDirectory__GetRoomList__Return { v = (System.Collections.Generic.List<System.String>)__v });
        }
    }

    [ProtoContract, TypeAlias]
    public class IRoomDirectory__GetRoomList__Return : IInterfacedMessage, IValueGetable
    {
        [ProtoMember(1)] public System.Collections.Generic.List<System.String> v;

        public Type GetInterfaceType() { return typeof(IRoomDirectory); }

        public object Value { get { return v; } }
    }

    [ProtoContract, TypeAlias]
    public class RoomDirectoryRef : InterfacedActorRef, IRoomDirectory
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return (ActorRefBase)Actor; }
            set { Actor = value; }
        }

        private RoomDirectoryRef()
            : base(null)
        {
        }

        public RoomDirectoryRef(IActorRef actor)
            : base(actor)
        {
        }

        public RoomDirectoryRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout)
            : base(actor, requestWaiter, timeout)
        {
        }

        public RoomDirectoryRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new RoomDirectoryRef(Actor, requestWaiter, Timeout);
        }

        public RoomDirectoryRef WithTimeout(TimeSpan? timeout)
        {
            return new RoomDirectoryRef(Actor, RequestWaiter, timeout);
        }

        public Task<SlimUnityChat.Interface.IRoom> GetOrCreateRoom(System.String name)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IRoomDirectory__GetOrCreateRoom__Invoke { name = name }
            };
            return SendRequestAndReceive<SlimUnityChat.Interface.IRoom>(requestMessage);
        }

        public Task RemoveRoom(System.String name)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IRoomDirectory__RemoveRoom__Invoke { name = name }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task<System.Collections.Generic.List<System.String>> GetRoomList()
        {
            var requestMessage = new RequestMessage
            {
                Message = new IRoomDirectory__GetRoomList__Invoke {  }
            };
            return SendRequestAndReceive<System.Collections.Generic.List<System.String>>(requestMessage);
        }
    }
}

#endregion

#region SlimUnityChat.Interface.IRoomDirectoryWorker

namespace SlimUnityChat.Interface
{
    [MessageTableForInterfacedActor(typeof(IRoomDirectoryWorker))]
    public static class IRoomDirectoryWorker__MessageTable
    {
        public static Type[,] GetMessageTypes()
        {
            return new Type[,]
            {
                {typeof(IRoomDirectoryWorker__CreateRoom__Invoke), typeof(IRoomDirectoryWorker__CreateRoom__Return)},
                {typeof(IRoomDirectoryWorker__RemoveRoom__Invoke), null},
            };
        }
    }

    [ProtoContract, TypeAlias]
    public class IRoomDirectoryWorker__CreateRoom__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String name;

        public Type GetInterfaceType() { return typeof(IRoomDirectoryWorker); }

        public async Task<IValueGetable> Invoke(object target)
        {
            var __v = await((IRoomDirectoryWorker)target).CreateRoom(name);
            return (IValueGetable)(new IRoomDirectoryWorker__CreateRoom__Return { v = (SlimUnityChat.Interface.RoomRef)__v });
        }
    }

    [ProtoContract, TypeAlias]
    public class IRoomDirectoryWorker__CreateRoom__Return : IInterfacedMessage, IValueGetable
    {
        [ProtoMember(1)] public SlimUnityChat.Interface.RoomRef v;

        public Type GetInterfaceType() { return typeof(IRoomDirectoryWorker); }

        public object Value { get { return v; } }
    }

    [ProtoContract, TypeAlias]
    public class IRoomDirectoryWorker__RemoveRoom__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String name;

        public Type GetInterfaceType() { return typeof(IRoomDirectoryWorker); }

        public async Task<IValueGetable> Invoke(object target)
        {
            await ((IRoomDirectoryWorker)target).RemoveRoom(name);
            return null;
        }
    }

    [ProtoContract, TypeAlias]
    public class RoomDirectoryWorkerRef : InterfacedActorRef, IRoomDirectoryWorker
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return (ActorRefBase)Actor; }
            set { Actor = value; }
        }

        private RoomDirectoryWorkerRef()
            : base(null)
        {
        }

        public RoomDirectoryWorkerRef(IActorRef actor)
            : base(actor)
        {
        }

        public RoomDirectoryWorkerRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout)
            : base(actor, requestWaiter, timeout)
        {
        }

        public RoomDirectoryWorkerRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new RoomDirectoryWorkerRef(Actor, requestWaiter, Timeout);
        }

        public RoomDirectoryWorkerRef WithTimeout(TimeSpan? timeout)
        {
            return new RoomDirectoryWorkerRef(Actor, RequestWaiter, timeout);
        }

        public Task<SlimUnityChat.Interface.IRoom> CreateRoom(System.String name)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IRoomDirectoryWorker__CreateRoom__Invoke { name = name }
            };
            return SendRequestAndReceive<SlimUnityChat.Interface.IRoom>(requestMessage);
        }

        public Task RemoveRoom(System.String name)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IRoomDirectoryWorker__RemoveRoom__Invoke { name = name }
            };
            return SendRequestAndWait(requestMessage);
        }
    }
}

#endregion

#region SlimUnityChat.Interface.IUser

namespace SlimUnityChat.Interface
{
    [MessageTableForInterfacedActor(typeof(IUser))]
    public static class IUser__MessageTable
    {
        public static Type[,] GetMessageTypes()
        {
            return new Type[,]
            {
                {typeof(IUser__GetId__Invoke), typeof(IUser__GetId__Return)},
                {typeof(IUser__GetRoomList__Invoke), typeof(IUser__GetRoomList__Return)},
                {typeof(IUser__EnterRoom__Invoke), typeof(IUser__EnterRoom__Return)},
                {typeof(IUser__ExitFromRoom__Invoke), null},
                {typeof(IUser__Whisper__Invoke), null},
            };
        }
    }

    [ProtoContract, TypeAlias]
    public class IUser__GetId__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        public Type GetInterfaceType() { return typeof(IUser); }

        public async Task<IValueGetable> Invoke(object target)
        {
            var __v = await((IUser)target).GetId();
            return (IValueGetable)(new IUser__GetId__Return { v = __v });
        }
    }

    [ProtoContract, TypeAlias]
    public class IUser__GetId__Return : IInterfacedMessage, IValueGetable
    {
        [ProtoMember(1)] public System.String v;

        public Type GetInterfaceType() { return typeof(IUser); }

        public object Value { get { return v; } }
    }

    [ProtoContract, TypeAlias]
    public class IUser__GetRoomList__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        public Type GetInterfaceType() { return typeof(IUser); }

        public async Task<IValueGetable> Invoke(object target)
        {
            var __v = await((IUser)target).GetRoomList();
            return (IValueGetable)(new IUser__GetRoomList__Return { v = (System.Collections.Generic.List<System.String>)__v });
        }
    }

    [ProtoContract, TypeAlias]
    public class IUser__GetRoomList__Return : IInterfacedMessage, IValueGetable
    {
        [ProtoMember(1)] public System.Collections.Generic.List<System.String> v;

        public Type GetInterfaceType() { return typeof(IUser); }

        public object Value { get { return v; } }
    }

    [ProtoContract, TypeAlias]
    public class IUser__EnterRoom__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String name;
        [ProtoMember(2)] public System.Int32 observerId;

        public Type GetInterfaceType() { return typeof(IUser); }

        public async Task<IValueGetable> Invoke(object target)
        {
            var __v = await((IUser)target).EnterRoom(name, observerId);
            return (IValueGetable)(new IUser__EnterRoom__Return { v = (System.Tuple<System.Int32, SlimUnityChat.Interface.RoomInfo>)__v });
        }
    }

    [ProtoContract, TypeAlias]
    public class IUser__EnterRoom__Return : IInterfacedMessage, IValueGetable
    {
        [ProtoMember(1)] public System.Tuple<System.Int32, SlimUnityChat.Interface.RoomInfo> v;

        public Type GetInterfaceType() { return typeof(IUser); }

        public object Value { get { return v; } }
    }

    [ProtoContract, TypeAlias]
    public class IUser__ExitFromRoom__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String name;

        public Type GetInterfaceType() { return typeof(IUser); }

        public async Task<IValueGetable> Invoke(object target)
        {
            await ((IUser)target).ExitFromRoom(name);
            return null;
        }
    }

    [ProtoContract, TypeAlias]
    public class IUser__Whisper__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String targetUserId;
        [ProtoMember(2)] public System.String message;

        public Type GetInterfaceType() { return typeof(IUser); }

        public async Task<IValueGetable> Invoke(object target)
        {
            await ((IUser)target).Whisper(targetUserId, message);
            return null;
        }
    }

    [ProtoContract, TypeAlias]
    public class UserRef : InterfacedActorRef, IUser
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return (ActorRefBase)Actor; }
            set { Actor = value; }
        }

        private UserRef()
            : base(null)
        {
        }

        public UserRef(IActorRef actor)
            : base(actor)
        {
        }

        public UserRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout)
            : base(actor, requestWaiter, timeout)
        {
        }

        public UserRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new UserRef(Actor, requestWaiter, Timeout);
        }

        public UserRef WithTimeout(TimeSpan? timeout)
        {
            return new UserRef(Actor, RequestWaiter, timeout);
        }

        public Task<System.String> GetId()
        {
            var requestMessage = new RequestMessage
            {
                Message = new IUser__GetId__Invoke {  }
            };
            return SendRequestAndReceive<System.String>(requestMessage);
        }

        public Task<System.Collections.Generic.List<System.String>> GetRoomList()
        {
            var requestMessage = new RequestMessage
            {
                Message = new IUser__GetRoomList__Invoke {  }
            };
            return SendRequestAndReceive<System.Collections.Generic.List<System.String>>(requestMessage);
        }

        public Task<System.Tuple<System.Int32, SlimUnityChat.Interface.RoomInfo>> EnterRoom(System.String name, System.Int32 observerId)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IUser__EnterRoom__Invoke { name = name, observerId = observerId }
            };
            return SendRequestAndReceive<System.Tuple<System.Int32, SlimUnityChat.Interface.RoomInfo>>(requestMessage);
        }

        public Task ExitFromRoom(System.String name)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IUser__ExitFromRoom__Invoke { name = name }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task Whisper(System.String targetUserId, System.String message)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IUser__Whisper__Invoke { targetUserId = targetUserId, message = message }
            };
            return SendRequestAndWait(requestMessage);
        }
    }
}

#endregion

#region SlimUnityChat.Interface.IUserDirectory

namespace SlimUnityChat.Interface
{
    [MessageTableForInterfacedActor(typeof(IUserDirectory))]
    public static class IUserDirectory__MessageTable
    {
        public static Type[,] GetMessageTypes()
        {
            return new Type[,]
            {
                {typeof(IUserDirectory__RegisterUser__Invoke), null},
                {typeof(IUserDirectory__UnregisterUser__Invoke), null},
                {typeof(IUserDirectory__GetUser__Invoke), typeof(IUserDirectory__GetUser__Return)},
            };
        }
    }

    [ProtoContract, TypeAlias]
    public class IUserDirectory__RegisterUser__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String userId;
        [ProtoMember(2)] public SlimUnityChat.Interface.UserRef user;

        public Type GetInterfaceType() { return typeof(IUserDirectory); }

        public async Task<IValueGetable> Invoke(object target)
        {
            await ((IUserDirectory)target).RegisterUser(userId, user);
            return null;
        }
    }

    [ProtoContract, TypeAlias]
    public class IUserDirectory__UnregisterUser__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String userId;

        public Type GetInterfaceType() { return typeof(IUserDirectory); }

        public async Task<IValueGetable> Invoke(object target)
        {
            await ((IUserDirectory)target).UnregisterUser(userId);
            return null;
        }
    }

    [ProtoContract, TypeAlias]
    public class IUserDirectory__GetUser__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String userId;

        public Type GetInterfaceType() { return typeof(IUserDirectory); }

        public async Task<IValueGetable> Invoke(object target)
        {
            var __v = await((IUserDirectory)target).GetUser(userId);
            return (IValueGetable)(new IUserDirectory__GetUser__Return { v = (SlimUnityChat.Interface.UserRef)__v });
        }
    }

    [ProtoContract, TypeAlias]
    public class IUserDirectory__GetUser__Return : IInterfacedMessage, IValueGetable
    {
        [ProtoMember(1)] public SlimUnityChat.Interface.UserRef v;

        public Type GetInterfaceType() { return typeof(IUserDirectory); }

        public object Value { get { return v; } }
    }

    [ProtoContract, TypeAlias]
    public class UserDirectoryRef : InterfacedActorRef, IUserDirectory
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return (ActorRefBase)Actor; }
            set { Actor = value; }
        }

        private UserDirectoryRef()
            : base(null)
        {
        }

        public UserDirectoryRef(IActorRef actor)
            : base(actor)
        {
        }

        public UserDirectoryRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout)
            : base(actor, requestWaiter, timeout)
        {
        }

        public UserDirectoryRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new UserDirectoryRef(Actor, requestWaiter, Timeout);
        }

        public UserDirectoryRef WithTimeout(TimeSpan? timeout)
        {
            return new UserDirectoryRef(Actor, RequestWaiter, timeout);
        }

        public Task RegisterUser(System.String userId, SlimUnityChat.Interface.IUser user)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IUserDirectory__RegisterUser__Invoke { userId = userId, user = (SlimUnityChat.Interface.UserRef)user }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task UnregisterUser(System.String userId)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IUserDirectory__UnregisterUser__Invoke { userId = userId }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task<SlimUnityChat.Interface.IUser> GetUser(System.String userId)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IUserDirectory__GetUser__Invoke { userId = userId }
            };
            return SendRequestAndReceive<SlimUnityChat.Interface.IUser>(requestMessage);
        }
    }
}

#endregion

#region SlimUnityChat.Interface.IUserLogin

namespace SlimUnityChat.Interface
{
    [MessageTableForInterfacedActor(typeof(IUserLogin))]
    public static class IUserLogin__MessageTable
    {
        public static Type[,] GetMessageTypes()
        {
            return new Type[,]
            {
                {typeof(IUserLogin__Login__Invoke), typeof(IUserLogin__Login__Return)},
            };
        }
    }

    [ProtoContract, TypeAlias]
    public class IUserLogin__Login__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String id;
        [ProtoMember(2)] public System.String password;
        [ProtoMember(3)] public System.Int32 observerId;

        public Type GetInterfaceType() { return typeof(IUserLogin); }

        public async Task<IValueGetable> Invoke(object target)
        {
            var __v = await((IUserLogin)target).Login(id, password, observerId);
            return (IValueGetable)(new IUserLogin__Login__Return { v = __v });
        }
    }

    [ProtoContract, TypeAlias]
    public class IUserLogin__Login__Return : IInterfacedMessage, IValueGetable
    {
        [ProtoMember(1)] public System.Int32 v;

        public Type GetInterfaceType() { return typeof(IUserLogin); }

        public object Value { get { return v; } }
    }

    [ProtoContract, TypeAlias]
    public class UserLoginRef : InterfacedActorRef, IUserLogin
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return (ActorRefBase)Actor; }
            set { Actor = value; }
        }

        private UserLoginRef()
            : base(null)
        {
        }

        public UserLoginRef(IActorRef actor)
            : base(actor)
        {
        }

        public UserLoginRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout)
            : base(actor, requestWaiter, timeout)
        {
        }

        public UserLoginRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new UserLoginRef(Actor, requestWaiter, Timeout);
        }

        public UserLoginRef WithTimeout(TimeSpan? timeout)
        {
            return new UserLoginRef(Actor, RequestWaiter, timeout);
        }

        public Task<System.Int32> Login(System.String id, System.String password, System.Int32 observerId)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IUserLogin__Login__Invoke { id = id, password = password, observerId = observerId }
            };
            return SendRequestAndReceive<System.Int32>(requestMessage);
        }
    }
}

#endregion

#region SlimUnityChat.Interface.IUserMessasing

namespace SlimUnityChat.Interface
{
    [MessageTableForInterfacedActor(typeof(IUserMessasing))]
    public static class IUserMessasing__MessageTable
    {
        public static Type[,] GetMessageTypes()
        {
            return new Type[,]
            {
                {typeof(IUserMessasing__Whisper__Invoke), null},
                {typeof(IUserMessasing__Invite__Invoke), null},
            };
        }
    }

    [ProtoContract, TypeAlias]
    public class IUserMessasing__Whisper__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public SlimUnityChat.Interface.ChatItem chatItem;

        public Type GetInterfaceType() { return typeof(IUserMessasing); }

        public async Task<IValueGetable> Invoke(object target)
        {
            await ((IUserMessasing)target).Whisper(chatItem);
            return null;
        }
    }

    [ProtoContract, TypeAlias]
    public class IUserMessasing__Invite__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        [ProtoMember(1)] public System.String invitorUserId;
        [ProtoMember(2)] public System.String roomName;

        public Type GetInterfaceType() { return typeof(IUserMessasing); }

        public async Task<IValueGetable> Invoke(object target)
        {
            await ((IUserMessasing)target).Invite(invitorUserId, roomName);
            return null;
        }
    }

    [ProtoContract, TypeAlias]
    public class UserMessasingRef : InterfacedActorRef, IUserMessasing
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return (ActorRefBase)Actor; }
            set { Actor = value; }
        }

        private UserMessasingRef()
            : base(null)
        {
        }

        public UserMessasingRef(IActorRef actor)
            : base(actor)
        {
        }

        public UserMessasingRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout)
            : base(actor, requestWaiter, timeout)
        {
        }

        public UserMessasingRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new UserMessasingRef(Actor, requestWaiter, Timeout);
        }

        public UserMessasingRef WithTimeout(TimeSpan? timeout)
        {
            return new UserMessasingRef(Actor, RequestWaiter, timeout);
        }

        public Task Whisper(SlimUnityChat.Interface.ChatItem chatItem)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IUserMessasing__Whisper__Invoke { chatItem = chatItem }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task Invite(System.String invitorUserId, System.String roomName)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IUserMessasing__Invite__Invoke { invitorUserId = invitorUserId, roomName = roomName }
            };
            return SendRequestAndWait(requestMessage);
        }
    }
}

#endregion

#region SlimUnityChat.Interface.IRoomObserver

namespace SlimUnityChat.Interface
{
    [ProtoContract, TypeAlias]
    public class IRoomObserver__Enter__Invoke : IInvokable
    {
        [ProtoMember(1)] public System.String userId;

        public void Invoke(object target)
        {
            ((IRoomObserver)target).Enter(userId);
        }
    }

    [ProtoContract, TypeAlias]
    public class IRoomObserver__Exit__Invoke : IInvokable
    {
        [ProtoMember(1)] public System.String userId;

        public void Invoke(object target)
        {
            ((IRoomObserver)target).Exit(userId);
        }
    }

    [ProtoContract, TypeAlias]
    public class IRoomObserver__Say__Invoke : IInvokable
    {
        [ProtoMember(1)] public SlimUnityChat.Interface.ChatItem chatItem;

        public void Invoke(object target)
        {
            ((IRoomObserver)target).Say(chatItem);
        }
    }

    [ProtoContract, TypeAlias]
    public class RoomObserver : InterfacedObserver, IRoomObserver
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return Channel != null ? (ActorRefBase)(((ActorNotificationChannel)Channel).Actor) : null; }
            set { Channel = new ActorNotificationChannel(value); }
        }

        [ProtoMember(2)] private int _observerId
        {
            get { return ObserverId; }
            set { ObserverId = value; }
        }

        private RoomObserver()
            : base(null, 0)
        {
        }

        public RoomObserver(INotificationChannel channel, int observerId)
            : base(channel, observerId)
        {
        }

        public void Enter(System.String userId)
        {
            var message = new IRoomObserver__Enter__Invoke { userId = userId };
            Notify(message);
        }

        public void Exit(System.String userId)
        {
            var message = new IRoomObserver__Exit__Invoke { userId = userId };
            Notify(message);
        }

        public void Say(SlimUnityChat.Interface.ChatItem chatItem)
        {
            var message = new IRoomObserver__Say__Invoke { chatItem = chatItem };
            Notify(message);
        }
    }
}

#endregion

#region SlimUnityChat.Interface.IUserEventObserver

namespace SlimUnityChat.Interface
{
    [ProtoContract, TypeAlias]
    public class IUserEventObserver__Whisper__Invoke : IInvokable
    {
        [ProtoMember(1)] public SlimUnityChat.Interface.ChatItem chatItem;

        public void Invoke(object target)
        {
            ((IUserEventObserver)target).Whisper(chatItem);
        }
    }

    [ProtoContract, TypeAlias]
    public class IUserEventObserver__Invite__Invoke : IInvokable
    {
        [ProtoMember(1)] public System.String invitorUserId;
        [ProtoMember(2)] public System.String roomName;

        public void Invoke(object target)
        {
            ((IUserEventObserver)target).Invite(invitorUserId, roomName);
        }
    }

    [ProtoContract, TypeAlias]
    public class UserEventObserver : InterfacedObserver, IUserEventObserver
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return Channel != null ? (ActorRefBase)(((ActorNotificationChannel)Channel).Actor) : null; }
            set { Channel = new ActorNotificationChannel(value); }
        }

        [ProtoMember(2)] private int _observerId
        {
            get { return ObserverId; }
            set { ObserverId = value; }
        }

        private UserEventObserver()
            : base(null, 0)
        {
        }

        public UserEventObserver(INotificationChannel channel, int observerId)
            : base(channel, observerId)
        {
        }

        public void Whisper(SlimUnityChat.Interface.ChatItem chatItem)
        {
            var message = new IUserEventObserver__Whisper__Invoke { chatItem = chatItem };
            Notify(message);
        }

        public void Invite(System.String invitorUserId, System.String roomName)
        {
            var message = new IUserEventObserver__Invite__Invoke { invitorUserId = invitorUserId, roomName = roomName };
            Notify(message);
        }
    }
}

#endregion