using Services.CustomerService.Repositories.Constants;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases.ConstantsTestCases
{
    public class EventRepositoryQueriesTestCases
    {
        [Fact]
        public void EventRepositoryQueriesData_ReturnsString()
        {
            //Arrange

            //Act
            string UpdateHighlightedFlagByEventId = EventRepositoryQueries.UpdateHighlightedFlagByEventId;
            string RemoveHighlightedFlagByEventId = EventRepositoryQueries.RemoveHighlightedFlagByEventId;
            string GetAllEventType = EventRepositoryQueries.GetAllEventType;
            string GetAllEventAction = EventRepositoryQueries.GetAllEventAction;
            string GetRelatedAsset = EventRepositoryQueries.GetRelatedAsset;
            string GetContactByAssetId = EventRepositoryQueries.GetContactByAssetId;
            string CreatedEvent = EventRepositoryQueries.CreatedEvent;
            string GetEventActionCategory = EventRepositoryQueries.GetEventActionCategory;

            //Assert
            Assert.NotNull(UpdateHighlightedFlagByEventId);
            Assert.NotNull(RemoveHighlightedFlagByEventId);
            Assert.NotNull(GetAllEventType);
            Assert.NotNull(GetAllEventAction);
            Assert.NotNull(GetRelatedAsset);
            Assert.NotNull(GetContactByAssetId);
            Assert.NotNull(CreatedEvent);
            Assert.NotNull(GetEventActionCategory);


            Assert.True(UpdateHighlightedFlagByEventId.Length>0);
            Assert.True(RemoveHighlightedFlagByEventId.Length>0);
            Assert.True(GetAllEventType.Length>0);
            Assert.True(GetAllEventAction.Length>0);
            Assert.True(GetRelatedAsset.Length>0);
            Assert.True(GetContactByAssetId.Length>0);
            Assert.True(CreatedEvent.Length>0);
            Assert.True(GetEventActionCategory.Length>0);
        }
    }
}
