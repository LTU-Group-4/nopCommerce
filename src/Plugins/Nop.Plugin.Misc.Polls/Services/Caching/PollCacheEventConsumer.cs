//using Nop.Core.Domain.Polls;
using Nop.Plugin.Misc.Polls.Domain;
using Nop.Services.Caching;

//namespace Nop.Services.Polls.Caching;
namespace Nop.Plugin.Misc.Polls.Services.Caching;

/// <summary>
/// Represents a poll cache event consumer
/// </summary>
public partial class PollCacheEventConsumer : CacheEventConsumer<Poll>;