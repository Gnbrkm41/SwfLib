﻿using System.Xml.Linq;
using Code.SwfLib.Tags.ActionsTags;
using SwfLib.SwfMill.TagFormatting;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoABCDefineTagFormatter : TagFormatterBase<DoABCDefineTag> {

        protected override void FormatTagElement(DoABCDefineTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DoAbc"; }
        }

    }
}
