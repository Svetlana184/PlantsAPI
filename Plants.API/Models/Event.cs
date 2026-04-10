using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class Event
{
    public int IdEvent { get; set; }

    public string EventType { get; set; } = null!;

    public int? IdProductionBatch { get; set; }

    public int? IdUser { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
    [JsonIgnore]
    public virtual ProductionBatch? IdProductionBatchNavigation { get; set; }
    [JsonIgnore]
    public virtual User? IdUserNavigation { get; set; }
}
