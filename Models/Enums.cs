﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDeskManager.Models
{
    /// <summary>
    /// Value of the user role.
    /// </summary>
    public enum Role
    {
        Admin = 0,
        User = 1,
    }

    /// <summary>
    /// Value of the item type.
    /// </summary>
    public enum ItemType
    {
        Other = 0,
        Mouse = 1,
        Keyboard = 2,
        Monitor = 3,
        DockStation = 4,
    }

    /// <summary>
    /// Value of the item status.
    /// </summary>
    public enum ItemStatus
    {
        Unknown = 0,
        Free = 1,
        Used = 2,
        Broken = 3,
    }

    /// <summary>
    /// Value of the issue status.
    /// </summary>
    public enum IssueStatus
    {
        Created = 0,
        New = 1,
        Open = 2,
        InProgress = 3,
        Blocked = 4,
        Done = 5
    }

    /// <summary>
    /// Value of the desk status.
    /// </summary>
    public enum DeskStatus
    {
        Free = 0,
        Broken = 2,
    }
}
