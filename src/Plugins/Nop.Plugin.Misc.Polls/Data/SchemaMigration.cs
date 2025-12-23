using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.Polls.Domain;

namespace Nop.Plugin.Misc.Polls.Data
{
    [NopMigration("2025/01/01 12:00:00", "Misc.Polls schema", MigrationProcessType.Installation)]
    public class SchemaMigration : AutoReversingMigration
    {
        public override void Up()
        {
            // Smart check
            if (!Schema.Table(nameof(Poll)).Exists())
            {
                Create.TableFor<Poll>();
            }

            if (!Schema.Table(nameof(PollAnswer)).Exists())
            {
                Create.TableFor<PollAnswer>();
            }

            if (!Schema.Table(nameof(PollVotingRecord)).Exists())
            {
                Create.TableFor<PollVotingRecord>();
            }
        }
    }
}