namespace NWN
{
    public class NWObjectBase
    {
        public uint OID {get; protected set;}
        public class EventScripts
        {
            private NWObjectBase owner;
            public EventScripts(NWObjectBase owner) { this.owner = owner; }
            public string this[EventScript key]
            {
                get => NWScript.GetEventScript(owner, (int)key);
                set => NWScript.SetEventScript(owner, (int)key, value);
            }
        }

        public AllLocals Locals;
        public EventScripts Scripts;

        public NWObjectBase(uint oid)
        {
            OID = oid;
            Locals = new AllLocals(this);
            Scripts = new EventScripts(this);
        }

        public const uint OBJECT_INVALID = 0x7F000000;
        public static uint OBJECT_SELF { get { return Internal.OBJECT_SELF; } }


        public static bool operator ==(NWObjectBase lhs, NWObjectBase rhs)
        {
            bool lhsNull = object.ReferenceEquals(lhs, null);
            bool rhsNull = object.ReferenceEquals(rhs, null);
            return (lhsNull && rhsNull) || (!lhsNull && !rhsNull && lhs.OID == rhs.OID);
        }

        public static bool operator !=(NWObjectBase lhs, NWObjectBase rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object o)
        {
            NWObjectBase other = o as NWObjectBase;
            return other != null && other == this;
        }

        public override int GetHashCode()
        {
            return (int)OID;
        }

        public static implicit operator uint(NWObjectBase obj) => obj.OID;
        public static implicit operator bool(NWObjectBase obj) => obj != null && obj.OID != NWScript.OBJECT_INVALID;
        public ObjectType ObjectType => (ObjectType)NWScript.GetObjectType(this);

        public virtual string Name
        {
            get => NWScript.GetName(this);
            set => NWScript.SetName(this, value);
        }
        public virtual string Tag
        {
            get => NWScript.GetTag(this);
            set => NWScript.SetTag(this, value);
        }
        public virtual string ResRef => NWScript.GetResRef(this);
        public virtual bool IsValid => this != null && NWScript.GetIsObjectValid(this) == 1;
        public virtual void AssignCommand(ActionDelegate action)
        {
            NWScript.AssignCommand(this, action);
        }
    }

}
