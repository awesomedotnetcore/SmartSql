﻿using SmartSql.Abstractions;
using SmartSql.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSql.Configuration.Tags
{
    public class IsNotEqual : CompareTag
    {
        public override TagType Type => TagType.IsNotEqual;

        public override bool IsCondition(RequestContext context)
        {
            Object reqVal = GetPropertyValue(context);
            if (reqVal == null) { return false; }
            string reqValStr = string.Empty;
            if (reqVal is Enum)
            {
                reqValStr = Convert.ToInt64(reqVal).ToString();
            }
            else
            {
                reqValStr = reqVal.ToString();
            }
            return !reqValStr.Equals(CompareValue);
        }
    }
}
