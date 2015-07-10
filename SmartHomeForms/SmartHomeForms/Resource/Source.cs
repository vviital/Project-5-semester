using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHomeForms
{
    public class ReSource
    {
        public List<SourceType> Types { private set; get; }

        public ReSource(int type)
        {
            Types = new List<SourceType>();
            CreateTypes(type);
        }

        private void CreateTypes(int intType)
        {
            var typeOfSource = typeof (SourceType);

            var usingTypes = (SourceType) intType;
            
            //choose the flags
            var types = Enum.GetValues(typeOfSource).Cast<SourceType>().Where(item => usingTypes.HasFlag(item));
            
            foreach (var item in types)
            {
                Types.Add(item);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("    ");
            var types = Types.Select(x => x.ToString());
            foreach (var item in types)
            {
                result.Append(item + ' ');
            }
            return result.ToString();
        }

        public static List<SourceType> GetSourceTypes(SourceType sourceType)
        {
            return Enum.GetValues(typeof (SourceType)).Cast<SourceType>().Where(type => sourceType.HasFlag(type)).ToList();
        }
    }

}
