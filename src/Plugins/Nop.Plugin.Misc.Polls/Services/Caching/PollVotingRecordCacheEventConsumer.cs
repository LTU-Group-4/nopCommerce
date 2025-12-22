using Nop.Core.Domain.Polls;
using Nop.Services.Caching;

//namespace Nop.Services.Polls.Caching;
namespace Nop.Plugin.Misc.Polls.Services.Caching;

/// <summary>
/// Represents a poll voting record cache event consumer
/// </summary>
public partial class PollVotingRecordCacheEventConsumer : CacheEventConsumer<PollVotingRecord>;