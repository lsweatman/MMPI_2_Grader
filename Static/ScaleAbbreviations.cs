using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMPI_Try_2.Static
{
    class ScaleAbbreviations
    {
        // Holds the abbreviated category names for display
        private static List<List<string>> categoryAbbrev = new List<List<string>>();

        private static List<string> basicNames = new List<string>() { "L", "F", "K", "Hs", "D", "Hy", "Pd", "Mf", "Pa", "Pt", "Sc", "Ma", "Si" };
        private static List<string> harrisLingoesNames = new List<string>() { "D1", "D2", "D3", "D4", "D5", "Hy1", "Hy2", "Hy3", "Hy4", "Hy5", "Pd1", "Pd2", "Pd3", "Pd4", "Pd5", "Pa1", "Pa2", "Pa3", "Sc1", "Sc2", "Sc3", "Sc4", "Sc5", "Sc6", "Ma1", "Ma2", "Ma3", "Ma4" };
        private static List<string> wienerHarmonNames = new List<string>() { "D-O", "D-S", "Hy-O", "Hy-S", "Pd-O", "Pd-S", "Pa-O", "Pa-S", "Ma-O", "Ma-S" };
        private static List<string> siSubNames = new List<string>() { "Si1", "Si2", "Si3" };
        private static List<string> supplementalNames = new List<string>() { "A", "R", "Es", "MAC-R", "FB", "VRIN", "TRIN", "O-H", "Do", "Re", "Mt", "GM", "GF", "PK", "PS", "MDS", "APS", "AAS", "ANX", "FRS", "OBS", "DEP", "HEA", "BIZ", "ANG", "CYN", "ASP", "TPA", "LSE", "SOD", "FAM", "WRK", "TRT" };

        public ScaleAbbreviations()
        {
            categoryAbbrev.Add(basicNames);
            categoryAbbrev.Add(harrisLingoesNames);
            categoryAbbrev.Add(wienerHarmonNames);
            categoryAbbrev.Add(siSubNames);
            categoryAbbrev.Add(supplementalNames);
        }

        public List<List<string>> getCategoryAbbrev()
        {
            return categoryAbbrev;
        }
    }
}
