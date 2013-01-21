﻿using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class SymbolClassTagFormatter : TagFormatterBase<SymbolClassTag> {
        protected override XElement FormatTagElement(SymbolClassTag tag) {
            return new XElement(SwfTagNameMapping.SYMBOL_CLASS_TAG);
        }

        protected override void AcceptTagAttribute(SymbolClassTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(SymbolClassTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
