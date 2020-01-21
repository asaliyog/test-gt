using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Model
{
   public class Command
    {
        public string DataSourceName { get; set; }

        public SourceType DataSourceType { get; set; }

        public string DataSourcePath { get; set; }

        public PathType DataSourcePathType { get; set; }
    }
    public enum SourceType { 
        JSON,
        YML,
        CSV
    }
    public enum PathType { 
        URL,
        LocalPath
    }
}
