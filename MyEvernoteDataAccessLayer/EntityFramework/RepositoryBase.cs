using MyEvernoteDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernoteDataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        // Singelton patternini basitçe uyguladık.
        protected static DatabaseContext context;
        private static object _lockSync = new object();
        protected RepositoryBase()
        {
            CreateContext();
        }
        private static void CreateContext()
        {
            if (context == null)
            {
                lock (_lockSync)
                {
                    if (context == null)
                    {
                        context = new DatabaseContext();
                    }
                }
            }
        }
    }
}
