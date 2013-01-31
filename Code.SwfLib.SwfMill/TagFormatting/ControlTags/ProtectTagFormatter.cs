﻿using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class ProtectTagFormatter : TagFormatterBase<ProtectTag> {
        protected override void FormatTagElement(ProtectTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "Protect"; }
        }
    }
}
