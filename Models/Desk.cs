﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDeskManager.Models
{
    public class Desk
    {
        #region Properties and indexers

        /// <summary>
        /// Gets or sets the ID value of desk.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name value of desk.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of horizontal map location.
        /// </summary>
        public string? MapXLocation { get; set; }

        /// <summary>
        /// Gets or sets the value of vertical map location.
        /// </summary>
        public string? MapYLocation { get; set; }

        /// <summary>
        /// Gets or sets the value of desk width on map.
        /// </summary>
        public string? Width { get; set; }

        /// <summary>
        /// Gets or sets the value of desk height on map.
        /// </summary>
        public string? Height { get; set; }

        /// <summary>
        /// Gets or sets the value of room ID.
        /// </summary>
        public int? RoomId { get; set; }

        /// <summary>
        /// Gets or sets the value of room name.
        /// </summary>
        public string? RoomName { get; set; }

        /// <summary>
        /// Gets or sets the value of status ID.
        /// </summary>
        public DeskStatus Status { get; set; }

        #endregion
    }
}
