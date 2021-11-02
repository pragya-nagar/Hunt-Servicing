using Services.CustomerService.ViewModel;
using Services.CustomerService.ViewModel.ContactViewModel;
using Services.CustomerService.ViewModel.DocumentViewModel;
using Services.CustomerService.ViewModel.EventAssetViewModel;
using Services.CustomerService.ViewModel.OwnerViewModel;
using Services.CustomerService.ViewModel.PropertyViewModel;
using Xunit;

namespace Services.CustomerService.TestCases.Models
{
    public class EntityTestCases : BaseTest
    {
        [Fact]
        public void AccountInfoEntityGetSetPropertyTests()
        {
            var model = new AccountInfoEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void AdvancedSearchEntityGetSetPropertyTests()
        {
            var model = new AdvancedSearchEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void AssetInfoEntityGetSetPropertyTests()
        {
            var model = new AssetInfoEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void AssetStatusEntityGetSetPropertyTests()
        {
            var model = new AssetStatusEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void CityEntityGetSetPropertyTests()
        {
            var model = new CityEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void ContactEntityGetSetPropertyTests()
        {
            var model = new ContactEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void ElasticAdvancedSearchEntityGetSetPropertyTests()
        {
            var model = new ElasticAdvancedSearchEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void ElasticGlobalSearchEntityGetSetPropertyTests()
        {
            var model = new ElasticGlobalSearchEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void EventActionCategoryEntityGetSetPropertyTests()
        {
            var model = new EventActionCategoryEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void EventActionEntityGetSetPropertyTests()
        {
            var model = new EventActionEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void EventEntityGetSetPropertyTests()
        {
            var model = new EventEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void EventTypeEntityGetSetPropertyTests()
        {
            var model = new EventTypeEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void FlagActionEntityGetSetPropertyTests()
        {
            var model = new FlagActionEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void GlobalSearchOptionEntityGetSetPropertyTests()
        {
            var model = new GlobalSearchOptionEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void GlobalSearchOptionInputAdvancedEntityGetSetPropertyTests()
        {
            var model = new GlobalSearchOptionInputAdvancedEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void GlobalSearchOptionInputEntityGetSetPropertyTests()
        {
            var model = new GlobalSearchOptionInputEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void LienAssetInfoEntityGetSetPropertyTests()
        {
            var model = new LienAssetInfoEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void LienHeaderInfoEntityGetSetPropertyTests()
        {
            var model = new LienHeaderInfoEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void LienHeaderInfoEntityResponseGetSetPropertyTests()
        {
            var model = new LienHeaderInfoEntityResponse();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void LienRecentActivityEntityGetSetPropertyTests()
        {
            var model = new LienRecentActivityEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void RecentEventsEntityGetSetPropertyTests()
        {
            var model = new RecentEventsEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void RelatedAssetEntityGetSetPropertyTests()
        {
            var model = new RelatedAssetEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void SearchGridResponseEntityGetSetPropertyTests()
        {
            var model = new SearchGridResponseEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void StateListEntityGetSetPropertyTests()
        {
            var model = new StateListEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        #region ContactViewModel

        [Fact]
        public void ContactDetailsEntityGetSetPropertyTests()
        {
            var model = new ContactDetailsEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void ContactTypeEntityGetSetPropertyTests()
        {
            var model = new ContactTypeEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void ManageContactGetSetPropertyTests()
        {
            var model = new ManageContact();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }
        
        #endregion ContactViewModel

        #region DocumentViewModel
        [Fact]
        public void DocumentEntityGetSetPropertyTests()
        {
            var model = new DocumentEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void DocumentTypeEntityGetSetPropertyTests()
        {
            var model = new DocumentTypeEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        #endregion DocumentViewModel

        #region OwnerViewModel

        [Fact]
        public void OwnerEntityGetSetPropertyTests()
        {
            var model = new OwnerEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        #endregion OwnerViewModel

        #region PropertyViewModel

        [Fact]
        public void PropertyDetailsEntityGetSetPropertyTests()
        {
            var model = new PropertyDetailsEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        #endregion PropertyViewModel

        #region EventAssetViewModel

        [Fact]
        public void EventDetailsEntityGetSetPropertyTests()
        {
            var model = new EventDetailsEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void EventDetailsHeaderEntityGetSetPropertyTests()
        {
            var model = new EventDetailsHeaderEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void EventMasterEntityGetSetPropertyTests()
        {
            var model = new EventMasterEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void EventMasterRejectionReasonEntityGetSetPropertyTests()
        {
            var model = new EventMasterRejectionReasonEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void EventTypeAssetDetailsEntityGetSetPropertyTests()
        {
            var model = new EventTypeAssetDetailsEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void CertificateUploadFileHistoryGetSetPropertyTests()
        {
            var model = new CertificateUploadFileHistory();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }
        #endregion EventAssetViewModel
    }
}
