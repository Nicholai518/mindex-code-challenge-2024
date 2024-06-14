using System;
using System.Net;
using System.Net.Http;
using System.Text;
using CodeChallenge.Models;
using CodeCodeChallenge.Tests.Integration.Extensions;
using CodeCodeChallenge.Tests.Integration.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeChallenge.Tests.Integration
{
    [TestClass]
    public class CompensationControllerTests
    {
        private static HttpClient _httpClient;
        private static TestServer _testServer;

        [ClassInitialize]
        // Attribute ClassInitialize requires this signature
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter",
            Justification = "<Pending>")]
        public static void InitializeClass(TestContext context)
        {
            _testServer = new TestServer();
            _httpClient = _testServer.NewClient();
        }

        [ClassCleanup]
        public static void CleanUpTest()
        {
            _httpClient.Dispose();
            _testServer.Dispose();
        }

        [TestMethod]
        public void CreateCompensationForJohnLennon_Returns_Created()
        {
            // Arrange
            var expectedEmployeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f";
            var expectedFirstName = "John";
            var expectedLastName = "Lennon";
            var expectedDepartment = "Engineering";
            var expectedPosition = "Development Manager";
            var expectedSalary = 80000.00;
            var expectedEffectiveDate = new DateTime(2015, 12, 25);

            Employee johnLennon = new Employee();
            johnLennon.EmployeeId = expectedEmployeeId;
            var compensation = new Compensation()
            {
                Employee = johnLennon,
                Salary = expectedSalary,
                EffectiveDate = expectedEffectiveDate
            };

            var requestContent = new JsonSerialization().ToJson(compensation);

            // Execute
            var postRequestTask = _httpClient.PostAsync("api/compensation",
                new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var response = postRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var newCompensation = response.DeserializeContent<Compensation>();
            Assert.IsNotNull(newCompensation.CompensationId);
            Assert.AreEqual(expectedEmployeeId, newCompensation.Employee.EmployeeId);
            Assert.AreEqual(expectedFirstName, newCompensation.Employee.FirstName);
            Assert.AreEqual(expectedLastName, newCompensation.Employee.LastName);
            Assert.AreEqual(expectedDepartment, newCompensation.Employee.Department);
            Assert.AreEqual(expectedPosition, newCompensation.Employee.Position);
            Assert.AreEqual(expectedSalary, newCompensation.Salary);
            Assert.AreEqual(expectedEffectiveDate, newCompensation.EffectiveDate);
        }


        [TestMethod]
        public void CreateAndGetCompensationForPaulMcCartney_Returns_OK()
        {
            // Arrange
            var expectedEmployeeId = "b7839309-3348-463b-a7e3-5de1c168beb3";
            var expectedFirstName = "Paul";
            var expectedLastName = "McCartney";
            var expectedDepartment = "Engineering";
            var expectedPosition = "Developer I";
            var expectedSalary = 80000.00;
            var expectedEffectiveDate = new DateTime(2015, 12, 25);

            Employee paulMcCartney = new Employee();
            paulMcCartney.EmployeeId = expectedEmployeeId;
            var compensation = new Compensation()
            {
                Employee = paulMcCartney,
                Salary = expectedSalary,
                EffectiveDate = expectedEffectiveDate
            };

            var requestContent = new JsonSerialization().ToJson(compensation);

            // Execute
            var postRequestTask = _httpClient.PostAsync("api/compensation",
                new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var createResponse = postRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, createResponse.StatusCode);

            var newCompensation = createResponse.DeserializeContent<Compensation>();
            Assert.IsNotNull(newCompensation.CompensationId);
            Assert.AreEqual(expectedEmployeeId, newCompensation.Employee.EmployeeId);
            Assert.AreEqual(expectedFirstName, newCompensation.Employee.FirstName);
            Assert.AreEqual(expectedLastName, newCompensation.Employee.LastName);
            Assert.AreEqual(expectedDepartment, newCompensation.Employee.Department);
            Assert.AreEqual(expectedPosition, newCompensation.Employee.Position);
            Assert.AreEqual(expectedSalary, newCompensation.Salary);
            Assert.AreEqual(expectedEffectiveDate, newCompensation.EffectiveDate);


            // GET 
            var getRequestTask = _httpClient.GetAsync($"api/compensation/{expectedEmployeeId}");
            var getResponse = getRequestTask.Result;


            // Assert
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
            var getCompensation = getResponse.DeserializeContent<Compensation>();
            Assert.IsNotNull(newCompensation.CompensationId);
            Assert.AreEqual(expectedEmployeeId, getCompensation.Employee.EmployeeId);
            Assert.AreEqual(expectedFirstName, getCompensation.Employee.FirstName);
            Assert.AreEqual(expectedLastName, getCompensation.Employee.LastName);
            Assert.AreEqual(expectedDepartment, getCompensation.Employee.Department);
            Assert.AreEqual(expectedPosition, getCompensation.Employee.Position);
            Assert.AreEqual(expectedSalary, getCompensation.Salary);
            Assert.AreEqual(expectedEffectiveDate, getCompensation.EffectiveDate);
        }
    }
}