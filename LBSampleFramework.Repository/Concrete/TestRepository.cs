using LBSampleFramework.Entity;
using LBSampleFramework.Helpers;
using LBSampleFramework.Repository.Interface;
using System.Data;
using System.Linq;

namespace LBSampleFramework.Repository.Concrete
{
    public class TestRepository : BaseRepository<SampleTable, int>, ITestRepository
    {
        public SampleTable GetFirst()
        {
            string qry = "SELECT TOP 1 * FROM SampleTable";
            DBCommand cmd = CreateSqlCommand(qry);

            SampleTable retval = ExecuteReader(cmd, GetEntity).FirstOrDefault();

            return retval;
        }

        internal SampleTable GetEntity(IDataRecord record)
        {
            try
            {
                return new SampleTable()
                {
                    ColumnOne = record.Get<int>("ColumnOne"),
                    ColumnTwo = record.Get<string>("ColumnTwo")
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
