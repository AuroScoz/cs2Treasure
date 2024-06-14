using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;
using Service.Realms;

[MapTo("map")]
public partial class DBMap : IRealmObject {
    [MapTo("_id")]
    [Required]
    [PrimaryKey]
    public string Id { get; set; }
    [MapTo("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }
    [MapTo("enable")]
    public bool? Enable { get; set; }
    [MapTo("jsonMapID")]
    public int? JsonMapID { get; set; }
    [MapTo("matchType")]
    public string MatchType { get; set; }

}