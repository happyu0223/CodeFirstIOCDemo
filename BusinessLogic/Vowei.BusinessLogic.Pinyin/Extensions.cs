using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.BusinessLogic.Pinyin
{
    public static class Extensions
    {
        public static string[] ToPinyins(char ch, PinyinStyle style = PinyinStyle.ToneNumber)
        {
            if (ChineseChar.IsValidChar(ch))
            {
                var cc = new ChineseChar(ch);
                switch (style)
                {
                    case PinyinStyle.ToneNumber:
                        return cc.Pinyins.Take(cc.PinyinCount).ToArray();
                    case PinyinStyle.NoTone:
                        return cc.Pinyins.Take(cc.PinyinCount)
                            .Select(py => py.Substring(0, py.Length - 1))
                            .Distinct().ToArray();
                    case PinyinStyle.Acronym:
                        return cc.Pinyins.Take(cc.PinyinCount)
                            .Select(py => py.Substring(0, 1))
                            .Distinct().ToArray();
                }
            }
            return null;
        }

        public static string ToPinyin(string s, PinyinStyle style = PinyinStyle.ToneNumber)
        {
            return s == null ? null : string.Join(" ", s
                .Select(ch => ToPinyins(ch, style))
                .Where(pys => pys != null)
                .Select(pys => string.Join("/", pys)));
        }
    }
}
