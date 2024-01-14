using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDeskManager.Models
{
    public class AddDeskDto
    {
        #region Properties and indexers

        /// <summary>
        /// Gets or sets the name value of desk.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of room ID.
        /// </summary>
        public int? RoomId { get; set; }

        #endregion
    }
}
