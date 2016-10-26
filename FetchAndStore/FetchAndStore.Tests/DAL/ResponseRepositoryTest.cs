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


        [TestInitialize] //runs before any tests
        public void Intialize()
        {
            //create
            mock_context = new Mock<ResponseContext>();
            mock_response_table = new Mock<DbSet<Response>>();
            response_list = new List<Response>();  //fake database
            repo = new ResponseRepository(mock_context.Object);

            ConnectMocksToDataStore();

        }

        [TestCleanup] //runs after every test
        public void TearDown()
        {
            repo = null; //reset repo 
        }


        public void RepoEnsureCanCreateInstance()
        {
            ResponseRepository repo = new ResponseRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureRepoHasContext()
        {
            ResponseRepository repo = new ResponseRepository();
            ResponseContext actual_context = repo.Context;

            Assert.IsInstanceOfType(actual_context, typeof(ResponseContext));
        }

        [TestMethod]
        public void RepoEnsureWeHaveNoReponses()
        {
            //Arrange

            //Act
            List<Response> some_response = repo.GetResponses();
            int expected_response_count = 0;
            int actual_response_count = some_response.Count;

            //Assert
            Assert.AreEqual(expected_response_count, actual_response_count);

        }



        [TestMethod]
        public void RepoEnsureRepoCanStoreReponses()
        {
            Response test_response = new Response { ResponseId = 0, URL = "https://google.com", StatusCode = "200", Method = "GET", RequestTime = "5000"};
            repo.AddResponse(test_response);
            int expected_response_count = 1;
            int actual_response_count = repo.GetResponses().Count();

            Assert.AreEqual(expected_response_count, actual_response_count);
        }

    }

}
