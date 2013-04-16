﻿using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;
using SwfLib.SwfMill.TagFormatting;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class StartSound2TagFormatter : TagFormatterBase<StartSound2Tag> {
        
        protected override void FormatTagElement(StartSound2Tag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "StartSound2"; }
        }
    }
}
