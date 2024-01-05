using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDeskManager.Models
{
    public class ItemTypeComboBox
    {
        #region Properties and indexers

        /// <summary>
        /// Gets or sets the ID value of ItemType.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name value of ItemType.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ItemType value.
        /// </summary>
        public ItemType ItemType { get; set; }

        #endregion
    }
}
