﻿using System.Xml.Linq;
using SwfLib.Tags.ControlTags;

namespace SwfLib.SwfMill.TagFormatting.ControlTags {
    public class ImportAssetsTagFormatter : TagFormatterBase<ImportAssetsTag> {
        protected override void FormatTagElement(ImportAssetsTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "ImportAssets"; }
        }
    }
}
