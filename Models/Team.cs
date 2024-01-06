using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDeskManager.Models
{
    public class Team
    {
        #region Properties and indexers

        /// <summary>
        /// Gets or sets the ID value of team.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name value of team.
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}
