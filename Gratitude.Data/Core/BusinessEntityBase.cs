using System;
using SQLite;

namespace Gratitude.Data.Core
{
    public class BusinessEntityBase:IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public BusinessEntityBase()
        {
        }

        public BusinessEntityBase(int id) => Id = id;
    }
}
