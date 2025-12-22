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
            // Skapar tabellen för Poll (Själva omröstningen)
            Create.TableFor<Poll>();

            // Skapar tabellen för PollAnswer (Svarsalternativen)
            Create.TableFor<PollAnswer>();

            // Skapar tabellen för PollVotingRecord (Vem som röstat vad)
            Create.TableFor<PollVotingRecord>();
        }
    }
}