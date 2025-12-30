using Nop.Plugin.Misc.Polls.Domain;
using Nop.Services.Caching;

namespace Nop.Plugin.Misc.Polls.Services.Caching;

/// <summary>
/// Represents a poll answer cache event consumer
/// </summary>
public partial class PollAnswerCacheEventConsumer : CacheEventConsumer<PollAnswer>;