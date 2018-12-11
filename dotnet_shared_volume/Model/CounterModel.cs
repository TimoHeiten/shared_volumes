using System;

namespace dotnet_shared_volume.Model
{
    public class CounterModel
    {
        public int Id { get; set; }
        public DateTimeOffset VisitedAt { get; set; }
    }
}