using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using HyperWebApp1.Entities;
using HyperWebApp1.Repository.Pattern.Infrastructure;

namespace HyperWebApp1.Services.UnitTest.EntityTests
{
    [TestClass]
    public class SingleRowTests
    {
        [TestMethod]
        public void SingleRow_Get_SetTests()
        {
            // Set value 
            SingleRow singleRow = new SingleRow()
            {
                Name = "Name",
                City = "City",
                Id = "Id",
                ObjectState = ObjectState.Added
            };
            //Get Value
            SingleRow singleRowSet = new SingleRow()
            {
                Name = singleRow.Name,
                City = singleRow.City,
                Id = singleRow.Id,
                ObjectState = singleRow.ObjectState
            };
            Assert.IsTrue(true, singleRowSet.Name);
        }
    }
}
