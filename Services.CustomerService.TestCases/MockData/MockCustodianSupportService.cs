using System;
using System.Collections.Generic;
using Services.CustomerService.ViewModel.EventAssetViewModel;

namespace Services.CustomerService.TestCases.MockData
{
    public class MockCustodianSupportService
    {
        public static IEnumerable<EventMasterRejectionReasonEntity> MockEventMasterRejectionReasonEntity()
        {
            yield return new EventMasterRejectionReasonEntity
            {
                EventMasterRejectionReasonId = 0,
                EventMasterRejectionReasonName = "TestName"
            };
        }
        public static IEnumerable<EventMasterEntity> MockPendingEventsEntity()
        {
            yield return new EventMasterEntity
            {
                EventId = "TestEventId",
                StateCode = "TS"
            };
        }
        public static IEnumerable<EventDetailsHeaderEntity> MockEventDetailsHeaderEntity()
        {
            yield return new EventDetailsHeaderEntity
            {
                EventId = "TestEventId"
            };
        }
        public static IEnumerable<EventDetailsEntity> MockEventDetailsEntity()
        {
            yield return new EventDetailsEntity
            {
                EventId = "TestEventId"
            };
        }
        public static IEnumerable<EventTypeAssetDetailsEntity> MockEventTypeAssetDetailsEntity()
        {
            yield return new EventTypeAssetDetailsEntity
            {
                AssetID = "TestAssetID"
            };
        }
        public static IEnumerable<CertificateUploadFileHistory> MockCertificateUploadFileHistoryEntity()
        {
            yield return new CertificateUploadFileHistory
            {
                CertificateUploadFileId = 1,
                CertificateUploadFileName = string.Empty,
                IsProcessed = false,
                TotalRecordUploaded = 0
            };
        }
    }
}
