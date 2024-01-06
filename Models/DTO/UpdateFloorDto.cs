﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDeskManager.Models
{
    public class UpdateFloorDto
    {
        #region Properties and indexers

        /// <summary>
        /// Gets or sets the ID value of floor.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name value of floor.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of building ID.
        /// </summary>
        public int? BuildingId { get; set; }

        #endregion
    }
}
