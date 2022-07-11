using System;
using System.Linq;
using ProtoBuf;

namespace MaterialChartPlugin.Models
{
    [ProtoContract]
    public class TimeMaterialsPair : IEquatable<TimeMaterialsPair>
    {
        /// <summary>
        /// 時刻
        /// </summary>
        [ProtoMember(1)]
        public DateTime DateTime { get; protected set; }

        /// <summary>
        /// 燃料
        /// </summary>
        [ProtoMember(2)]
        public int Fuel { get; protected set; }

        /// <summary>
        /// 弾薬
        /// </summary>
        [ProtoMember(3)]
        public int Ammunition { get; protected set; }

        /// <summary>
        /// 鋼材
        /// </summary>
        [ProtoMember(4)]
        public int Steel { get; protected set; }

        /// <summary>
        /// ボーキサイト
        /// </summary>
        [ProtoMember(5)]
        public int Bauxite { get; protected set; }

        /// <summary>
        /// 高速修復材
        /// </summary>
        [ProtoMember(6)]
        public int RepairTool { get; protected set; }

        /// <summary>
        /// 開発資材
        /// </summary>
        [ProtoMember(7)]
        public int DevelopmentTool { get; protected set; }

        /// <summary>
        /// 高速建造材
        /// </summary>
        [ProtoMember(8)]
        public int InstantBuildTool { get; protected set; }

        /// <summary>
        /// 改修資材
        /// </summary>
        [ProtoMember(9)]
        public int ImprovementTool { get; protected set; }

        public int MostMaterial(Boolean[] visible)
        {
            var material = new [] { Fuel, Ammunition, Steel, Bauxite };
            var result = visible
                .Zip(material, (first, second) => new { Visible = first, Material = second })
                .Where(x => x.Visible)
                .Select(x => x.Material);

            return result.Count() == 0 ? material.Max() : result.Max();

        }

        public int MinMaterial(Boolean[] visible)
        {
            var material = new[] { Fuel, Ammunition, Steel, Bauxite };

            var result = visible.Zip(material, (first, second) => new { Visible = first, Material = second })
                            .Where(x => x.Visible).Select(x => x.Material);

            return result.Count() == 0 ? 0 : result.Min();
        }

        public int MostTool(Boolean[] visible)
        {
            var tool = new[] { RepairTool, ImprovementTool, DevelopmentTool, InstantBuildTool };
            var result = visible
                .Zip(tool, (first, second) => new { Visible = first, Material = second })
                .Where(x => x.Visible)
                .Select(x => x.Material);

            return result.Count() == 0 ? tool.Max() : result.Max();

        }

        public int MinTool(Boolean[] visible)
        {
            var tool = new[] { RepairTool, ImprovementTool, DevelopmentTool, InstantBuildTool };

            var result = visible.Zip(tool, (first, second) => new { Visible = first, Material = second })
                            .Where(x => x.Visible).Select(x => x.Material);

            return result.Count() == 0 ? 0 : result.Min();
        }

        public TimeMaterialsPair() { }

        public TimeMaterialsPair(DateTime dateTime, int fuel, int ammunition, int steel, int bauxite, int repairTool,
            int developmentTool, int instantBuildTool, int improvementTool)
        {
            this.DateTime = dateTime;
            this.Fuel = fuel;
            this.Ammunition = ammunition;
            this.Steel = steel;
            this.Bauxite = bauxite;
            this.RepairTool = repairTool;

            // いつか使うかも？
            // いつ使うの？今で(ry
            this.DevelopmentTool = developmentTool;
            this.InstantBuildTool = instantBuildTool;
            this.ImprovementTool = improvementTool;
        }

        public bool Equals(TimeMaterialsPair other)
        {
            return this.DateTime == other.DateTime && this.Fuel == other.Fuel && this.Ammunition == other.Ammunition
                && this.Steel == other.Steel && this.Bauxite == other.Bauxite && this.RepairTool == other.RepairTool;
        }

        public override string ToString()
        {
            return $"DateTime={DateTime}, Fuel={Fuel}, Ammunition={Ammunition}, Steel={Steel}, Bauxite={Bauxite}, RepairTool={RepairTool}, DevelopmentTool={DevelopmentTool}, InstantBuildTool={InstantBuildTool}, ImprovementTool={ImprovementTool}";
        }
    }
}
