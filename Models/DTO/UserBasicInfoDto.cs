using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDeskManager.Models
{
    public class UserBasicInfoDto
    {
        #region Properties and indexers

        /// <summary>
        /// Gets or sets the ID value of user.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the login value of user.
        /// </summary>
        public string? Name { get; set; }

        #endregion
    }
}
