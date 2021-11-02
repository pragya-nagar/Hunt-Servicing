using Services.CustomerService.Command;
using Xunit;

namespace Services.CustomerService.TestCases.Models
{
    public class PropertyCommands: BaseTest
    {
        /// <summary>
        /// Creates the contact command get set property tests.
        /// </summary>
        [Fact]
        public void CreateContactCommandGetSetPropertyTests()
        {
            var model = new CreateContactCommand();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        /// <summary>
        /// Creates the document command get set property tests.
        /// </summary>
        [Fact]
        public void CreateDocumentCommandGetSetPropertyTests()
        {
            var model = new CreateDocumentCommand();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        /// <summary>
        /// Creates the event command get set property tests.
        /// </summary>
        [Fact]
        public void CreateEventCommandGetSetPropertyTests()
        {
            var model = new CreateEventCommand();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        /// <summary>
        /// Removes the event type flag command get set property tests.
        /// </summary>
        [Fact]
        public void RemoveEventTypeFlagCommandGetSetPropertyTests()
        {
            var model = new RemoveEventTypeFlagCommand();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        /// <summary>
        /// Updates the contact command get set property tests.
        /// </summary>
        [Fact]
        public void UpdateContactCommandGetSetPropertyTests()
        {
            var model = new UpdateContactCommand();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        /// <summary>
        /// Updates the contact flag command get set property tests.
        /// </summary>
        [Fact]
        public void UpdateContactFlagCommandGetSetPropertyTests()
        {
            var model = new UpdateContactFlagCommand();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        /// <summary>
        /// Updates the event type flag command get set property tests.
        /// </summary>
        [Fact]
        public void UpdateEventTypeFlagCommandGetSetPropertyTests()
        {
            var model = new UpdateEventTypeFlagCommand();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }
        /// <summary>
        /// Pending events action command get set property tests.
        /// </summary>
        [Fact]
        public void PendingEventsActionCommandGetSetPropertyTests()
        {
            var model = new PendingEventsActionCommand();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }


        [Fact]
        public void RemoveUploadFileFlagCommandGetSetPropertyTests()
        {
            var model = new RemoveUploadFileFlagCommand();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }
    }
}