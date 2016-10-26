using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FetchAndStore.DAL;
using FetchAndStore.Models;
using Moq;



namespace FetchAndStore.Tests.DAL
{
    [TestClass]
    public class ResponseRepositoryTest
    {
        //creating Mock Connections
        Mock<ResponseContext> mock_context { get; set; }
        Mock<DbSet<Response>> mock_response_table { get; set; }
        List<Response> response_list { get; set; }
        ResponseRepository repo { get; set; }

        public void ConnectMocksToDataStore()
        {
            var queryable_list = response_list.AsQueryable();


            //tricking LINQ to to think list is a database table
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            //response property returns fake database table
            mock_context.Setup(c => c.Responses).Returns(mock_response_table.Object);

            //define callback for response to a called method
            mock_response_table.Setup(t => t.Add(It.IsAny<Response>())).Callback((Response s) => response_list.Add(s));

        }


        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
