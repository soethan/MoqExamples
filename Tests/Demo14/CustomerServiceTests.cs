using Moq;
using NUnit.Framework;
using PluralSight.Moq.Code.Demo14;
using System.Collections.Generic;

namespace PluralSight.Moq.Tests.Demo14
{
    public class CustomerServiceTests
    {
        [Test]
        public void the_customer_should_be_saved()
        {
            //Arrange
            var mockCustomerRepository =
                new Mock<ICustomerRepository>();

            mockCustomerRepository
                .Setup(x => x.Save(It.IsAny<Customer>()));

            var customerService = new CustomerService(
                mockCustomerRepository.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockCustomerRepository.Verify();
        }

        [TestFixture]
        public class When_creating_a_customer
        {
            [Test]
            public void the_customer_should_be_saved_fetch_all_should_be_called()
            {
                //Arrange
                var mockCustomerRepository = 
                    new Mock<ICustomerRepository>(MockBehavior.Strict);

                mockCustomerRepository
                    .Setup(x => x.Save(It.IsAny<Customer>()));
                mockCustomerRepository
                    .Setup(x => x.FetchAll())
                    .Returns(new List<Customer>());

                var customerService = new CustomerService(
                    mockCustomerRepository.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockCustomerRepository.Verify();
            }
        }
    }
}