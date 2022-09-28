using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace KingstoneProject.Models
{
    [Table("charactersheets")]
    public class CharacterSheet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Background { get; set; }
        public string SubBackground { get; set; }
        public string Player { get; set; }
        public string CharacterClass { get; set; }
        public string Foibles { get; set; }
        public string Distinction { get; set; }
        public string PrimaryDiscipline { get; set; }
        public string SecondaryDiscipline { get; set; }
        public int HarmTaken { get; set; }
        public int HarmFestered { get; set; }
        public string LeftHandName { get; set; }
        public string LeftHandImage { get; set; }
        public string RightHandName { get; set; }
        public string RightHandImage { get; set; }
        public string Specials { get; set; }
        public string CharacterImage { get; set; }
        public string Paw { get; set; }
        public int Strength { get; set; }
        public int Endurance { get; set; }
        public int Ready { get; set; }
        public int Agility { get; set; }
        public int Knowledge { get; set; }
        public int Proficiency { get; set; }
        public int Charisma { get; set; }
        public int Awareness { get; set; }
        public int Destruction { get; set; }
        public int Transmutation { get; set; }
        public int Restoration { get; set; }
    }
}
