using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using HyperWebApp1.Entities;
using HyperWebApp1.Repository;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Moq;
using HyperWebApp1.Repository.Mongo;

namespace HyperWebApp1.Services.UnitTest.MongoMocks
{
    [TestClass]
    public class SingleRowTests
    {
        ISingleRowService singleRowService;
        ISingleRowRepository singleRowRepo;
        Mock<IMongoCollection<SingleRow>> mongocollection;
        List<SingleRow> singleRowList;

        public SingleRowTests()
        {
            singleRowList = new List<SingleRow>();
            singleRowList.Add(new SingleRow() { Id = "1", City = "city 1", Name = "name 1" });
            singleRowList.Add(new SingleRow() { Id = "2", City = "city 2", Name = "name 2" });
            singleRowList.Add(new SingleRow() { Id = "3", City = "city 3", Name = "name 3" });
            mongocollection = new Mock<IMongoCollection<SingleRow>>();
            singleRowRepo = new SingleRowRepository();
            singleRowService = new SingleRowService(singleRowRepo);

        }

        [TestMethod]
        public void CollectionNameAttribute_Tests()
        {
            CollectionNameAttribute attribute = new CollectionNameAttribute("value");
            var value = attribute.Name;
        }
    }
}
