﻿using SwfLib.Avm2.Data;

namespace SwfLib.Avm2 {
    public class AbcMethodParam {

        public string Name { get; set; }

        public AbcMultiname Type { get; set; }

        public AbcMethodParamDefaultValue Default { get; set; }

    }

    public abstract class AbcMethodParamDefaultValue {

        public static implicit operator AbcMethodParamDefaultValue(int val) {
            return new AbcMethodParamInt { Value = val };
        }

        public static implicit operator AbcMethodParamDefaultValue(uint val) {
            return new AbcMethodParamUInt { Value = val };
        }

        public static implicit operator AbcMethodParamDefaultValue(double val) {
            return new AbcMethodParamDouble { Value = val };
        }

        public abstract AsConstantType Type { get; }
    }

    public class AbcMethodParamInt : AbcMethodParamDefaultValue {

        public int Value { get; set; }

        public override string ToString() {
            return "int: " + Value;
        }

        public override AsConstantType Type {
            get { return AsConstantType.Integer; }
        }
    }

    public class AbcMethodParamUInt : AbcMethodParamDefaultValue {

        public uint Value { get; set; }

        public override string ToString() {
            return "uint: " + Value;
        }

        public override AsConstantType Type {
            get { return AsConstantType.UInteger; }
        }
    }

    public class AbcMethodParamDouble : AbcMethodParamDefaultValue {

        public double Value { get; set; }

        public override string ToString() {
            return "double: " + Value;
        }

        public override AsConstantType Type {
            get { return AsConstantType.Double; }
        }
    }
}
