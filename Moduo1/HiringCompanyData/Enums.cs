using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyData
{
    [DataContract]
    public enum PositionEnum : int
    {
        [EnumMember]
        CEO = 0,
        [EnumMember]
        HR = 1,
        [EnumMember]
        PO = 2,
        [EnumMember]
        SM = 3
    }

    [DataContract]
    public enum ProjectState
    {
        [EnumMember]
        New = 0,
        [EnumMember]
        Accepted = 1,
        [EnumMember]
        Open = 2,
        [EnumMember]
        Finished = 3,
        [EnumMember]
        Closed = 4
    }

    [DataContract]
    public enum TaskState
    {
        [EnumMember]
        New = 0,
        [EnumMember]
        Open = 1,
        [EnumMember]
        Finished = 2,
        [EnumMember]
        Closed = 3
    }

    [DataContract]
    public enum UserStoryState
    {
        [EnumMember]
        New = 0,
        [EnumMember]
        Open = 1,
        [EnumMember]
        Finished = 2,
        [EnumMember]
        Closed = 3
    }

}
