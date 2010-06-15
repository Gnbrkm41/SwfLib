﻿using System;
using System.IO;
using Code.SwfLib.Tags;

namespace Code.SwfLib
{
    public class Tag2BinaryVisitor : ISwfTagVisitor
    {

        public object Visit(CSMTextSettingsTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineBitsJPEG2Tag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineFont3Tag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineFontNameTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineShapeTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineSpriteTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineTextTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(EndTag tag)
        {
            return new SwfTagData { Type = SwfTagType.End, Data = new byte[0] };
        }

        public object Visit(ExportTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(FileAttributesTag tag)
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt32((uint)tag.Attributes);
            return new SwfTagData { Type = SwfTagType.FileAttributes, Data = mem.ToArray() };
        }

        public object Visit(MetadataTag tag)
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteString(tag.Metadata);
            return new SwfTagData { Type = SwfTagType.MetaData, Data = mem.ToArray() };
        }

        public object Visit(PlaceObject2Tag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(SetBackgroundColorTag tag)
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteRGB(tag.Color);
            return new SwfTagData { Type = SwfTagType.SetBackgroundColor, Data = mem.ToArray() };
        }

        public object Visit(ShowFrameTag tag)
        {
            return new SwfTagData { Type = SwfTagType.ShowFrame, Data = new byte[0] };
        }

        public object Visit(SwfTagBase tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(UnknownTag tag)
        {
            throw new NotImplementedException();
        }
    }
}
