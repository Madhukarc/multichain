﻿/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LucidOcean.MultiChain
{
    public class JsonRpcRequest : IJsonRpcRequest
    {
        public Dictionary<string, object> Values { get; private set; }

        public JsonRpcRequest()
        {
            this.Values = new Dictionary<string, object>();
        }

        [JsonProperty("method")]
        public string Method
        {
            get
            {
                return this.GetValue<string>("method");
            }
            set
            {
                this.SetValue("method", value);
            }
        }

        [JsonProperty("params")]
        public object[] Params
        {
            get
            {
                return this.GetValue<object[]>("params");
            }
            set
            {
                this.SetValue("params", value);
            }
        }

        [JsonProperty("id")]
        public int Id
        {
            get
            {
                return this.GetValue<int>("id");
            }
            set
            {
                this.SetValue("int", value);
            }
        }
        private void SetValue(string name, object value)
        {
            this.Values[name] = value;
        }

        public T GetValue<T>(string name)
        {
            if (this.Values.ContainsKey(name))
                return (T)this.Values[name];
            else
                return default(T);
       }

    }
}
