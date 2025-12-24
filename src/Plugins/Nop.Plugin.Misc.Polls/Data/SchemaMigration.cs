using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.Polls.Domain;

namespace Nop.Plugin.Misc.Polls.Data
{
    [NopSchemaMigration("2025/01/01 12:00:00", "Polls plugin schema", MigrationProcessType.Installation)]
    public class SchemaMigration : AutoReversingMigration
    {
        public override void Up()
        {
            // 1. Create the Poll table manually
            if (!Schema.Table(nameof(Poll)).Exists())
            {
                Create.Table(nameof(Poll))
                    .WithColumn(nameof(Poll.Id)).AsInt32().PrimaryKey().Identity()
                    .WithColumn(nameof(Poll.LanguageId)).AsInt32().NotNullable()
                    .WithColumn(nameof(Poll.Name)).AsString(int.MaxValue).NotNullable()
                    .WithColumn(nameof(Poll.SystemKeyword)).AsString(int.MaxValue).Nullable()
                    .WithColumn(nameof(Poll.Published)).AsBoolean().NotNullable()
                    .WithColumn(nameof(Poll.ShowOnHomepage)).AsBoolean().NotNullable()
                    .WithColumn(nameof(Poll.AllowGuestsToVote)).AsBoolean().NotNullable()
                    .WithColumn(nameof(Poll.DisplayOrder)).AsInt32().NotNullable()
                    .WithColumn(nameof(Poll.StartDateUtc)).AsDateTime().Nullable()
                    .WithColumn(nameof(Poll.EndDateUtc)).AsDateTime().Nullable()
                    .WithColumn(nameof(Poll.LimitedToStores)).AsBoolean().NotNullable()
                    .WithColumn(nameof(Poll.SubjectToAcl)).AsBoolean().NotNullable();
            }

            // 2. Create the PollAnswer table
            if (!Schema.Table(nameof(PollAnswer)).Exists())
            {
                Create.Table(nameof(PollAnswer))
                    .WithColumn(nameof(PollAnswer.Id)).AsInt32().PrimaryKey().Identity()
                    .WithColumn(nameof(PollAnswer.PollId)).AsInt32().NotNullable().ForeignKey(nameof(Poll), nameof(Poll.Id))
                    .WithColumn(nameof(PollAnswer.Name)).AsString(int.MaxValue).NotNullable()
                    .WithColumn(nameof(PollAnswer.NumberOfVotes)).AsInt32().NotNullable()
                    .WithColumn(nameof(PollAnswer.DisplayOrder)).AsInt32().NotNullable();
            }

            // 3. Create the PollVotingRecord table
            if (!Schema.Table(nameof(PollVotingRecord)).Exists())
            {
                Create.Table(nameof(PollVotingRecord))
                    .WithColumn(nameof(PollVotingRecord.Id)).AsInt32().PrimaryKey().Identity()
                    .WithColumn(nameof(PollVotingRecord.PollAnswerId)).AsInt32().NotNullable().ForeignKey(nameof(PollAnswer), nameof(PollAnswer.Id))
                    .WithColumn(nameof(PollVotingRecord.CustomerId)).AsInt32().NotNullable()
                    .WithColumn(nameof(PollVotingRecord.CreatedOnUtc)).AsDateTime().NotNullable();
            }
        }
    }
}