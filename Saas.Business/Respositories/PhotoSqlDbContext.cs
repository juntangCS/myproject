using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Entity;
using Saas.Business.Entities;

namespace Saas.Business.Respositories
{
    /// <summary>
    /// 
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PhotoSqlDbContext:DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoSqlDbContext"/> class.
        /// </summary>
        public PhotoSqlDbContext() : base("name=PhotoSqlDbContext")
        {
        }

        public IDbSet<User> Users { get; set; }

    }
}
