namespace EXOPEK_Backend.Entities;


    public enum DifficultyType 
    {
        None = 0,
        Beginner,
        Intermediate,
        Advanced
    }

    public enum CategoryType 
    {
        None = 0,
        FullBody,
        UpperBody,
        LowerBody,
        Core,
        Cardio
    }

    public enum StageType 
    {
        WarmUp,
        Main,
        Cooldown
    }
    public enum TargetType
    {
        None = 0,
        Strength,
        Endurance,
        Mobility,
        Flexibility,
        Balance,
        Coordination,
        Speed,
        Power,
        Agility,
        Reaction,
        Stamina,
    }

    public enum PhaseType
    {
        Phase1,
        Phase2,
        Phase3,
        Phase4,
        Phase5,
        Phase6,
        Phase7,
        Phase8,
        Phase9,
        Phase10,
    }
    
    public enum StatusType
    {
        None = 0,
        Active,
        Inactive,
        Deleted,
        Completed,
        Pending,
        Rejected,
        Approved,
        Blocked,
        Unblocked,
        Verified,
        Unverified,
        Locked,
        Unlocked,
        Expired,
        Unexpired,
        PendingVerification,
        PendingApproval,
    }
