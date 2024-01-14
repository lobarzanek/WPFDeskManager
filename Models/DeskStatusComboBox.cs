using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDeskManager.Models
{
    public class DeskStatusComboBox
    {
        #region Properties and indexers

        /// <summary>
        /// Gets or sets the ID value of Desk Status.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name value of Desk Status.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the DeskStatus value.
        /// </summary>
        public DeskStatus DeskStatus { get; set; }

        #endregion
    }
}
