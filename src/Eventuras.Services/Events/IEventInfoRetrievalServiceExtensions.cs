using System;
using Eventuras.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventuras.Services.Events
{
    public static class IEventInfoRetrievalServiceExtensions
    {
        public static async Task<List<EventInfo>> GetUpcomingEventsAsync(
            this IEventInfoRetrievalService service,
            EventInfoFilter filter = null,
            EventInfoRetrievalOptions options = null)
        {
            return await service.ListEventsAsync(new EventInfoFilter(filter ?? new EventInfoFilter())
            {
                StatusNoneOf = new[]
                {
                    EventInfo.EventInfoStatus.Cancelled,
                    EventInfo.EventInfoStatus.Draft
                },
                StartDateAfter = DateTime.Now
            }, EventRetrievalOrder.StartDate, options);
        }

        public static async Task<List<EventInfo>> GetFeaturedEventsAsync(
            this IEventInfoRetrievalService service,
            EventInfoFilter filter = null,
            EventInfoRetrievalOptions options = null)
        {
            return await service.ListEventsAsync(new EventInfoFilter(filter ?? new EventInfoFilter())
            {
                FeaturedOnly = true,
                StatusNoneOf = new[]
                {
                    EventInfo.EventInfoStatus.Cancelled,
                    EventInfo.EventInfoStatus.Draft
                },
                StartDateAfter = DateTime.Now
            }, EventRetrievalOrder.StartDate, options);
        }

        public static async Task<List<EventInfo>> GetUnpublishedEventsAsync(
            this IEventInfoRetrievalService service,
            EventInfoFilter filter = null,
            EventInfoRetrievalOptions options = null)
        {
            return await service.ListEventsAsync(new EventInfoFilter(filter ?? new EventInfoFilter())
            {
                StatusOneOf = new[]
                {
                    EventInfo.EventInfoStatus.Cancelled,
                    EventInfo.EventInfoStatus.Draft
                }
            }, EventRetrievalOrder.StartDate, options);
        }

        public static async Task<List<EventInfo>> GetPastEventsAsync(
            this IEventInfoRetrievalService service,
            EventInfoFilter filter = null,
            EventInfoRetrievalOptions options = null)
        {
            return await service.ListEventsAsync(new EventInfoFilter(filter ?? new EventInfoFilter())
            {
                PastEventsOnly = true,
                StatusNoneOf = new[]
                {
                    EventInfo.EventInfoStatus.Cancelled,
                    EventInfo.EventInfoStatus.Draft
                }
            }, EventRetrievalOrder.StartDate, options);
        }

        public static async Task<List<EventInfo>> GetOnDemandEventsAsync(
            this IEventInfoRetrievalService service,
            EventInfoFilter filter = null,
            EventInfoRetrievalOptions options = null)
        {
            return await service.ListEventsAsync(new EventInfoFilter(filter ?? new EventInfoFilter())
            {
                StatusNoneOf = new[]
                {
                    EventInfo.EventInfoStatus.Cancelled,
                    EventInfo.EventInfoStatus.Draft
                },
                TypeOneOf = new[]
                {
                    EventInfo.EventInfoType.OnlineCourse
                }
            }, EventRetrievalOrder.Title, options);
        }

        public static async Task<List<EventInfo>> GetOngoingEventsAsync(
            this IEventInfoRetrievalService service,
            EventInfoFilter filter = null,
            EventInfoRetrievalOptions options = null)
        {
            return await service.ListEventsAsync(new EventInfoFilter(filter ?? new EventInfoFilter())
            {
                TodaysEventsOnly = true,
                StatusNoneOf = new[]
                {
                    EventInfo.EventInfoStatus.Cancelled,
                    EventInfo.EventInfoStatus.Draft
                }
            }, EventRetrievalOrder.StartDate, options);
        }
    }
}
