using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;
using Service.Realms;


[MapTo("playerState")]
public partial class DBPlayerState : IRealmObject {
    [Required]
    [MapTo("_id")]
    [PrimaryKey]
    public string ID { get; private set; }
    [MapTo("createdAt")]
    public DateTimeOffset CreatedAt { get; private set; }
    [MapTo("lastUpdatedAt")]
    public DateTimeOffset? LastUpdatedAt { get; private set; }

}