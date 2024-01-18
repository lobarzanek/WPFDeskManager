using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDeskManager.Models.DTO
{
    public class AddRoomDto
    {
        #region Properties and indexers

        /// <summary>
        /// Gets or sets the name value of room.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the value of map view box.
        /// </summary>
        public string mapViewBox { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the value of map width.
        /// </summary>
        public string mapWidth { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the value of map height.
        /// </summary>
        public string mapHeight { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the value of xmlns.
        /// </summary>
        public string mapXmlns { get; set; } = "http://www.w3.org/2000/svg";

        /// <summary>
        /// Gets or sets the value of floor ID.
        /// </summary>
        public int? FloorId { get; set; }

        #endregion
    }
}
