﻿using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Filters;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class PlaceObject3TagFormatter : PlaceObjectBaseFormatter<PlaceObject3Tag> {

        private const string REPLACE_ATTRIB = "replace";
        private const string MORPH_ATTRIB = "morph";
        private const string ALL_FLAGS1_ATTRIB = "allflags1";
        private const string ALL_FLAGS2_ATTRIB = "allflags2";
        private const string BITMAP_CACHING_ATTRIB = "bitmapCaching";
        private const string EVENTS_ELEM = "events";


        protected override void AcceptPlaceAttribute(PlaceObject3Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case NAME_ATTRIB:
                    tag.Name = attrib.Value;
                    break;
                case "className":
                    tag.ClassName = attrib.Value;
                    break;
                case REPLACE_ATTRIB:
                    tag.Move = ParseBoolFromDigit(attrib);
                    break;
                case MORPH_ATTRIB:
                    tag.Ratio = ushort.Parse(attrib.Value);
                    break;
                case ALL_FLAGS1_ATTRIB:
                    //TODO: read flags1
                    break;
                case ALL_FLAGS2_ATTRIB:
                    //TODO: read flags2
                    break;
                case BITMAP_CACHING_ATTRIB:
                    tag.BitmapCache = byte.Parse(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptPlaceTagElement(PlaceObject3Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "filters":
                    foreach (var xFilter in element.Elements()) {
                        tag.Filters.Add(XFilter.FromXml(xFilter));
                    }
                    break;
                case EVENTS_ELEM:
                    //TODO: Read events
                    break;
                case "colorTransform":
                    tag.ColorTransform = XColorTransformRGBA.FromXml(element.Element("ColorTransform2"));
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override void FormatPlaceElement(PlaceObject3Tag tag, XElement elem) {
            if (tag.Name != null) {
                elem.Add(new XAttribute("name", tag.Name));
            }
            if (tag.ClassName != null) {
                elem.Add(new XAttribute("className", tag.ClassName));
            }
            if (tag.Ratio.HasValue) {
                elem.Add(new XAttribute("morph", tag.Ratio.Value));
            }
            elem.Add(new XAttribute("replace", CommonFormatter.Format(tag.Move)));
            if (tag.BitmapCache.HasValue) {
                elem.Add(new XAttribute(BITMAP_CACHING_ATTRIB, tag.BitmapCache.Value));
            }
            if (tag.ColorTransform.HasValue) {
                elem.Add(new XElement("colorTransform", XColorTransformRGBA.ToXml(tag.ColorTransform.Value)));
            }
            if (tag.Filters.Count > 0) {
                var xFilters = new XElement("filters");
                foreach (var filter in tag.Filters) {
                    xFilters.Add(XFilter.ToXml(filter));
                }
                elem.Add(xFilters);
            }
        }

        protected override bool HasCharacter(PlaceObject3Tag tag) {
            return tag.HasCharacter;
        }

        protected override void HasCharacter(PlaceObject3Tag tag, bool val) {
            tag.HasCharacter = val;
        }

        protected override bool HasMatrix(PlaceObject3Tag tag) {
            return tag.HasMatrix;
        }

        protected override void HasMatrix(PlaceObject3Tag tag, bool val) {
            tag.HasMatrix = val;
        }

        public override string TagName {
            get { return "PlaceObject3"; }
        }

    }
}