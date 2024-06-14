using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;
using Service.Realms;
using Cysharp.Threading.Tasks;

[MapTo("gladiator")]
public partial class DBGladiator : IRealmObject {
    [MapTo("_id")]
    [PrimaryKey]
    [Required]
    public string ID { get; private set; }
    [MapTo("createdAt")]
    public DateTimeOffset CreatedAt { get; private set; }
    [MapTo("ownerID")]
    public string OwnerID { get; private set; }
    [MapTo("jsonGladiatorID")]
    public int? JsonGladiatorID { get; set; }
    [MapTo("jsonSkillIDs")]
    public IList<int> JsonSkillIDs { get; }
    [MapTo("jsonTraitIDs")]
    public IList<int> JsonTraitIDs { get; }
    [MapTo("jsonEquipIDs")]
    public IList<int> JsonEquipIDs { get; }
    [MapTo("hp")]
    public int? HP { get; set; }
    [MapTo("curHP")]
    public int? CurHP { get; set; }
    [MapTo("vigorRegen")]
    public double? VigorRegen { get; set; }
    [MapTo("str")]
    public int? STR { get; set; }
    [MapTo("def")]
    public int? DEF { get; set; }
    [MapTo("mdef")]
    public int? MDEF { get; set; }
    [MapTo("crit")]
    public double? CRIT { get; set; }
    [MapTo("init")]
    public int? INIT { get; set; }
    [MapTo("knockback")]
    public int? Knockback { get; set; }
}