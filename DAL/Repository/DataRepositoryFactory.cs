using DAL.Repository.Implementation;

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
                return new FileDataRepository(gender);
            }
        }
    }

    public enum EnumDataRepositoryType
    {
        API, FILE
    }
}
