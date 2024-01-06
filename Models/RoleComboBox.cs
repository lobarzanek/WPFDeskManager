using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDeskManager.Models
{
    public class RoleComboBox
    {
        #region Properties and indexers

        /// <summary>
        /// Gets or sets the ID value of Role.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name value of Role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Role value.
        /// </summary>
        public Role Role { get; set; }

        #endregion
    }
}
