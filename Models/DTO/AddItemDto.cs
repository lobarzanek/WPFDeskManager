using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDeskManager.Models
{
    public class AddItemDto
    {
        #region Properties and indexers

        /// <summary>
        /// Gets or sets the name value of item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the serial number value of item.
        /// </summary>
        public string? SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the type value of item.
        /// </summary>
        public ItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the value of owner ID.
        /// </summary>
        public int? OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the value of brand ID.
        /// </summary>
        public int? BrandId { get; set; }

        /// <summary>
        /// Gets or sets the value of desk ID.
        /// </summary>
        public int? DeskId { get; set; }

        #endregion
    }
}
