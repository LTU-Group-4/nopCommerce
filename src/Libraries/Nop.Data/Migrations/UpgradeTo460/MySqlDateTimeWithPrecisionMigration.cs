using FluentMigrator;
using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.Gdpr;
using Nop.Core.Domain.Logging;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.Orders;
//using Nop.Core.Domain.Polls; // Commented out for Plugin extraction
using Nop.Core.Domain.ScheduleTasks;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Migrations.UpgradeTo460;

[NopSchemaMigration("2023-07-28 08:00:00", "Update datetime type precision")]
public class MySqlDateTimeWithPrecisionMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        var dataSettings = DataSettingsManager.LoadSettings();

        // Update the types only in MySql 
        if (dataSettings.DataProvider != DataProviderType.MySql)
            return;

        // Using standard FluentMigrator syntax (Alter.Table) instead of AddOrAlterColumnFor
        // to avoid CS1061 errors in your version.

        Alter.Table(nameof(ActivityLog)).AlterColumn(nameof(ActivityLog.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(Address)).AlterColumn(nameof(Address.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(BackInStockSubscription)).AlterColumn(nameof(BackInStockSubscription.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(BlogComment)).AlterColumn(nameof(BlogComment.CreatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(BlogPost)).AlterColumn(nameof(BlogPost.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(BlogPost)).AlterColumn(nameof(BlogPost.EndDateUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(BlogPost)).AlterColumn(nameof(BlogPost.StartDateUtc)).AsCustom("datetime(6)").Nullable();

        Alter.Table(nameof(Campaign)).AlterColumn(nameof(Campaign.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(Campaign)).AlterColumn(nameof(Campaign.DontSendBeforeDateUtc)).AsCustom("datetime(6)").Nullable();

        Alter.Table(nameof(Category)).AlterColumn(nameof(Category.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(Category)).AlterColumn(nameof(Category.UpdatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(Currency)).AlterColumn(nameof(Currency.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(Currency)).AlterColumn(nameof(Currency.UpdatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(Customer)).AlterColumn(nameof(Customer.CannotLoginUntilDateUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(Customer)).AlterColumn(nameof(Customer.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(Customer)).AlterColumn(nameof(Customer.DateOfBirth)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(Customer)).AlterColumn(nameof(Customer.LastActivityDateUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(Customer)).AlterColumn(nameof(Customer.LastLoginDateUtc)).AsCustom("datetime(6)").Nullable();

        Alter.Table(nameof(CustomerPassword)).AlterColumn(nameof(CustomerPassword.CreatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(Discount)).AlterColumn(nameof(Discount.EndDateUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(Discount)).AlterColumn(nameof(Discount.StartDateUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(DiscountUsageHistory)).AlterColumn(nameof(DiscountUsageHistory.CreatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(Forum)).AlterColumn(nameof(Forum.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(Forum)).AlterColumn(nameof(Forum.LastPostTime)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(Forum)).AlterColumn(nameof(Forum.UpdatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(ForumGroup)).AlterColumn(nameof(ForumGroup.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(ForumGroup)).AlterColumn(nameof(ForumGroup.UpdatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(ForumPost)).AlterColumn(nameof(ForumPost.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(ForumPost)).AlterColumn(nameof(ForumPost.UpdatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(ForumPostVote)).AlterColumn(nameof(ForumPostVote.CreatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(PrivateMessage)).AlterColumn(nameof(PrivateMessage.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(ForumSubscription)).AlterColumn(nameof(ForumSubscription.CreatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(ForumTopic)).AlterColumn(nameof(ForumTopic.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(ForumTopic)).AlterColumn(nameof(ForumTopic.LastPostTime)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(ForumTopic)).AlterColumn(nameof(ForumTopic.UpdatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(GdprLog)).AlterColumn(nameof(GdprLog.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(GenericAttribute)).AlterColumn(nameof(GenericAttribute.CreatedOrUpdatedDateUTC)).AsCustom("datetime(6)").Nullable();

        Alter.Table(nameof(GiftCard)).AlterColumn(nameof(GiftCard.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(GiftCardUsageHistory)).AlterColumn(nameof(GiftCardUsageHistory.CreatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(Log)).AlterColumn(nameof(Log.CreatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(Manufacturer)).AlterColumn(nameof(Manufacturer.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(Manufacturer)).AlterColumn(nameof(Manufacturer.UpdatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(MigrationVersionInfo)).AlterColumn(nameof(MigrationVersionInfo.AppliedOn)).AsCustom("datetime(6)").Nullable();

        Alter.Table(nameof(NewsLetterSubscription)).AlterColumn(nameof(NewsLetterSubscription.CreatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(Order)).AlterColumn(nameof(Order.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(Order)).AlterColumn(nameof(Order.PaidDateUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(OrderItem)).AlterColumn(nameof(OrderItem.RentalEndDateUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(OrderItem)).AlterColumn(nameof(OrderItem.RentalStartDateUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(OrderNote)).AlterColumn(nameof(OrderNote.CreatedOnUtc)).AsCustom("datetime(6)");

        // POLLS - Commented out as they are moved to a Plugin
        //Alter.Table(nameof(Poll)).AlterColumn(nameof(Poll.EndDateUtc)).AsCustom("datetime(6)").Nullable();
        //Alter.Table(nameof(Poll)).AlterColumn(nameof(Poll.StartDateUtc)).AsCustom("datetime(6)").Nullable();
        //Alter.Table(nameof(PollVotingRecord)).AlterColumn(nameof(PollVotingRecord.CreatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(Product)).AlterColumn(nameof(Product.AvailableEndDateTimeUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(Product)).AlterColumn(nameof(Product.AvailableStartDateTimeUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(Product)).AlterColumn(nameof(Product.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(Product)).AlterColumn(nameof(Product.MarkAsNewEndDateTimeUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(Product)).AlterColumn(nameof(Product.MarkAsNewStartDateTimeUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(Product)).AlterColumn(nameof(Product.PreOrderAvailabilityStartDateTimeUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(Product)).AlterColumn(nameof(Product.UpdatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(ProductReview)).AlterColumn(nameof(ProductReview.CreatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(QueuedEmail)).AlterColumn(nameof(QueuedEmail.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(QueuedEmail)).AlterColumn(nameof(QueuedEmail.DontSendBeforeDateUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(QueuedEmail)).AlterColumn(nameof(QueuedEmail.SentOnUtc)).AsCustom("datetime(6)").Nullable();

        Alter.Table(nameof(RecurringPayment)).AlterColumn(nameof(RecurringPayment.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(RecurringPayment)).AlterColumn(nameof(RecurringPayment.StartDateUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(RecurringPaymentHistory)).AlterColumn(nameof(RecurringPaymentHistory.CreatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(ReturnRequest)).AlterColumn(nameof(ReturnRequest.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(ReturnRequest)).AlterColumn(nameof(ReturnRequest.UpdatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(RewardPointsHistory)).AlterColumn(nameof(RewardPointsHistory.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(RewardPointsHistory)).AlterColumn(nameof(RewardPointsHistory.EndDateUtc)).AsCustom("datetime(6)").Nullable();

        Alter.Table(nameof(ScheduleTask)).AlterColumn(nameof(ScheduleTask.LastEnabledUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(ScheduleTask)).AlterColumn(nameof(ScheduleTask.LastEndUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(ScheduleTask)).AlterColumn(nameof(ScheduleTask.LastStartUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(ScheduleTask)).AlterColumn(nameof(ScheduleTask.LastSuccessUtc)).AsCustom("datetime(6)").Nullable();

        Alter.Table(nameof(Shipment)).AlterColumn(nameof(Shipment.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(Shipment)).AlterColumn(nameof(Shipment.DeliveryDateUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(Shipment)).AlterColumn(nameof(Shipment.ReadyForPickupDateUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(Shipment)).AlterColumn(nameof(Shipment.ShippedDateUtc)).AsCustom("datetime(6)").Nullable();

        Alter.Table(nameof(ShoppingCartItem)).AlterColumn(nameof(ShoppingCartItem.CreatedOnUtc)).AsCustom("datetime(6)");
        Alter.Table(nameof(ShoppingCartItem)).AlterColumn(nameof(ShoppingCartItem.RentalEndDateUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(ShoppingCartItem)).AlterColumn(nameof(ShoppingCartItem.RentalStartDateUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(ShoppingCartItem)).AlterColumn(nameof(ShoppingCartItem.UpdatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(StockQuantityHistory)).AlterColumn(nameof(StockQuantityHistory.CreatedOnUtc)).AsCustom("datetime(6)");

        Alter.Table(nameof(TierPrice)).AlterColumn(nameof(TierPrice.EndDateTimeUtc)).AsCustom("datetime(6)").Nullable();
        Alter.Table(nameof(TierPrice)).AlterColumn(nameof(TierPrice.StartDateTimeUtc)).AsCustom("datetime(6)").Nullable();

        Alter.Table(nameof(VendorNote)).AlterColumn(nameof(VendorNote.CreatedOnUtc)).AsCustom("datetime(6)");
    }
}