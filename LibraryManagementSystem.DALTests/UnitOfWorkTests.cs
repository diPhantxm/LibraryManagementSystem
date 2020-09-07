using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Tests
{
    [TestClass()]
    public class UnitOfWorkTests
    {
        [TestMethod()]
        public void GetTableNamesTest()
        {
            try
            {
                using (var uow = new UnitOfWork(new LibraryDbContext()))
                {
                    uow.GetTableNames();
                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetRepositoryTest()
        {
            try
            {
                using (var uow = new UnitOfWork(new LibraryDbContext()))
                {
                    
                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}