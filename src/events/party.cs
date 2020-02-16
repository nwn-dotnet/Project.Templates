namespace NWN.Events
{
    public class PartyEvent : NWNXEvent
    {
        public const string BEFORE_JOIN       = "NWNX_ON_PARTY_ACCEPT_INVITATION_BEFORE";
        public const string AFTER_JOIN        = "NWNX_ON_PARTY_ACCEPT_INVITATION_AFTER";
        public const string BEFORE_LEAVE      = "NWNX_ON_PARTY_LEAVE_BEFORE";
        public const string AFTER_LEAVE       = "NWNX_ON_PARTY_LEAVE_AFTER";
        public const string BEFORE_KICK       = "NWNX_ON_PARTY_KICK_BEFORE";
        public const string AFTER_KICK        = "NWNX_ON_PARTY_KICK_AFTER";
        public const string BEFORE_NEW_LEADER = "NWNX_ON_PARTY_TRANSFER_LEADERSHIP_BEFORE";
        public const string AFTER_NEW_LEADER  = "NWNX_ON_PARTY_TRANSFER_LEADERSHIP_AFTER";

        public delegate void EventDelegate(PartyEvent e);

        public static EventDelegate BeforeJoinParty           = delegate {};
        public static EventDelegate AfterJoinParty            = delegate {};
        public static EventDelegate BeforeLeaveParty          = delegate {};
        public static EventDelegate AfterLeaveParty           = delegate {};
        public static EventDelegate BeforeKickPartyMember     = delegate {};
        public static EventDelegate AfterKickPartyMember      = delegate {};
        public static EventDelegate BeforeTransferLeadership  = delegate {};
        public static EventDelegate AfterTransferLeadership   = delegate {};

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public NWPlayer InvitedBy => GetEventObject("INVITED_BY").AsPlayer();
        public NWPlayer KickedPlayer => GetEventObject("KICKED").AsPlayer();
        public NWPlayer NewLeader => GetEventObject("NEW_LEADER").AsPlayer();

        public PartyEvent(string script) { EventType = script; }

        [NWNEventHandler(BEFORE_JOIN)]
        [NWNEventHandler(AFTER_JOIN)]
        [NWNEventHandler(BEFORE_LEAVE)]
        [NWNEventHandler(AFTER_LEAVE)]
        [NWNEventHandler(BEFORE_KICK)]
        [NWNEventHandler(AFTER_KICK)]
        [NWNEventHandler(BEFORE_NEW_LEADER)]
        [NWNEventHandler(AFTER_NEW_LEADER)]
        public static void EventHandler(string script)
        {
            var e = new PartyEvent(script);
            switch (script)
            {
                case BEFORE_JOIN:       BeforeJoinParty(e); break;
                case AFTER_JOIN:        AfterJoinParty(e); break;
                case BEFORE_LEAVE:      BeforeLeaveParty(e); break;
                case AFTER_LEAVE:       AfterLeaveParty(e); break;
                case BEFORE_KICK:       BeforeKickPartyMember(e); break;
                case AFTER_KICK:        AfterKickPartyMember(e); break;
                case BEFORE_NEW_LEADER: BeforeTransferLeadership(e); break;
                case AFTER_NEW_LEADER:  AfterTransferLeadership(e); break;
                default: break;
            }
        }
    }

    public class PvPAttitudeEvent : NWNXEvent
    {
        public const string BEFORE_PVP_ATTITUDE_CHANGE	= "NWNX_ON_PVP_ATTITUDE_CHANGE_BEFORE";
        public const string AFTER_PVP_ATTITUDE_CHANGE	= "NWNX_ON_PVP_ATTITUDE_CHANGE_AFTER";
    
        public delegate void EventDelegate(PvPAttitudeEvent e);
    
        public static EventDelegate BeforeChange	= delegate {};
        public static EventDelegate AfterChange	    = delegate {};
    
        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public NWPlayer Target => GetEventObject("TARGET_OBJECT_ID").AsPlayer();
        public bool LikesTarget => GetEventInt("ATTITUDE") == 1;
    
        public PvPAttitudeEvent(string script) { EventType = script; }
    
        [NWNEventHandler(BEFORE_PVP_ATTITUDE_CHANGE)]
        [NWNEventHandler(AFTER_PVP_ATTITUDE_CHANGE)]
        public static void EventHandler(string script)
        {
            var e = new PvPAttitudeEvent(script);
            switch (script)
            {
                case BEFORE_PVP_ATTITUDE_CHANGE:	BeforeChange(e); break;
                case AFTER_PVP_ATTITUDE_CHANGE:	AfterChange(e); break;
            }
        }
    }
}