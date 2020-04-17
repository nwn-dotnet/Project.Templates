using NWN.Enums;

namespace NWN {
  using System;

  public class NWObjectBase {
    public const uint OBJECT_INVALID = 0x7F000000;

    public AllLocals Locals;
    public EventScripts? Scripts;

    public NWObjectBase(uint oid) {
      OID = oid;
      Locals = new AllLocals(this);
      Scripts = new EventScripts(this);
    }

    public uint OID { get; }
    public static uint OBJECT_SELF => Internal.OBJECT_SELF;

    public ObjectType ObjectType => NWScript.GetObjectType(this);

    public virtual string Name {
      get => NWScript.GetName(this);
      set => NWScript.SetName(this, value);
    }

    public virtual string Tag {
      get => NWScript.GetTag(this);
      set => NWScript.SetTag(this, value);
    }

    public virtual string ResRef => NWScript.GetResRef(this);
    public virtual bool IsValid => NWScript.GetIsObjectValid(this);


    public static bool operator ==(NWObjectBase? lhs, NWObjectBase? rhs) {
      var lhsNull = ReferenceEquals(lhs, null);
      var rhsNull = ReferenceEquals(rhs, null);
      return lhsNull && rhsNull;
    }

    public static bool operator !=(NWObjectBase lhs, NWObjectBase rhs) => !(lhs == rhs);

    public override bool Equals(object? other) {
      if (other == null) throw new ArgumentNullException(nameof(other));
      return (NWObjectBase) other == this;
    }

    public override int GetHashCode() => (int) OID;

    public static implicit operator uint(NWObjectBase obj) => obj.OID;

    public static implicit operator bool(NWObjectBase obj) => obj.OID != NWScript.OBJECT_INVALID;

    public virtual void AssignCommand(ActionDelegate action) => NWScript.AssignCommand(this, action);

    public class EventScripts {
      private readonly NWObjectBase owner;

      public EventScripts(NWObjectBase owner) {
        this.owner = owner;
      }

      public string this[EventScript key] {
        get => NWScript.GetEventScript(owner, (int) key);
        set => NWScript.SetEventScript(owner, (int) key, value);
      }
    }
  }
}