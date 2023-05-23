using DAL.Repository.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DataRepositoryFactory
    {
        private DataRepositoryFactory()
        {}

        public static IDataRepository GetRepository(EnumDataRepositoryType type, EnumGender gender)
        {
            if (type == EnumDataRepositoryType.API)
            {
                return new ApiDataRepository(gender);
            } else
            {
                return null;
            }
        }
    }

    public enum EnumDataRepositoryType
    {
        API, FILE
    }
}
