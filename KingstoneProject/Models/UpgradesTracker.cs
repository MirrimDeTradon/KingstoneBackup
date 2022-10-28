using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace KingstoneProject.Models
{
    [Table("upgradetrackers")]
    public class UpgradesTracker
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int s2 { get; set; }
        public int s4 { get; set; }
        public int e3 { get; set; }
        public int e5 { get; set; }
        public int r1 { get; set; }
        public int r2 { get; set; }
        public int r5 { get; set; }
        public int a3 { get; set; }
        public int a5 { get; set; }
        public int k1 { get; set; }
        public int k3 { get; set; }
        public int k5 { get; set; }
        public int k6 { get; set; }
        public int p2 { get; set; }
        public int p3 { get; set; }
        public int p4 { get; set; }
        public int c2 { get; set; }
        public int c3 { get; set; }
        public int c5 { get; set; }
        public int aw1 { get; set; }
        public int aw2 { get; set; }
        public int aw4 { get; set; }
        public int aw6 { get; set; }
        public int d1 { get; set; }
        public int d2 { get; set; }
        public int t1 { get; set; }
        public int t2 { get; set; }
        public int t3 { get; set; }
        public int re1 { get; set; }
    }
}
