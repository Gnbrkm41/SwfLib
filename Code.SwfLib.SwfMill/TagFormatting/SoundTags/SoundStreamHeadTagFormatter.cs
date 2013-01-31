﻿using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class SoundStreamHeadTagFormatter : TagFormatterBase<SoundStreamHeadTag> {
        protected override void FormatTagElement(SoundStreamHeadTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "SoundStreamHeadTag"; }
        }
    }
}
