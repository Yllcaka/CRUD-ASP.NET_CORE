using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisionMVC.CustomMethods
{

    public class MinimumValueAttribute:ValidationAttribute
    {
        private readonly int _minValue;
        private readonly double _minValueDouble;
        private readonly bool _equal = true;
        public MinimumValueAttribute(int minValue) {
            _minValue = minValue;
        }
        public MinimumValueAttribute(double minValue, bool notEqual) {
            _minValueDouble = minValue;
            _equal = notEqual;
        }
        public override bool IsValid(object value)
        {
            return _equal?(int)value >= _minValue: (double)value > _minValueDouble;
        }
    }
}
