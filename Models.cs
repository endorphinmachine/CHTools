using System;
using System.Collections.Generic;

namespace CHTools
{
    public class Project
    {
        private string number;
        private string name;
        private string bjNo; // 报建编号
        private string pwNo; // 相关批文号
        private string ydNo; // 建设用地规划许可证
        private string location;
        private string builder;
        private string designer;
        private string contractor;
        private List<Build> builds;
        public string Number { get => number; set => number = value; }
        public string Name { get => name; set => name = value; }
        public string BJNo { get => bjNo; set => bjNo = value; }
        public string PWNo { get => pwNo; set => pwNo = value; }
        public string YDNo { get => ydNo; set => ydNo = value; }
        public string Location { get => location; set => location = value; }
        public string Builder { get => builder; set => builder = value; }
        public string Designer { get => designer; set => designer = value; }
        public string Contractor { get => contractor; set => contractor = value; }
        internal List<Build> Builds { get => builds; set => builds = value; }

        public Project()
        {
            Builds = new List<Build>();
        }
    }

    public class Build
    {
        private string number;
        private string name;
        private string yt;
        private string hs;
        private string z;
        private string ds;
        private string dx;
        private string jd;
        private string jr;
        private string jrsm;
        private string wqsm;
        private string smhd;
        private List<BuildUnit> units;

        public string Number { get => number; set => number = value; }  //工程编号
        public string Name { get => name; set => name = value; }  //建设项目名称
        public string YT { get => yt; set => yt = value; }
        public string HS { get => hs; set => hs = value; }
        public string Z { get => z; set => z = value; }
        public string DS { get => ds; set => ds = value; }
        public string DX { get => dx; set => dx = value; }
        public string JD { get => jd; set => jd = value; }
        public string JR { get => jr; set => jr = value; }
        public string JRSM { get => jrsm; set => jrsm = value; }
        public string WQSM { get => wqsm; set => wqsm = value; }
        public string SMHD { get => smhd; set => smhd = value; }
        public List<BuildUnit> Units { get => units; set => units = value; }

        public Build()
        {
            // 在构造函数中初始化 Units 属性为空的 List<BuildUnit>
            Units = new List<BuildUnit>();
        }

        // 先取整后求和的地上面积
        public int GetDS()
        {
            int sum = 0;
            foreach (var u in Units)
            {
                if (!u.Name.Contains("地下"))
                {
                    double area = double.Parse(u.Area);
                    int val = (int)Math.Round(area, 0);
                    sum += val;
                }
            }
            return sum;
        }

        public int GetDX()
        {
            int sum = 0;
            foreach (var u in Units)
            {
                if (u.Name.Contains("地下"))
                {
                    double area = double.Parse(u.Area);
                    int val = (int)Math.Round(area, 0);
                    sum += val;
                }
            }
            return sum;
        }
    }

    public class BuildUnit
    {
        private string name;
        private string area;
        private string function;
        private string floor;
        private bool isUdgGound;

        public string Name { get => name; set => name = value; }
        public string Area { get => area; set => area = value; }
        public string Function { get => function; set => function = value; }
        public string Floor { get => floor; set => floor = value; }
        public bool IsUdGround { get => isUdgGound; set => isUdgGound = value; }
    }

    public class Vector
    {
        private Dictionary<string, string> permission;
        private Dictionary<string, List<string>> function;
        private Dictionary<string, List<string>> facility;
        private Dictionary<string, List<string>> other;

        public Dictionary<string, string> Permission { get => permission; set => permission = value; }
        public Dictionary<string, List<string>> Function { get => function; set => function = value; }
        public Dictionary<string, List<string>> Facility { get => facility; set => facility = value; }
        public Dictionary<string, List<string>> Other { get => other; set => other = value; }

        public void Initialize()
        {
            Permission = new Dictionary<string, string>();
            Function = new Dictionary<string, List<string>>();
            Facility = new Dictionary<string, List<string>>();
            Other = new Dictionary<string, List<string>>();
        }
    }
}

