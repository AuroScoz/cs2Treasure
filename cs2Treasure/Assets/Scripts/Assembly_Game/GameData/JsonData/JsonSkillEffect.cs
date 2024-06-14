using System.Collections.Generic;
using Scoz.Func;
using LitJson;
using System;
using Unity.Entities.UniversalDelegates;


namespace Gladiators.Main {
    public enum EffectType {
        Attack,//傷害
        RestoreHP,//生命
        RestoreVigor,//體力
        Dizzy,//暈眩
        Poison,//中毒
        Bleeding,//流血
        Burning,//著火
        Fearing,//恐懼
        Vulnerable,//無力
        Weak,//虛弱
        Fatigue,//疲勞
        Protection,//守護
        Reflection,//反射傷害
        Rush,//突擊
        Pull,//拉取
        Knockback,//擊退
        Enraged,//激怒
    }
    public class JsonSkillEffect : JsonBase {
        public static string DataName { get; set; }
        public new string ID { get; private set; }
        public string Name {
            get {
                return JsonString.GetString_static(DataName + "_" + ID, "Name");
            }
        }
        public string Description {
            get {
                return JsonString.GetString_static(DataName + "_" + ID, "Description");
            }
        }
        public int SkillID { get; private set; }
        public Target MyTarget { get; private set; }
        public List<SkillEffect> EnemyEffects = new List<SkillEffect>();
        public List<SkillEffect> MySelfEffects = new List<SkillEffect>();
        static Dictionary<int, List<JsonSkillEffect>> SkillEffectDataDic = new Dictionary<int, List<JsonSkillEffect>>();
        protected override void SetDataFromJson(JsonData _item) {
            JsonData item = _item;

            //反射屬性
            //var myData= JsonMapper.ToObject<SkillEffectJsonData>(item.ToJson());
            //// 使用反射來更新屬性
            //foreach (PropertyInfo propertyInfo in this.GetType().GetProperties()) {
            //    if (propertyInfo.CanRead && propertyInfo.CanWrite) {
            //        //下面這行如果報錯誤代表上方的sonMapper.ToObject<XXXXX>(item.ToJson());<---XXXXX忘了改目前Class名稱
            //        var value = propertyInfo.GetValue(myData, null);
            //        propertyInfo.SetValue(this, value, null);
            //    }
            //}

            //自定義屬性
            EffectType tmpTEffectType = EffectType.Attack;
            int tmpTypeValue = 0;
            foreach (string key in item.Keys) {
                switch (key) {
                    case "ID":
                        ID = (string)item[key];
                        break;
                    case "SkillID":
                        SkillID = (int)item[key];
                        break;
                    case "Target":
                        MyTarget = MyEnum.ParseEnum<Target>(item[key].ToString());
                        break;
                    default:
                        try {
                            if (key.Contains("EffectType")) {
                                tmpTEffectType = MyEnum.ParseEnum<EffectType>(item[key].ToString());
                            } else if (key.Contains("EffectValue")) {
                                tmpTypeValue = (int)item[key];
                            } else if (key.Contains("EffectProb")) {
                                SkillEffect effect = new SkillEffect(tmpTEffectType, (double)item[key], tmpTypeValue);
                                if (MyTarget == Target.Enemy) EnemyEffects.Add(effect);
                                else if (MyTarget == Target.Myself) MySelfEffects.Add(effect);
                            }
                        } catch (Exception _e) {
                            WriteLog.LogErrorFormat(DataName + "表格格式錯誤 ID:" + ID + "    Log: " + _e);
                        }
                        break;
                }
            }
            AddToSkillEffectDic(this);
        }
        protected override void ResetStaticData() {
        }
        void AddToSkillEffectDic(JsonSkillEffect _data) {
            if (SkillEffectDataDic.ContainsKey(_data.SkillID)) SkillEffectDataDic[_data.SkillID].Add(_data);
            else SkillEffectDataDic.Add(_data.SkillID, new List<JsonSkillEffect> { _data });
        }
        public static List<JsonSkillEffect> GetSkillEffectDatas(int _id) {
            if (SkillEffectDataDic.ContainsKey(_id)) return SkillEffectDataDic[_id];
            return null;
        }
    }
    public class SkillEffect {
        public EffectType EffectType { get; private set; }
        public double Prob { get; private set; }
        public int Value { get; private set; }

        public SkillEffect(EffectType _type, double _prob, int _value) {
            EffectType = _type;
            Prob = _prob;
            Value = _value;
        }
    }

}
