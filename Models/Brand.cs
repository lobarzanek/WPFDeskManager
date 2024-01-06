using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDeskManager.Models
{
    public class Brand
    {
        #region Properties and indexers

        /// <summary>
        /// Gets or sets the ID value of desk.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the name value of brand.
        /// </summary>
        public string? Name { get; set; }

        #endregion
    }
}
