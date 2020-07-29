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
        public void UnitOfWorkTestAsync()
        {
            using (var uow = new UnitOfWork(new LibraryDbContext()))
            {
                var connection = uow.DbContext.Database.Exists();

                Assert.IsTrue(connection);
            }
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}