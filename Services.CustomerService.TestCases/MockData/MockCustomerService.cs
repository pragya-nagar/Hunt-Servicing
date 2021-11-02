using Services.CustomerService.ViewModel;
using Services.CustomerService.ViewModel.ContactViewModel;
using Services.CustomerService.ViewModel.DocumentViewModel;
using Services.CustomerService.ViewModel.OwnerViewModel;
using Services.CustomerService.ViewModel.PropertyViewModel;
using System.Collections.Generic;

namespace Services.CustomerService.TestCases.MockData
{
    public static class MockCustomerService
    {
        public static IEnumerable<StateListEntity> MockStateList()
        {
            yield return new StateListEntity
            {
                StateCode = "TA",
                StateName = "Texas",
                StateId = 1
            };
        }
        public static IEnumerable<AssetStatusEntity> MockAssetStatusList()
        {
            yield return new AssetStatusEntity
            {
                StatusCode = "ACTIVE",
                StatusName = "ACTIVE",
                StatusId = 1
            };
        }
        public static IEnumerable<EventActionEntity> MockEventActionList()
        {
            yield return new EventActionEntity
            {
                EventActionId = 1,
                EventActionName = "Test Event Action",
                IsActionflag = false
            };
        }
        public static IEnumerable<GlobalSearchOptionEntity> MockGlobalSearchOptionEntity()
        {
            yield return new GlobalSearchOptionEntity
            {
                CellPhone = "00 00 0000",
                ContactPerson = "Test"
            };
        }
        public static IEnumerable<SearchGridResponseEntity> MockSearchGridResponseEntity()
        {
            yield return new SearchGridResponseEntity
            {
                NumberOfLienCountActive = 0,
                NumberOfLienCountRedeemed = 0
            };
        }
        public static LienHeaderInfoEntity MockLienHeaderInfoEntity()
        {
            return new LienHeaderInfoEntity
            {
                AssetId = "0"
            };
        }
        public static IEnumerable<LienAssetInfoEntity> MockLienAssetInfoEntity()
        {
            yield return new LienAssetInfoEntity
            {
                AssetId = "0"
            };
        }
        public static IEnumerable<LienRecentActivityEntity> MockLienRecentActivityEntity()
        {
            yield return new LienRecentActivityEntity
            {
                Action = ""
            };
        }
        public static IEnumerable<EventTypeEntity> MockEventTypeEntity()
        {
            yield return new EventTypeEntity
            {
                EventTypeId = 0
            };
        }
        public static IEnumerable<FlagActionEntity> MockFlagActionEntity()
        {
            yield return new FlagActionEntity
            {
                FlagActionId = 0
            };
        }

        public static IEnumerable<RelatedAssetEntity> MockAddEventRelatedAssetEntity()
        {
            yield return new RelatedAssetEntity
            {
                AssetId = "0"
            };
        }

        public static IEnumerable<ContactEntity> MockContactEntity()
        {
            yield return new ContactEntity
            {
                ContactId = 0
            };
        }

        public static IEnumerable<OwnerEntity> MockOwnerEntity()
        {
            yield return new OwnerEntity
            {
                OwnerName = "TestOwner"
            };
        }


        public static IEnumerable<EventActionCategoryEntity> MockEventActionCategoryEntity()
        {
            yield return new EventActionCategoryEntity
            {
                EventActionCategoryId = 0
            };
        }

        public static IEnumerable<ContactDetailsEntity> MockContactDetailsEntity()
        {
            yield return new ContactDetailsEntity
            {
                ContactId = 0
            };
        }


        public static IEnumerable<ContactTypeEntity> MockContactTypeEntity()
        {
            yield return new ContactTypeEntity
            {
                ContactTypeId = 0
            };
        }
        public static IEnumerable<CityEntity> MockCityEntity()
        {
            yield return new CityEntity
            {
                CityId = 0
            };
        }

        public static ManageContact MockManageContact()
        {
            return new ManageContact
            {
                AssetId = new List<string>(new[] { "test1", "test2" })
            };
        }
        public static IEnumerable<PropertyDetailsEntity> MockPropertyDetailsEntity()
        {
            yield return new PropertyDetailsEntity
            {
                CityName = "New York",
            };
        }
        public static IEnumerable<DocumentEntity> MockDocumentEntity()
        {
            yield return new DocumentEntity
            {
               AssetId = "Test"
            };
        }
        public static IEnumerable<DocumentTypeEntity> MockDocumentTypeEntity()
        {
            yield return new DocumentTypeEntity
            {
                DocumentTypeId = 0
            };
        }
        
    }
}
